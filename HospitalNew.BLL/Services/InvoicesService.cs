using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.BLL.Services
{
    public class InvoicesService : GenericService<Invoice>, IInvoicesService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoicesService(IInvoiceRepository invoiceRepository, IAppointmentRepository appointmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CalculateInvoicePrice()
        {
            return _unitOfWork.invoiceRepository.CalculateInvoicePrice();
        }

        public async Task<Invoice> DeleteInvoice(int id)
        {
            var invoice = await _unitOfWork.invoiceRepository.GetById(id);
            if(invoice == null) 
                return null;
            _unitOfWork.invoiceRepository.Delete(invoice);
            _unitOfWork.SaveChanges();
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoiceDetails()
        {
            return await _unitOfWork.invoiceRepository.GetDetails();
        }

        public Task<Invoice> GetInvoiceById(int id)
        {
            var invoice = _unitOfWork.invoiceRepository.GetById(id);
            if(invoice == null) 
                return null;
            return invoice;
        }

        public async Task<ServiceResult<Invoice>> UpdateInvoice(int id, InvoiceDto invoice)
        {
            var inv = await _unitOfWork.invoiceRepository.GetById(id);
            if (inv == null)
                return ServiceResult<Invoice>.Fail("Invoice doesn't exist");
            if (!_unitOfWork.appointmentRepository.IsValidAppointment(invoice.AppId))
                return ServiceResult<Invoice>.Fail("Invalid appointment ID");
            _mapper.Map(invoice, inv);
            _unitOfWork.invoiceRepository.Update(inv);
            _unitOfWork.SaveChanges();
            return ServiceResult<Invoice>.Ok(inv, "Invoice updated successfully");
        }

        public async Task<Invoice> AddInvoice(InvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            if(!_unitOfWork.appointmentRepository.IsValidAppointment(dto.AppId))
                return null;
            await _unitOfWork.invoiceRepository.Add(invoice);
            _unitOfWork.SaveChanges();
            return invoice;
        }
    }
}
