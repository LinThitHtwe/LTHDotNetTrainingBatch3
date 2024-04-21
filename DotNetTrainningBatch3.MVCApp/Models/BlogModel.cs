using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainningBatch3.MVCApp.Models
{
    [Table("Blog2")]
    public class BlogModel
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string Author { get; set; }
    }

    public class BlogResponseModel 
    {
        public Boolean IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
