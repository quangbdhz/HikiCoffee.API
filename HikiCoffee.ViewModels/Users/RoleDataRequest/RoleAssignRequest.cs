using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.ViewModels.Users.RoleDataRequest
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }

        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
