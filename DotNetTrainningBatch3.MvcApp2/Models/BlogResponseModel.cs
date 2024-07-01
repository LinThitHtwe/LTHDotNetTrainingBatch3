namespace DotNetTrainningBatch3.MvcApp2.Models
{
    public class BlogResponseModel
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
        public bool isEndOfPage => pageNo >= pageCount;
        public List<BlogModel> data { get; set; }
    }

    public class BlogModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string content { get; set; }
    }

}
