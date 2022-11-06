using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetByID(int ID);
        void Add(DepartmentVM dept);
        void Update(DepartmentVM dept);
        void Delete(int ID);
        /*
         IQuerable -> select query and filter it in database
         IEnumerable -> select data in database and filter in the memory of the device
         */

    }
}
