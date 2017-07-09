using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Entities
{
    public interface IUserContextRepository : IRepository<UserContext>
    {
        UserContext GetUserContextByToken(Guid Token);
        UserContext GetUserContextByUserId(string userId);
    }
}
