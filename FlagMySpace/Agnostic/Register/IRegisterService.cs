using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Register
{
    public interface IRegisterService
    {
        Task<ResultModel> RegisterAsync(string username, string password, string email);
    }
}
