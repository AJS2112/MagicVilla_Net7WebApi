using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaUrl;

        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServicesUrls:VillaApi");
        }

        public async Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Url = villaUrl + "/api/v1/UsersAuth/login",
                Data = loginRequestDTO
            });
        }

        public async Task<T> RegisterAsync<T>(RegistrationRequestDTO registrationRequestDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Url = villaUrl + "/api/v1/UsersAuth/register",
                Data = registrationRequestDTO
            });
        }
    }
}
