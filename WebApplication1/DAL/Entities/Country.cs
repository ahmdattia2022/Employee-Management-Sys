using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }


        public virtual ICollection<City> Cities { get; set; }

    }
}
