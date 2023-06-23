using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuiXuanHung0281.Models
{
    public class BXHstudent
    {
        [Key]
         public int BXHstudentID { get; set; }
        public string BXHstudentName{ get; set; }
        public string BXHstudentSex{ get; set; }
       
    }
}
