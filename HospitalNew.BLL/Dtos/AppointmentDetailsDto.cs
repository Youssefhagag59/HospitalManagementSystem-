using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Dtos
{
    public class AppointmentDetailsDto
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public string DocName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppTime { get; set; }
        public AppStatus Status { get; set; }
    }
}
