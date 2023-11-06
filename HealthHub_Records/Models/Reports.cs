using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.Models
{
    public class Reports
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string title { get; set; }

        [DataType(DataType.Text), Display(Name = "Description")]
        public string Description { get; set; }
        public int? userid { get; set; }

        [Display(Name = "File")]
        [NotMapped]
        public IFormFile file { get; set; } = default!;

        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}

