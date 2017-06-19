using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Model.Models
{
    [Table("Error")]
    public class Error
    {
        [Key]
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { set; get; }
        public DateTime CreateDate { set; get; }
    }
}
