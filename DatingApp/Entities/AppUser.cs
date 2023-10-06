using System.ComponentModel.DataAnnotations;

namespace DatingApp.Entities
{
    public class AppUser
    {
        //[Key] uses using System.ComponentModel.DataAnnotations;
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
