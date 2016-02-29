using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Alaska.Model.CommonModel
{
    public class ScreenConfiguration
    {
        #region properties
        [Key]
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string Description { get; set; }
        public bool? IsExistAlert { get; set; }
        public bool? IsAutoPreviousInfo { get; set; }
        public bool? IsPreviousInfo { get; set; }
        public bool? IsHistoryInfo { get; set; }
        public string DefaultCss { get; set; }
        public byte? ScreenLevel { get; set; }
        public byte ActiveStatus { get; set; }
        #endregion



    }
}
