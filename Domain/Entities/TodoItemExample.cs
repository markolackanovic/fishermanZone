using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoItemExample
    {
        public int Id { get; set; }
        public int ListId { get; set; }

        public string? Title { get; set; }

        public string? Note { get; set; }

        public DateTime? Reminder { get; set; }
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

    }
}