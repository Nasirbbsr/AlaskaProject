using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alaska.Model.CommonModel
{
    public class ScreenDomainModel
    {
        [Key]
        public int ScreenModelID { get; set; }
        public string ModelName { get; set; }
        public byte ActiveStatus{ get; set; }
        }
}
