using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Rajanell.ClientAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rajanell.ClientAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly AppSettings _appSettings;

        public IdentityService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public async Task<AuthToken> GetAccessToken(string clientId, string clientSecret)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(_appSettings.IdentityProviderUrl);
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = _appSettings.Scope
            });

            var results = JsonSerializer.Deserialize<AuthToken>(tokenResponse.Json.ToString(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return results;
        }
    }
}
