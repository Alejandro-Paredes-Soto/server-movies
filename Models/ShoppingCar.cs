using System.ComponentModel.DataAnnotations;

namespace server_movies.Models
{
    public class ShoppingCar
    {
      
        [Key]
        public int IdUser { get; set; }

        [Key]
        public int IdMovie { get; set; }
    }
}
