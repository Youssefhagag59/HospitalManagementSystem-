using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface IInvoicesService : IGenericService<Invoice>
    {
        Task<Invoice> GetInvoiceById(int  id);
        Task<Invoice> DeleteInvoice(int id);
        Task<ServiceResult<Invoice>> UpdateInvoice(int id, InvoiceDto invoice);
        Task<IEnumerable<Invoice>> GetInvoiceDetails();
        int CalculateInvoicePrice();
        Task<Invoice> AddInvoice(InvoiceDto dto);
    }
}
