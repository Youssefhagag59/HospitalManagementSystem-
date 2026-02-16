using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.DAL.Models
{
    public class Appointment : BaseEntity
    {
      
        public int DocId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppTime { get; set; }
        public Invoice Invoice { get; set; }
        public AppStatus AppStatus { get; set; }
        //public string Status { get; set; }
    }
}
