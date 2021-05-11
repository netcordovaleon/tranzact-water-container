using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.WaterContainer.App.Dto;
using Tranzact.WaterContainer.App.Responses;

namespace Tranzact.WaterContainer.App.Operators
{
    public interface IWaterContainerOperator
    {
        WaterContainerResponse ResultWaterContainer(CoordinateDTO request);
    }
}
