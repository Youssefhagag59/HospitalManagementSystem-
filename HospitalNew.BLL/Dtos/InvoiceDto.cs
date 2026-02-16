using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Dtos
{
    public class InvoiceDto
    {
        public int AppId { get; set; }
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
