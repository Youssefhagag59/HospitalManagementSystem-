using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Dtos
{
    public class InvoiceDetailsDto
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }
        public string PatientName { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public AppStatus AppStatus { get; set; }
        
    }
}
