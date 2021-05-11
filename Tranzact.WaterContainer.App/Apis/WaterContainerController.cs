using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tranzact.WaterContainer.App.Dto;
using Tranzact.WaterContainer.App.Responses;
using Tranzact.WaterContainer.App.Operators;

namespace Tranzact.WaterContainer.App.Apis
{
    [ApiController]
    [Route("container/challenge")]
    public class WaterContainerController : ControllerBase
    {

        private readonly IWaterContainerOperator waterContainerSolution;
        public WaterContainerController(IWaterContainerOperator _waterContainerSolution)
        {
            this.waterContainerSolution = _waterContainerSolution;
        }

        [HttpPost("WaterContainerResult")]
        [Route("result")]
        public WaterContainerResponse GetWaterContainerResult(CoordinateDTO request) {
            return this.waterContainerSolution.ResultWaterContainer(request);
        }
    }
}
