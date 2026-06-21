# CLAUDE.md

Guidance for working in this repository. This file documents the conventions and standards already established in the codebase — follow them when adding or modifying code.

## What this is

This is the **CFX (Connected Factory Exchange) SDK** — the open-source C# reference implementation of the IPC-2591 CFX standard, an industry messaging standard for electronics manufacturing (SMT lines, assembly, test, materials handling). The library defines the message envelope, the catalog of CFX messages, the shared data structures they reference, and the AMQP/HTTP transport used to publish and subscribe them.

- **NuGet package:** `CFX.CFXSDK`
- **License:** Apache-2.0
- **Owner:** IPC CFX Committee / Association of Connecting Electronics Industries
- **Upstream:** https://github.com/IPCConnectedFactoryExchange/CFX
- The library is consumed by third parties and strong-named — treat the public API as a contract. Renames and signature changes are breaking changes.

## Solution layout

| Project | Purpose |
|---------|---------|
| `CFX/` | The SDK library itself — messages, structures, transport, utilities. The only shipped artifact. |
| `CFXUnitTests/` | MSTest suite (AMQP broker connectivity, direct connect, serialization round-trips). |
| `CFXExampleEndpoint/` | WinForms reference app demonstrating endpoint usage and JSON-schema generation. |
| `AppendixNotesTool/` | Utility tool. |
| `docs/` | Sandcastle-generated HTML/CHM reference documentation (generated output — do not hand-edit). |

Within `CFX/`, code is organized by CFX domain namespace:
`CFX` (envelope + base messages), `CFX.Production`, `CFX.ResourcePerformance`, `CFX.Materials`, `CFX.InformationSystem`, `CFX.Sensor`, `CFX.Maintenance`, `CFX.Structures` (shared data structures + enums), `CFX.Transport` (AMQP/HTTP), `CFX.Utilities` (serialization, logging, attributes).

## Build & test

```bash
dotnet build CFX.sln              # build all projects
dotnet test CFXUnitTests/         # run the test suite
```

- The library multi-targets: `netstandard1.6;net8.0;netcoreapp3.1;net462`. Any new code must compile across **all** of these — avoid APIs that aren't available on netstandard1.6 / net462.
- Unit tests target `net48` and use **MSTest** (`[TestClass]` / `[TestMethod]`).
- There is no CI pipeline in the repo; builds and tests are run locally / in Visual Studio 2022.

## Core architecture

- **`CFXMessage`** (`CFX/CFXMessage.cs`) — abstract base class for every CFX message. Holds no data; provides `ToJson()`, `FromJson<T>()`, `ToBytes()`, `FromBytes<T>()`, `FromTypeName()`. Every message class inherits from it.
- **`CFXEnvelope`** (`CFX/CFXEnvelope.cs`) — the transport wrapper around a single message. Carries `MessageName`, `Version`, `TimeStamp`, `UniqueID`, `Source`, `Target`, `RequestID`, and the `MessageBody`.
- **`CFXJsonSerializer`** (`CFX/Utilities/JsonConvert.cs`) — the single serialization entry point wrapping Newtonsoft.Json. Always serialize/deserialize through `CFXMessage`/`CFXEnvelope` helpers, never call `JsonConvert` directly from message code.
- Serialization is **Newtonsoft.Json (13.x)** with `TypeNameHandling.Auto` and `TypeNameAssemblyFormatHandling.Simple`. Deserialization always enables type tracking so polymorphic `$type` info round-trips.

## Conventions for messages and structures

When adding a new message or data structure, mirror the existing pattern exactly. `CFX/ResourcePerformance/LogEntryRecorded.cs` and `CFX/Production/ActivitiesExecuted.cs` are good templates.

### Class declaration
- **Messages** inherit from `CFXMessage` and live in a domain namespace (e.g. `CFX.Production`).
- **Structures** (shared, reusable types referenced by messages) inherit from nothing and live in `CFX.Structures`.
- One public class (or enum) per file; the **filename matches the type name** in PascalCase.
- Message names use natural tense — events past tense (`WorkCompleted`, `FaultOccurred`), requests/responses suffixed (`...Request` / `...Response`).

### JSON / polymorphism attributes
- A class containing polymorphic members (base-type properties or collections of a base type) is decorated:
  ```csharp
  [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
  public class ActivitiesExecuted : CFXMessage
  ```
- A **single polymorphic property** (whose declared type is a base class with subtypes) must carry:
  ```csharp
  [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
  public LogEntryAdditionalData AdditionalData { get; set; }
  ```
  Omitting this is a real, recurring bug — subtypes silently fail to deserialize (see commit history for `LogEntryRecorded.AdditionalData`). **Any property typed as a polymorphic base class needs this attribute.**

### Enums
- Declared in their own file in `CFX.Structures`, with string serialization:
  ```csharp
  [JsonConverter(typeof(StringEnumConverter))]
  public enum TestResult { Passed, Failed, Error }
  ```
- Every enum **member** gets its own `<summary>`.

### Properties & constructors
- Public auto-properties (`{ get; set; }`). Scalars are not initialized inline.
- **Collections and nested structures are initialized in a default constructor**, never inline:
  ```csharp
  public ActivitiesExecuted()
  {
      Activities = new List<Activity>();
  }
  ```
- Provide a parameterless constructor; set sensible enum/GUID/DateTime defaults there (e.g. `Guid.NewGuid()`, `DateTime.Now`, `LogImportance.Information`).

### XML documentation (required)
- Every public class, property, and enum member has a `<summary>`. Docs are part of the shipped product (`GenerateDocumentationFile=true` feeds the Sandcastle reference site).
- **Message classes include a sample JSON payload** in the class summary, inside a `<code language="none"> … </code>` block — see `LogEntryRecorded.cs`. Add one for every new message.

### Versioning of new members
- Anything added after the current spec version is tagged with the version it first appeared in, on both the attribute and the doc:
  ```csharp
  /// <summary>
  /// <para>** NOTE: ADDED in CFX 1.4 **</para>
  /// Optional additional data depending on the machine type
  /// </summary>
  [CFX.Utilities.CreatedVersion("1.4")]
  public LogEntryAdditionalData AdditionalData { get; set; }
  ```
- `OtherTests.GetChanges` reflects over `CreatedVersionAttribute` to report API deltas — keep these accurate.

## Versioning & releasing

- Two distinct versions:
  - **CFX standard version** — `CFXEnvelope.CFXVERSION` (currently `"2.1"`), stamped into every envelope.
  - **SDK/assembly/package version** — set in `CFX/CFX.csproj` (`PackageVersion`, `Version`, `AssemblyVersion`, `FileVersion`), currently `2.1.1`. Semantic versioning.
- When bumping the SDK version, update all four version tags in `CFX.csproj` together (the git history does this in dedicated "Bumping Version" commits).
- The assembly is strong-named via `CFXStrongNameKey.snk`; symbol packages (`.snupkg`) are published alongside.

## Git & contribution workflow

- Changes land via **pull requests** (commit subjects carry the PR number, e.g. `(#261)`).
- Commit subjects are short and imperative, describing the spec/structure change (e.g. "Add GenericProcessData structure", "Addition of missing rejection reasons in the case of an electrical test"). Many reference the requesting party.
- New structure proposals are sometimes accompanied by a top-level design markdown (e.g. `GenericProcessData.md`) describing the structure before/with implementation.

## When making changes — checklist

1. Pick the right namespace/folder; one type per file, filename = type name.
2. Inherit `CFXMessage` for messages; nothing for structures.
3. Initialize collections/structures in a parameterless constructor.
4. Add `<summary>` to the type and every member; add a sample-JSON `<code>` block for messages.
5. Decorate polymorphic base-typed properties/collections with `ItemTypeNameHandling = TypeNameHandling.Auto`.
6. Use `[JsonConverter(typeof(StringEnumConverter))]` on enums.
7. Tag post-2.1 additions with `[CFX.Utilities.CreatedVersion("x.y")]` and a `** NOTE: ADDED in CFX x.y **` para.
8. Ensure it compiles on all target frameworks; add/extend a serialization round-trip test if behavior is non-trivial.
9. Remember the public API is a strong-named contract — additive changes only unless a major version bump is intended.
