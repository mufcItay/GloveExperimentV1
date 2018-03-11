using System;
using CommonTools;

namespace TestGame
{
    public static class HandMovemventDeviceFactory
    {
        private static GlovesDevice sGlovesDevice;
        private static SimulationFileDevice sSimulationFIleDevice;
        private static ReplayFileDevice sReplayFileDevice;

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
    }
}