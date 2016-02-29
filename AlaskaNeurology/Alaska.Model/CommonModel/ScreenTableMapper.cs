using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alaska.Model.CommonModel
{
    public class ScreenTableMapper
    {
        #region properties
      [Key]
        public int ScreenModelControlId { get; set; }
        public int FKScreenModelId { get; set; }
        public string ModelProperty { get; set; }
        public int? FKControlTypeId { get; set; }
        public byte? ActiveStatus { get; set; }
        #endregion

      

    }
}
