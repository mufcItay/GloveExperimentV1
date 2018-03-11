using System;
using CommonTools;

namespace TestGame
{
    public static class ExperimentStrategyFactory
    {
        private static ActiveExperimentStrategy sActiveStrategy;
        private static PassiveSimulationExperimentStrategy sSimulationStrategy;
        private static PassiveReplayExperimentStrategy sReplayStrategy;

        static public BaseExperimentStrategy GetOrCreate(ExperimentType exType)
        {
            BaseExperimentStrategy strategy = null;

            switch (exType)
            {
                case ExperimentType.Active:
                    if (sActiveStrategy == null)
                    {
                        sActiveStrategy = new ActiveExperimentStrategy();
                    }
                    strategy = sActiveStrategy;
                    break;
                case ExperimentType.PassiveSimulation:
                    if (sSimulationStrategy == null)
                    {
                        sSimulationStrategy = new PassiveSimulationExperimentStrategy();
                    }
                    strategy = sSimulationStrategy;
                    break;
                case ExperimentType.PassiveWatchingReplay:
                    if (sReplayStrategy == null)
                    {
                        sReplayStrategy = new PassiveReplayExperimentStrategy();
                    }
                    strategy = sReplayStrategy;
                    break;
                default:
                    break;
            }

            return strategy;
        }
    }
}