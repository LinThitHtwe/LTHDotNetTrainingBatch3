using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainningBatch3.MVCApp.Models
{
    [Table("Radar")]
    public class RadarModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Month")]
        public string Month { get; set; }
        [Column("Series")]
        public int Series { get; set; }
    }
}
