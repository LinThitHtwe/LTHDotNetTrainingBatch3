namespace DotNetTrainningBatch3.MVCApp.Models
{
    public class DashedLineChartModel
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }

    public class DashedLineChartResponseModel
    {
        public List<DashedLineChartModel> Series { get; set; }
        public List<string> Labels { get; set; }
    }
}
