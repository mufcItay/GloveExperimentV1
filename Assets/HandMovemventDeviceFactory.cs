using System;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment
{
    /// <summary>
    /// Factory class for HandMovementDevices, creates only one copy of each Device.
    /// </summary>
    public static class HandMovemventDeviceFactory
    {
        #region Data Members
        /// <summary>
        /// member of gloves device
        /// </summary>
        private static GlovesDevice sGlovesDevice;
        /// <summary>
        /// member of simulation device
        /// </summary>
        private static SimulationFileDevice sSimulationFIleDevice;
        
        /// <summary>
        /// member of Replay device
        /// </summary>
        private static ReplayFileDevice sReplayFileDevice;
        #endregion

        #region Functions

        /// <summary>
        /// The function gets relevant instance of hand movement device,
        /// if the device wasn't already created it will be created otherwise just returned.
        /// </summary>
        /// <param name="exType">ExperimentType that the device belongs to</param>
        /// <returns>abstraction of an device according to exType</returns>
        static public IHandMovementDevice GetOrCreate(ExperimentType exType)
        {
            IHandMovementDevice device = null;

            switch (exType)
            {
                case ExperimentType.Active:
                    if (sGlovesDevice == null)
                    {
                        sGlovesDevice = new GlovesDevice();
                    }
                    device = sGlovesDevice;
                    break;
                case ExperimentType.PassiveSimulation:
                    if (sSimulationFIleDevice == null)
                    {
                        sSimulationFIleDevice = new SimulationFileDevice();
                    }
                    device = sSimulationFIleDevice;
                    break;
                case ExperimentType.PassiveWatchingReplay:
                    if (sReplayFileDevice == null)
                    {
                        sReplayFileDevice = new ReplayFileDevice();
                    }
                    device = sReplayFileDevice;
                    break;
                default:
                    break;
            }

            return device;
        } 
        #endregion
    }
}