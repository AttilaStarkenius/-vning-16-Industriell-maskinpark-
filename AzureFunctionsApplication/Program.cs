//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AzureFunctionsApplication
//{
//    public class Program
//    {

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzureFunctionsApplication
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        //app =>
        //{
        //    //app.UseMiddleware<>
        //})
        .ConfigureServices(services =>
        {
            // services.AddScoped<>();
        })
        .Build();

            host.Run();
        }
            }
}
