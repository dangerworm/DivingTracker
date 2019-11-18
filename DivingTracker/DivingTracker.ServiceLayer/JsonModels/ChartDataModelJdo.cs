namespace DivingTracker.ServiceLayer.JsonModels
{
    public class ChartDataModelJdo
    {
        public string type { get; set; }
        public ChartDataJdo data { get; set; }
        public ChartOptionsJdo options { get; set; }
    }
}
