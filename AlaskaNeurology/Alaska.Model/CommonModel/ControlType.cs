using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alaska.Model.CommonModel
{
    public class LControlType
    {
       [Key]
        public int PkControlTypeId { get; set; }
        public string ControlType { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
