using CFX.Structures.SolderingStation.Identification;
namespace CFX.Structures.SolderingStation.Sensor
{
    /// <summary>
    /// Soldering station minutes countdown to enter Sleep or Hibernation mode 
    /// </summary>
    public class SleepHibernateDelayMinutes : IdentifySolderingStation
    {
        /// <summary>
        /// Soldering station minutes countdown to enter Sleep mode 
        /// </summary>
        public int EnterSleepMinutesDelay
        {
            get; set;
        }
        /// <summary>
        /// Soldering station minutes countdown to enter Hibernation mode 
        /// </summary>
        public int EnterHibernateMinutesDelay
        {
            get; set;
        }
    }
}
