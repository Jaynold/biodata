
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Title { get; set; }
    }
}