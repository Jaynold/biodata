
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Biodata
    {
        [Key]
        [MaxLength(15)]
        public string Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(45)]
        public string Description { get; set; }
        [MaxLength(20)]
        public string Homepage { get; set; }
        public List<Language> Languages { get; set; }
        public List<Link> Links { get; set; }
        public List<OperatingSystem> OperatingSystems { get; set; }
        public List<ToolType> ToolType { get; set; }
    }
}