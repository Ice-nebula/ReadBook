using Book.Models;
using Book.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Domain
{
    public interface ITokenService
    {
        string GetToken(UserModel userModel);
    }
}
