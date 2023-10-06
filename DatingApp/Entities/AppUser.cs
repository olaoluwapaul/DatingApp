using System.ComponentModel.DataAnnotations;
//uses using System.ComponentModel.DataAnnotations;

namespace DatingApp.Entities
{
    public class AppUser
    {
        //[Key] 
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
