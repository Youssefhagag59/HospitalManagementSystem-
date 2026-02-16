using AutoMapper;
using HospitalNew.BLL.Dtos;
using HospitalNew.DAL.Models;



namespace HospitalNew.BLL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>();

            
            CreateMap<Appointment, AppointmentDetailsDto>()
                .ForMember(dest => dest.DocName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.AppStatus));
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<DoctorDetailsDto, DoctorDto>();
            CreateMap<DoctorDto, DoctorDetailsDto>();
            CreateMap<DoctorDetailsDto, Doctor>();
            CreateMap<Specialty, SpecialtyDto>();
            CreateMap<SpecialtyDto, Specialty>();
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Specialty,Specialty>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Appointment, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Doctor, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Patient, PatientDetailsDto>();
            CreateMap<PatientDetailsDto, Patient>();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<Invoice, InvoiceDetailsDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Appointment.Doctor.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Appointment.Patient.Name))
                .ForMember(dest => dest.DoctorSpecialty, opt => opt.MapFrom(src => src.Appointment.Doctor.Specialty.Name))
                .ForMember(dest => dest.AppStatus, opt => opt.MapFrom(src => src.Appointment.AppStatus));
            CreateMap<Doctor, DoctorDetailsDto>()
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty.Name));
            CreateMap<UserDto, UserDetailsDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();

        }
    }
}
