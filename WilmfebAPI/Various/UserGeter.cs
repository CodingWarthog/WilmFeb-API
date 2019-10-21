using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WilmfebAPI.Various
{
    public interface IUserGeter
    {
        int GetUser();
    }
    public class UserGeter : PageModel, IUserGeter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserGeter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public  int GetUser()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            //var context = _httpContextAccessor.HttpContext;
            //var user6 = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
