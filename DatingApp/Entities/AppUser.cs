using DatingApp.Extentions;

namespace DatingApp.Entities
{
    public class AppUser
    {
        //[Key] 
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } //byte arrays for the password hash
        public byte[] PasswordSalt { get; set; } //byte arrays for the password salt
        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Indroduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new();

        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }
    }
}
