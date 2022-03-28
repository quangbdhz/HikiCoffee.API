using Microsoft.AspNetCore.Identity;

namespace HikiCoffee.Data.Entities
{
    internal class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
