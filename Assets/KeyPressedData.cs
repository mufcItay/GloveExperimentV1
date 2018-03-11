using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class KeyPressedData : IHandData
    {
        private string mKeyPressed;

        public string KeyPressed { get { return mKeyPressed; } }

        public KeyPressedData()
        {
            mKeyPressed = string.Empty;
        }

        public KeyPressedData(string keyPressed)
        {
            mKeyPressed = keyPressed;
        }
        public object Clone()
        {
            KeyPressedData clone = new KeyPressedData(mKeyPressed);
            return clone;
        }

        public void SetHandMovementData(object data)
        {
            mKeyPressed = data.ToString();
        }
    }
}
