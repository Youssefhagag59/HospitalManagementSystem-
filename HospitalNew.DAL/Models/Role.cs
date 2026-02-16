using System.Text.Json.Serialization;

namespace HospitalNew.DAL.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter<Role>))]
    public enum Role
    {
        Admin,
        Doctor,
        Patient,
        Receptionist,
        Manager,
        Accountant
    }
}
