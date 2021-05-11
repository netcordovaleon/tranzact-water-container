namespace Tranzact.WaterContainer.App.Services
{
    public class WaterContainerServices : IWaterContainerServices
    {
        public int calculateArea(int baser, int height)
        {
            return baser * height;
        }

        public int getLength(int[] coordinates)
        {
            return coordinates.Length;
        }

    }
}
