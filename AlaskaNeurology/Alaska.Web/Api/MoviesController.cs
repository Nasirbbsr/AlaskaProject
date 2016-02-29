
#region namespaces
using Alaska.DB.Infrastructure;
using Alaska.Model.DataModel;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using System.Collections.Generic;
using System.Linq;
#endregion namespaces
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Alaska.Web.API
{
    [Route("api/[controller]")]
    public class MoviesController
    {
        private readonly IApplicationEnvironment _hostEnvironment;
        
        private UnitOfWork _unitOfWork;
        public MoviesController (IApplicationEnvironment hostEnvironment, UnitOfWork unitofwork)
        {
            _hostEnvironment = hostEnvironment;

            _unitOfWork = unitofwork;
        }
            
      
       
        [HttpGet("{pageSize}/{pnum}/{sortColumn}/{sorttype}")]
        public IEnumerable<People> Get(int pageSize, int pnum, string sortColumn = null, string sorttype = null)
        {

            var PeopleList = _unitOfWork.PeopleRepository;
            IEnumerable<People> resultSet = null;
            if (sortColumn == "null")
            {
                resultSet = PeopleList.All().OrderBy(p => p.Id).Skip((pnum - 1) * pageSize).Take(pageSize);
            }
            else
            {
                string Scol = sortColumn.ToString().Trim();
                var propertyInfo = typeof(People).GetProperty(Scol);
                if (sorttype.Trim().ToLower()=="asc")
                {
                   
                    resultSet = PeopleList.All().OrderBy(p => propertyInfo.GetValue(p, null)).Skip((pnum - 1) * pageSize).Take(pageSize);
                }
                else
                {
                    resultSet = PeopleList.All().OrderByDescending(p => propertyInfo.GetValue(p, null)).Skip((pnum - 1) * pageSize).Take(pageSize);
                }
            }

            
            return resultSet.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
