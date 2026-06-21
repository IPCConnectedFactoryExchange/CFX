# CFX SDK Integration Tests

End-to-end integration tests that exercise the CFX SDK against real infrastructure in containers.
Unlike `CFXUnitTests` (net48, Windows-only, points at a pre-existing broker), everything here is
cross-platform (net8.0) and self-contained: Docker Compose stands up the dependencies, runs the
test, and reports pass/fail via the runner's process exit code.

## Layout

```
IntegrationTests/
  docker-compose.yml      # shared infra (broker, broker-init) + one runner service per scenario
  rabbitmq/
    rabbitmq.conf         # broker config (enables the AMQP 1.0 v1 address format the SDK uses)
  RabbitMqRoundTrip/      # scenario: publish a message to RabbitMQ and verify receipt
    RabbitMqRoundTrip.csproj
    Program.cs
    Dockerfile
  README.md               # this file
```

## Scenarios

### RabbitMqRoundTrip

Connects to a RabbitMQ broker via `AmqpCFXEndpoint`, publishes an `EndpointConnected` message to a
fanout exchange, and synchronously waits (via `OnCFXMessageReceived` + an `AutoResetEvent`) for the
same message — matched by `CFXEnvelope.UniqueID` — to arrive on the bound queue. Exits `0` on
receipt, `1` on timeout or connection error. Mirrors the `FireAndWait` pattern in
`CFXUnitTests/BrokerTests.cs`.

The broker is `rabbitmq:4-management`. RabbitMQ 4.x supports AMQP 1.0 natively; `rabbitmq/rabbitmq.conf`
permits the deprecated **v1** address format (`/exchange/X`, `/queue/Q`) that the SDK uses. A one-shot
`broker-init` container declares the durable fanout exchange, the durable queue, and the binding via
the management HTTP API.

## Running locally

From this directory:

```bash
docker compose run --build --rm rabbitmq-roundtrip   # exit code == test result
docker compose down -v                                # cleanup
```

`compose run` waits for the broker to become healthy and for `broker-init` to finish before running
the test. (We avoid `up --exit-code-from`, since the one-shot `broker-init` exiting would otherwise
tear the stack down early.)

### Without Docker

Point the runner at a manually running RabbitMQ 4.x broker (with v1 addressing permitted and the
`CFXTestExchange`/`CFXTestQueue` topology declared):

```bash
BROKER_HOST=localhost dotnet run --project RabbitMqRoundTrip
```

Configuration (all via environment variables, with defaults):

| Variable | Default | Meaning |
|----------|---------|---------|
| `BROKER_HOST` | `broker` | Broker hostname |
| `BROKER_PORT` | `5672` | AMQP port |
| `BROKER_USER` / `BROKER_PASS` | `cfxtest` / `cfxtest` | Credentials |
| `CFX_EXCHANGE` | `/exchange/CFXTestExchange` | Publish address |
| `CFX_QUEUE` | `/queue/CFXTestQueue` | Subscribe address |
| `CFX_VHOST` | _(default vhost `/`)_ | Optional virtual host, e.g. `vhost:MyHost` |
| `CFX_TIMEOUT_MS` | `30000` | Receive timeout |

## CI

`.github/workflows/integration-test.yml` runs the exact same `docker compose run` command on
`ubuntu-latest`, so local and CI share one source of truth. The runner's exit code drives the job
result; broker logs are dumped on failure and the stack is torn down afterward.

## Adding a new integration test

1. Create a new sibling folder `IntegrationTests/<Scenario>/` with a net8.0 console project
   (reference `..\..\CFX\CFX.csproj`), a `Program.cs` that exits `0`/`1`, and a `Dockerfile`
   (build context = repo root).
2. Add a runner service to `docker-compose.yml`. Reuse `broker` (add
   `depends_on: broker-init: condition: service_completed_successfully`) if it needs RabbitMQ, or
   add your own infrastructure service.
3. Add a step (or a job) to `.github/workflows/integration-test.yml` that runs
   `docker compose run --build --rm <your-service>`.
