using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class Chore
    {
        [Required(ErrorMessage = "Field {0} is needed")]
        public int Id { get; set; }

        public string Owner{ get; set; }

        [Required(ErrorMessage = "Field {0} is needed")]
        public string Name { get; set; }
        
        public bool Completed { get; set; } = false;

        public DateTime CompletionDate { get; set; }
    }
}