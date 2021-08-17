using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.IDAL
{
    public interface IRole
    {
        string GetRoles(string id, string sql);//获取用户所对应的角色
    }
}
