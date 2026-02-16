using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.DAL.Models
{
    public class Specialty : BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
    }
}
