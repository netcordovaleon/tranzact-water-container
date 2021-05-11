using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tranzact.WaterContainer.App.Services
{
    public interface IWaterContainerServices
    {
        int getLength(int[] coordinates);
        int calculateArea(int baser, int height);
    }
}
