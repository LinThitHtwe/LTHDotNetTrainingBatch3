using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainningBatch3.MVCApp.Models
{
    [Table("PageStatistic")]
    public class PageStatistic
    {
        [Key]
        [Column("PageStatisiticsId")]
        public int PageStatisiticsId { get; set; }
        [Column("SessionDuration")]
        public int SessionDuration { get; set; }
        [Column("PageViews")]
        public int PageViews {  get; set; }
        [Column("TotalViews")]
        public int TotalViews { get; set; }
        [Column("CreatedDate")]
        public string CreatedDate { get; set; }
    }
}
