namespace DivingTracker.ServiceLayer.JsonModels
{
    public class ChartOptionsJdo
    {
        public int cutoutPercentage { get; set; }
        public ChartScalesJdo scales { get; set; }
    }

    public class ChartScalesJdo
    {
        public ChartYAxesJdo[] yAxes { get; set; }
    }

    public class ChartYAxesJdo
    {
        public ChartTicksJdo ticks { get; set; }
    }

    public class ChartTicksJdo
    {
        public bool beginAtZero { get; set; }
    }
}
