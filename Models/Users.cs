using System.ComponentModel.DataAnnotations;

namespace server_movies.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public String Name { get; set; }
        public String Last_Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public DateTime Date_Create { get; set; }

        public int Active { get; set; }


   


    }
}
