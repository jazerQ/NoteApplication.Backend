using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Note
    {
        public Note(string Title, string Description) 
        {
            this.Title = Title;
            this.Description = Description;
            this.CreatedAt = DateTime.UtcNow;
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
