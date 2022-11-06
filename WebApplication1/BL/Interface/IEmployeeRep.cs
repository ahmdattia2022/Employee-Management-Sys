using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetByID(int Id);
        void Add(EmployeeVM emp);
        void Update(EmployeeVM emp);
        void Delete(int Id);
    }
}
