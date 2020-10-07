using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructureIdeo.Models
{
    public class Knots
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(280)]
        public string Text { get; set; }


        public int? ParentId { get; set; }

    }
}

