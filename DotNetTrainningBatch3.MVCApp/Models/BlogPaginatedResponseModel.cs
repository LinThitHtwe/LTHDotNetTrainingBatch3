﻿namespace DotNetTrainningBatch3.MVCApp.Models
{
    public class BlogPaginatedResponseModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        //public bool IsEndOfPage { get; set; }
        public bool IsEndOfPage => PageNo >= PageCount;
        public List<BlogModel> Data { get; set; }

    }
}
