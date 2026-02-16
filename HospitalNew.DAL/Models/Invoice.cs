using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.DAL.Models
{
    public class Invoice : BaseEntity
    {
       
        public int AppId { get; set; }
        public Appointment Appointment { get; set; } 
        public int Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        //public List<String> PaymentMethod { get; set; } = new List<String> { "Cash" , "Credit"};
    }
}


//fi 7aga msh zabta app w invoice da5lin f circle fix it