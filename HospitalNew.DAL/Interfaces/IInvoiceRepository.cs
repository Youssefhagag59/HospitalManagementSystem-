using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetDetails();
        int CalculateInvoicePrice();
    }
}
