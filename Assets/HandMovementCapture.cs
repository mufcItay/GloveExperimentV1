using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public sealed class HandMovementCapture
    {
        private static readonly HandMovementCapture sInstance = new HandMovementCapture();

        static HandMovementCapture()
        {
        }

        private HandMovementCapture()
        {

        }

        public static HandMovementCapture Instance
        {
            get
            {
                return sInstance;
            }
        }
    }
}
