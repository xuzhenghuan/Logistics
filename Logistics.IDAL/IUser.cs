using System;
using System.Collections.Generic;
using Logistics.MODEL;

namespace Logistics.IDAL
{
    public interface IUser
    {
        string Login(UserModel m,string sql);//登录
    }
}
