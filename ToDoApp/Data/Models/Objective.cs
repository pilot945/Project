using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Objective
    { 
        //идентификатор
        public Guid Id {  get; set; }

        //свойства
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExecuteDate { get; set; }

        //навигационные свойства 
        public Guid CreatorId { get; set; }
        public Guid AssigneeId { get; set; }
        public virtual User Creator { get; set; } = null!;
        public virtual User Assignee { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public bool IsExecuted { get; set; }
    }

}
