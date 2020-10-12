
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Biodata
    {
        [Key]
        [MaxLength(90)]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(90)]
        public string Name { get; set; }

        [Required]
        [MaxLength(90)]
        public string Description { get; set; }

        [Required]
        [MaxLength(90)]
        public string Homepage { get; set; }

        [Required]
        [MaxLength(90)]
        public string Owner { get; set; }

        public List<Language> Languages { get; set; }
        public virtual List<Link> Links { get; set; }
        public List<OperatingSystem> OperatingSystems { get; set; }
        public List<ToolType> ToolTypes { get; set; }
    }
}