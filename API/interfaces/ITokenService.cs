using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);         
    }
}