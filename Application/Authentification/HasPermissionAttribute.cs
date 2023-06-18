using Microsoft.AspNetCore.Authorization;

namespace Application.Authentification
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {

        public HasPermissionAttribute(Permission permission) 
        :base(policy: permission.ToString())
        { }
    }
}
