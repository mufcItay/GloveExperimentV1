using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasHandExperiment
{
    /// <summary>
    /// IHandData impelemntation for hand movement directed from a key press. releven to simulation experiments
    /// </summary>
    public class KeyPressedData : IHandData
    {
        #region Data Members
        /// <summary>
        /// current key pressed
        /// </summary>
        private string mKeyPressed;
        #endregion

        #region Properties
        /// <summary>
        /// property for the key that was pressed
        /// </summary>
        public string KeyPressed { get { return mKeyPressed; } }

        #endregion

        #region Ctors
        /// <summary>
        /// creates an instance with first key pressed = ""
        /// </summary>
        public KeyPressedData()
        {
            mKeyPressed = string.Empty;
        }

        /// <summary>
        /// creates an instance with initial key pressed
        /// </summary>
        /// <param name="keyPressed">the initial key pressed</param>
        public KeyPressedData(string keyPressed)
        {
            mKeyPressed = keyPressed;
        }
        #endregion

        #region Functions

        /// <summary>
        /// the fucntino clones given instance of the class
        /// </summary>
        /// <returns>a clone f the instnace</returns>
        public object Clone()
        {
            KeyPressedData clone = new KeyPressedData(mKeyPressed);
            return clone;
        }

        /// <summary>
        /// implementation of filling the instance by settign key pressed
        /// </summary>
        /// <param name="data">the data from which to determine which key was pressed</param>
        public void SetHandMovementData(object data)
        {
            mKeyPressed = data.ToString();
        } 
        #endregion
    }
}
