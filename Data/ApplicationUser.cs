using Microsoft.AspNetCore.Identity;

namespace BlazorApp.WareHouse.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsActived { get; set; }
    }

}
