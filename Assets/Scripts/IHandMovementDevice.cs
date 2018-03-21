using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasHandExperiment
{
    /// <summary>
    /// interface for a device that reads movement data 
    /// </summary>
    public interface IHandMovementDevice
    {
        /// <summary>
        /// opens the device and initializes it. MUST be called to start the device
        /// </summary>
        /// <returns> the function returns a boolean indicating whether it successfully opened the device,
        /// if device is already opened returns false</returns>
        bool Open();

        /// <summary>
        /// The function reads movement data and returns a IHandData structure that describes the hand movement
        /// </summary>
        /// <returns>IHandData structure that describes the had movement</returns>
        IHandData GetHandData();

        /// <summary>
        /// closes the device. MUST be called after we stopped using the device
        /// </summary>
        void Close();
    }
}
