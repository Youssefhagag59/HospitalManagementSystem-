using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Dtos
{
    public class AppointmentDto
    {
        public int DocId { get; set; }
        
        public int PatientId { get; set; }
        public DateTime AppTime { get; set; }
        public AppStatus AppStatus { get; set; }
    }
}
 