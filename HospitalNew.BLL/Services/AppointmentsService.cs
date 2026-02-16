using AutoMapper;
using HospitalNew.DAL.Data;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HospitalNew.BLL.Interfaces;

namespace HospitalNew.BLL.Services
{
    public class AppointmentsService : GenericService<Appointment>, IAppointmentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentRepository _appointmentsRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public AppointmentsService(IAppointmentRepository appointmentsRepository, IDoctorRepository doctorRepository
            ,IPatientRepository patientRepository,IInvoiceRepository invoiceRepository, 
             IMapper mapper, IUnitOfWork unitOfWork) 
            : base(appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<Appointment>> AddAppointment(AppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto); // Mapping DTO to Appointment entity
            if (!_unitOfWork.appointmentRepository.IsValidDate(dto.AppTime))
                return ServiceResult<Appointment>.Fail("Appointment time must be in the future");
            if (!_unitOfWork.doctorRepository.IsValid(dto.DocId))
                return ServiceResult<Appointment>.Fail("Doctor doesn't exist"); 
            if (!_unitOfWork.patientRepository.IsValid(dto.PatientId))
                return ServiceResult<Appointment>.Fail("Patient doesn't exist");
            await _unitOfWork.appointmentRepository.Add(appointment);

            if (dto.AppStatus == AppStatus.Comfirmed)
            {
                var invoice = new Invoice
                {
                    Appointment = appointment,
                    Price = _unitOfWork.invoiceRepository.CalculateInvoicePrice()
                };
                await _unitOfWork.invoiceRepository.Add(invoice);
            }
            _unitOfWork.SaveChanges();
            return ServiceResult<Appointment>.Ok(appointment,"Appointment added successfully");
        }

        public async Task<Appointment> DeleteAppointment(int id)
        {
            var app = await _unitOfWork.appointmentRepository.GetById(id);
            if (app == null)
                return null;
            _unitOfWork.appointmentRepository.Delete(app);
            _unitOfWork.SaveChanges();
            return app;
        }

        public Task<IEnumerable<Appointment>> GetAppointmentsDetails()
        {
            return _unitOfWork.appointmentRepository.GetDetails();
        }

        public bool IsValidAppointment(int id)
        {
            return _unitOfWork.appointmentRepository.IsValidAppointment(id);
        }

        public bool IsValidDate(DateTime date)
        {
            return _unitOfWork.appointmentRepository.IsValidDate(date);
        }

        public async Task<ServiceResult<Appointment>> UpdateAppointment(int id, AppointmentDto appointment)
        {
            var app =await _unitOfWork.appointmentRepository.GetById(id);
            if (app == null)
                return null;
            if (!_unitOfWork.appointmentRepository.IsValidDate(appointment.AppTime))
                return ServiceResult<Appointment>.Fail("Appointment time must be in the future");
            if (!_unitOfWork.doctorRepository.IsValid(appointment.DocId))
                return ServiceResult<Appointment>.Fail("Doctor doesn't exist");
            if (!_unitOfWork.patientRepository.IsValid(appointment.PatientId))
                return ServiceResult<Appointment>.Fail("Patient doesn't exist");

            _mapper.Map(appointment, app);
            _unitOfWork.appointmentRepository.Update(app);
            _unitOfWork.SaveChanges();
            return ServiceResult<Appointment>.Ok(app, "Appointment updated successfully");
        }

    }
}
