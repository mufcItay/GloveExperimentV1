using CommonTools;
using System;
using System.Collections.Generic;

namespace TestGame
{
    /// <summary>
    /// the class represents a simulation file device, reads from a simulation file the keys that need to be simulated
    /// </summary>
    public class SimulationFileDevice : BaseHandMovementFileDevice
    {
        /// <summary>
        /// created the IHandData relevant to keyPress data
        /// </summary>
        /// <returns>initial emty data of key press</returns>
        public override IHandData CreateHandMovementData()
        {
            return new KeyPressedData();
        }


        /// <summary>
        /// the simulation confguration element to read from
        /// </summary>
        /// <returns>path to simulation file</returns>
        public override string GetFileName()
        {
            return ConfigurationManager.Instance.Configuration.ReplayFilePath;
        }

        /// <summary>
        /// override of coordinates update.
        /// here we are only intersted in the key that was pressed
        /// </summary>
        /// <param name="coordinatesLine"></param>
        protected override void OnCoordinatesUpdate(string[] coordinatesLine)
        {
            // get the field of key press
            string keyPressed = coordinatesLine[CommonConstants.KEY_PRESS_COL_INDEX];
            mData.SetHandMovementData(keyPressed);
        }
        
    }
}