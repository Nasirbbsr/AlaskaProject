using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alaska.Model.CommonModel
{
    public class ScreenControlDBMapper
    {
        #region properties
        [Key]
        public int ControlDbId { get; set; }
        public int FKScreenId { get; set; }
        public int FKScreenModelControlId { get; set; }
        public string Description { get; set; }
        public string LabelName { get; set; }
        public short? SortPriority { get; set; }
        public string DefaultCssClass { get; set; }
        public bool? IsColumnFullWidth { get; set; }
        public byte? ActiveStatus { get; set; }

        #endregion

    }
}
