using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {   
        //идентификатор
        public Guid Id { get; set; }

        //свойства
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        //обратные навигвционные свойства
        public virtual ICollection<Objective> CreatedObjectives { get; set; } = null!;
        public virtual ICollection<Objective> AssignedObjectives { get; set; } = null!;

        public bool IsDeleted { get; set; }
       
    }
   
}
