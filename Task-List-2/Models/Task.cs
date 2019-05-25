using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_List_2.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}