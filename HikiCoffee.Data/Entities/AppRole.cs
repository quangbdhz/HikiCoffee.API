using Microsoft.AspNetCore.Identity;

namespace HikiCoffee.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
