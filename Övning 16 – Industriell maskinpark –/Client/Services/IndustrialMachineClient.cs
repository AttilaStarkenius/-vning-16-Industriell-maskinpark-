using System.Net.Http.Headers;
using System.Net.Http.Json;
using Övning_16___Industriell_maskinpark__.Client.Services;
using Övning_16___Industriell_maskinpark__.Shared.Entities;

namespace Övning_16___Industriell_maskinpark__.Services
{
    public class IndustrialMachineClient : IIndustrialMachineClient
    {
        private readonly HttpClient httpClient;

        public IndustrialMachineClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            //  this.httpClient.BaseAddress = new Uri("https://localhost:7149");
            //this.httpClient.BaseAddress = new Uri("https://todoblazorapi.azurewebsites.net");

            var baseAddress = configuration.GetSection("BaseAddress").Value;

            ArgumentNullException.ThrowIfNull(baseAddress, nameof(configuration));

            this.httpClient.BaseAddress = new Uri(baseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<IndustrialMachine>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<IndustrialMachine>>("api/todos");
        }

        public async Task<IndustrialMachine?> PostAsync(CreateNewIndustrialMachine createItem)
        {
            var response = await httpClient.PostAsJsonAsync("api/todos", createItem);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<IndustrialMachine>() : null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return (await httpClient.DeleteAsync($"api/todos/{id}")).IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(IndustrialMachine item)
        {
            return (await httpClient.PutAsJsonAsync($"api/todos/{item.Id}", item)).IsSuccessStatusCode;
        }
    }
}
