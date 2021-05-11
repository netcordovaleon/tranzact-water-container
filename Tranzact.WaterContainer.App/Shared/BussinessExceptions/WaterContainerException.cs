using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tranzact.WaterContainer.App.Shared.BussinessExceptions
{
    [Serializable]
    public class WaterContainerException : Exception
    {
        public WaterContainerException()
        {
        }

        public WaterContainerException(string message) : base(message)
        {
        }
    }
}
