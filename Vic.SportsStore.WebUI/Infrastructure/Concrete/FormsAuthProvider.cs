using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;

namespace Vic.SportsStore.WebApp.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public EFDbContext EFDb { get; set; }
        static string HashMD5(string  text)
        {
            var source = Encoding.UTF8.GetBytes(text);
            using (MD5 hasher = MD5.Create())
            {
                var result = hasher.ComputeHash(source);
                return Convert.ToBase64String(result);
            }
        }
        //private const string DefaultUser = "admin3";
        //private const string DefaultPwd = "fX6U9OMYOJ643oDcrd/7Mg==";
        public bool Authenticate(string username, string password)
        {
            bool result = false;
            var user = EFDb.Users.FirstOrDefault(i => i.UserName == username);
            if(user != null)
            {
                var inputPwdHash = HashMD5(password);
                if(user.Password == HashMD5(password))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}