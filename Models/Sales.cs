using System.ComponentModel.DataAnnotations;

namespace server_movies.Models
{
    public class Sales
    {
        [Key]
        public int IdSale { get; set; }
        public int IdUser { get; set; }
        public int IdMovie { get; set;}

        public int idPaymentMethod { get; set; }

        public int total {  get; set; }

        public DateTime Date_Created { get; set; }
    }
}
