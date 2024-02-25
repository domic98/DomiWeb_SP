using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomiWeb.Models.Helper
{
    public class RoleManagement
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
