using Tranzact.WaterContainer.App.Dto;
using Tranzact.WaterContainer.App.Responses;
using Tranzact.WaterContainer.App.Services;
using Tranzact.WaterContainer.App.Shared.BussinessExceptions;

namespace Tranzact.WaterContainer.App.Operators
{
    public class WaterContainerOperator : IWaterContainerOperator
    {
        private readonly IWaterContainerServices arrayAreaServices;
        public WaterContainerOperator(IWaterContainerServices _arrayAreaServices)
        {
            this.arrayAreaServices = _arrayAreaServices;
        }
        public WaterContainerResponse ResultWaterContainer(CoordinateDTO request)
        {
            validateLength(request.CoordinateY);
            int length = this.arrayAreaServices.getLength(request.CoordinateY);
            var response = new WaterContainerResponse();
            response.Result =  CalculateResult(length, request.CoordinateY);
            return response;

            int CalculateResult(int _length, int[] _coordinates) {
                int output = 0;
                for (int i = 0; i < _length; i++)
                {
                    for (int j = _length - 1; j > i; j--)
                    {
                        int baser = (j - i);
                        int height = (_coordinates[i] < _coordinates[j]) ? _coordinates[i] : _coordinates[j];
                        int area = this.arrayAreaServices.calculateArea(baser, height);
                        output = (area > output) ? area : output;
                    }
                }
                return output;
            }
        }

        protected void validateLength(int[] coordinates) {
            if (coordinates.Length < 2)
                throw new WaterContainerException("Coordinates not found");
        }

    }
}
