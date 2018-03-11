using CommonTools;
using System;
using System.Collections.Generic;

namespace TestGame
{
    public class SimulationFileDevice : BaseHandMovementFileDevice
    {
        public SimulationFileDevice()
        {
        }

        public override IHandData CreateHandMovementData()
        {
            return new KeyPressedData();
        }

        public override string GetFileName()
        {
            return ConfigurationManager.Instance.Configuration.ReplayFilePath;
        }

        protected override void OnCoordinatesUpdate(string[] coordinatesLine)
        {
            string keyPressed = coordinatesLine[CommonConstants.KEY_PRESS_COL_INDEX];
            mData.SetHandMovementData(keyPressed);
        }
        
    }
}