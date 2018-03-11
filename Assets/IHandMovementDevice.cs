using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public interface IHandMovementDevice
    {
        void Open();

        IHandData GetHandData();

        void Close();
    }
}
