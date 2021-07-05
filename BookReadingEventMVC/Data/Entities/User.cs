using System.ComponentModel.DataAnnotations;

namespace BookReadingEventMVC.Data.Entities
{ 
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
