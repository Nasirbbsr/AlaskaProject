using Alaska.Model.ModelConstraint;
using System.ComponentModel.DataAnnotations;
namespace Alaska.Model.DataModel
{
    public class People : IPrimaryKey<int>
    {

        #region properties
        [Required]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Gender { get; set; }
        public string company { get; set; }
        #endregion

    }
}
