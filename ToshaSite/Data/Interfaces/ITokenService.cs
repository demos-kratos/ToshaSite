using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data
{
    public interface ITokenService
    {
        string GetToken();
        DateTime? CheckToken(string token);
    }
}
