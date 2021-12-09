using Rajanell.ClientAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rajanell.ClientAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthToken> GetAccessToken(string clientId, string clientSecret);
    }
}
