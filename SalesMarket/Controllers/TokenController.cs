using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesMakert.Data.Model;
using SalesMarket.Repo;
using SalesMarket.Serv;

namespace SalesMarket.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IUserService userService;
        private SalesDbContext dbContext;
        private IConfiguration _configuration;
        public TokenController(IUserService userService, SalesDbContext context,IConfiguration configuration)
        {
            dbContext = context;
            this.userService = userService;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult RequestToken(Tokens tokens) 
        {
            var user = userService.GetUserByName(tokens);
            if(user.UserName != tokens.userName && user.Password != tokens.password)
            {
                return Unauthorized();
            }
            var tokenInDb = dbContext.TokensData.Where(n => n.UsersId == user.Id).Select(n => n).FirstOrDefault();
            dynamic key;
            if (tokenInDb != null)
            {
                var refreshTokenExpiry = tokenInDb.ExpiryRefreshToken;
                var tokenExpiry = tokenInDb.ExpiryToken;

                if (refreshTokenExpiry - DateTime.Now < TimeSpan.FromMinutes(0.0) || tokenExpiry - DateTime.Now < TimeSpan.FromSeconds(0.0))
                {
                    var accessToken = CreateToken(tokens, user.Id,out key);
                    tokenInDb.Token = accessToken.Token;
                    tokenInDb.RefreshToken = accessToken.RefreshToken;
                    tokenInDb.ExpiryRefreshToken = accessToken.ExpiryRefreshToken;
                    tokenInDb.ExpiryToken = accessToken.ExpiryToken;
                    tokenInDb.LastUpdate = accessToken.LastUpdate;
                    dbContext.SaveChanges();
                    var tokenObj = new Dictionary<string, string>();
                    tokenObj.Add("token", accessToken.Token);
                    tokenObj.Add("refreshToken", accessToken.RefreshToken);
                    return Ok(tokenObj);

                }
                else if (tokenExpiry - DateTime.Now < TimeSpan.FromMinutes(0.0) || tokenExpiry - DateTime.Now < TimeSpan.FromSeconds(0.0))
                {
                    var accessToken = UpdateAccessToken(tokens, user.Id,out key);
                    tokenInDb.Token = accessToken.Token;
                    tokenInDb.ExpiryToken = accessToken.ExpiryToken;
                    tokenInDb.LastUpdate = accessToken.LastUpdate;
                    dbContext.SaveChanges();
                    var tokenObj = new Dictionary<string, string>();
                    tokenObj.Add("token", accessToken.Token);
                    //tokenObj.Add("key", key);
                    return Ok(tokenObj);
                    
                }
            }
           
            if (tokenInDb == null)
            {
                var accessToken = CreateToken(tokens, user.Id, out key);
                dbContext.TokensData.Add(accessToken);
                dbContext.SaveChanges();
                var token = new Dictionary<string, string>();
                token.Add("token", accessToken.Token);
                token.Add("refreshToken", accessToken.RefreshToken);
                //token.Add("key", key);
                return Ok(token);
            }
            var tokenData = new Dictionary<string, string>();
            tokenData.Add("token", tokenInDb.Token);
            tokenData.Add("refreshToken", tokenInDb.RefreshToken);
            
            return Ok(tokenData);
          
        }
        
        public TokensData CreateToken(Tokens tokens,int id,out dynamic key) 
        {
            var user = userService.GetUserByName(tokens);
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes( _configuration["SecurityKey"] ));
            var keyRefreshToken = new SymmetricSecurityKey(Encoding.ASCII.GetBytes( _configuration["RefreshKey"] ));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Console.WriteLine(key);
            var expiry = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["expiryTokenInMin"]));
            var expiryRefreshToken = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["expiryRefreshTokenInMin"]));
            var token = new JwtTokenBuilder()
                               .AddSecurityKey(JwtSecurityKey.Create(_configuration["SecurityKey"]))
                               .AddSubject("test123 test123")
                               .AddIssuer("SalesMarket.Security.Bearer")
                               .AddAudience("SalesMarket.Security.Bearer")
                               .AddClaim("MembershipId", "111")
                               .AddExpiry(1)
                               .Build();

            var refreshToken = new JwtTokenBuilder()
                               .AddSecurityKey(keyRefreshToken)
                               .AddSubject("test123 test123")
                               .AddIssuer("SalesMarket.Security.Bearer")
                               .AddAudience("SalesMarket.Security.Bearer")
                               .AddExpiry(Convert.ToInt32(_configuration["expiryRefreshTokenInMin"]))
                               .AddClaim("MembershipId", "121")
                               .Build();

            TokensData tokensData = new TokensData
            {
                Token = token.Value,
                RefreshToken = refreshToken.Value,
                ExpiryToken = expiry,
                ExpiryRefreshToken = expiryRefreshToken,
                AddedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                UsersId = id
            };



            return tokensData;
        }

        public TokensData UpdateAccessToken(Tokens tokens, int id, out dynamic key)
        {
            var user = userService.GetUserByName(tokens);
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["SecurityKey"] ));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Console.WriteLine(key);
            var expiry = DateTime.Now.AddMinutes(5);
 
            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create(_configuration["SecurityKey"]))
                               .AddSubject("test123 test123")
                               .AddIssuer("SalesMarket.Security.Bearer")
                               .AddAudience("SalesMarket.Security.Bearer")
                               .AddClaim("MembershipId", "111")
                               .AddExpiry(1)
                               .Build();
            TokensData tokensData = new TokensData
            {
                Token = token.Value,
                ExpiryToken = expiry,
                AddedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                UsersId = id
            };

            return tokensData;
        }

    }
}