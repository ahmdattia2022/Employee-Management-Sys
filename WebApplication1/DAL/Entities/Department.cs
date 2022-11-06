using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Code  { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}
