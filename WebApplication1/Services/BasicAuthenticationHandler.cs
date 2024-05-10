//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Microsoft.Extensions.WebEncoders.Testing;
//using Microsoft.Identity.Client;
//using WebApplication1.Models;

//namespace WebApplication1.Services
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly WebApiDemoContext _context;

//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            WebApiDemoContext context) : base(options, logger, encoder)
//        {
//            _context = context;
//        }
        
//        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers.Authorization.ToString());
//            byte[] decodedHeader = Convert.FromBase64String(authHeader.Parameter ?? "");

//            string[] auth = Encoding.UTF8.GetString(decodedHeader).Split(':', 2);

//            //var user = _context.Users.FirstOrDefault(u => u.Username == auth[0] && u.Password == auth[1]);
//            (string UserId, string Username)? user = ("", "");

//            if (user == null) return AuthenticateResult.Fail("User not found");
//            else
//            {
//                var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.NameIdentifier, user?.UserId),
//                    new Claim(ClaimTypes.Name, user?.Username),
//                };
//                var identify = new ClaimsIdentity(claims, Scheme.Name);
//                var principal = new ClaimsPrincipal(identify);
//                var ticket = new AuthenticationTicket(principal, Scheme.Name);
//                return AuthenticateResult.Success(ticket);
//            }
//        }
//    }
//}
