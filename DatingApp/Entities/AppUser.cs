using System.ComponentModel.DataAnnotations;

namespace DatingApp.Entities
{
    public class AppUser
    {
        //[Key] 
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } //byte arrays for the password salt
        public byte[] PasswordSalt { get; set; } //byte arrays for the password salt
    }
}
