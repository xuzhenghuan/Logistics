using System;
using System.Collections.Generic;
using Logistics.IDAL;
using Dapper;
using System.Data.SqlClient;
using Logistics.Common;
using Logistics.MODEL;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Logistics.DAL
{
    public class UserDal : IUser
    {
        SqlConnection conn = new SqlConnection(Connection.MSSql);
        
        public UserModel Login(UserModel m,string sql)
        {

            m.UserPwd = MD5Helper.MD5Encrypt(m.UserPwd);//利用md5进行密码加密
            //参数化
            var par = new { @a = m.UserName, @b = m.UserPwd };

            //执行查询语句
            UserModel data = conn.Query<UserModel>(sql,par).FirstOrDefault();//多的该用户的权限信息

            if(data==null)
            {
                return null;//表示查询不到改账号信息
            }

            //var jwtConfig = Configuration.GetSection("Jwt");
            //秘钥，就是标头，这里用Hmacsha256算法，需要256bit的密钥
            var securityKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your-256-bit-secret")), SecurityAlgorithms.HmacSha256);
            //Claim，JwtRegisteredClaimNames中预定义了好多种默认的参数名，也可以像下面的Guid一样 自己定义键名.
            //ClaimTypes也预定义了好多类型如role、email、name。Role用于赋予权限，不同的角色可以访 问不同的接口
            //相当于有效载荷
            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Iss,"徐征欢"),
                new Claim(JwtRegisteredClaimNames.Aud,"张三"),
                new Claim("Guid", Guid.NewGuid().ToString("D")),
                new Claim(ClaimTypes.Role, m.UserRoles)
            };

            SecurityToken securityToken = new JwtSecurityToken(
                signingCredentials: securityKey,
                expires: DateTime.Now.AddMinutes(2),//过期时间
                claims: claims
                );

            //生成jwt令牌
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            m.Token = token;
            m.UserRoles = data.UserRoles;

            return m;//返回角色信息
        }
        
    }
}
