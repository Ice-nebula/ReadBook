using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserModel user);
    }
}
