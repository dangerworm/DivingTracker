namespace DivingTracker.ServiceLayer.JsonModels
{
    public class ChartDataJdo
    {
        public string[] labels { get; set; }
        public ChartDataSetJdo[] datasets { get; set; }
    }
}
