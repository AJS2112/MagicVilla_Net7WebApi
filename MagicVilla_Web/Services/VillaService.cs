using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaUrl;

        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration):base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServicesUrls:VillaApi");
        }

        public async Task<T> CreateAsync<T>(VillaCreateDTO villaCreateDTO, string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Url = villaUrl + "/api/villaApi",
                Data = villaCreateDTO,
                Token = token
            });
        }

        public async Task<T> DeleteAsync<T>(int id, string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.DELETE,
                Url = villaUrl + "/api/villaApi/" + id,
                Token = token
            });
        }

        public async Task<T> GetAllAsync<T>(string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.GET,
                Url = villaUrl + "/api/villaApi",
                Token = token
            });
        }

        public async Task<T> GetAsync<T>(int id, string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.GET,
                Url = villaUrl + "/api/villaApi/" + id,
                Token = token
            });
        }

        public async Task<T> UpdateAsync<T>(VillaUpdateDTO villaUpdateDTO, string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.PUT,
                Url = villaUrl + "/api/villaApi/" + villaUpdateDTO.Id,
                Data = villaUpdateDTO,
                Token = token
            });
        }
    }
}
