
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(90)]
        public string Name { get; set; }

        public List<Biodata> Biodata { get; set; }
    }
}