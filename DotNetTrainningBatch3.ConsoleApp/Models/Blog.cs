using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.Models
{
    [Table("Blog2")]
    public class Blog
    {
        [Key]
        [Column("id")]
        //public int Id { get; set; }
        public string Id { get; set; }
        [Column("title")]
        public string Title {  get; set; }
        [Column("author")]
        public string Author { get; set; }
    }
}
