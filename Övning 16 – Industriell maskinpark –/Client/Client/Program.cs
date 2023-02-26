//namespace Övning_16___Industriell_maskinpark__.Client.Client
//{
//    public class Program
//{

//}
//}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Övning_16___Industriell_maskinpark__.Client;
using Övning_16___Industriell_maskinpark__.Services;

namespace ToDoBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient<IToDoClient, ToDoClient>();

            await builder.Build().RunAsync();
        }
    }
}