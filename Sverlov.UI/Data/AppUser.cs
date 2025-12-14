using Microsoft.AspNetCore.Identity;


namespace Sverlov.UI.Data
{
    public class AppUser:IdentityUser
    {

        public byte[]? Avatar { get; set; } 
    }
}
