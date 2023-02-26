using System.Collections.Generic;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Övning_16___Industriell_maskinpark__.Client;
using Övning_16___Industriell_maskinpark__.Shared.Entities;
using AzureFunctionsApplication.Entities;
using AzureFunctionsApplication.Extensions;
using AzureFunctionsApplication.Helpers;
using AzureFunctionsApplication;

namespace AzureFunctionsApplication
{
    //Nuget so far!
    //Microsoft.Azure.Functions.Worker.Extensions.Tables - Isolated!
    //Azure.Data.Tables

    public class ToDoFuncApi
    {
        private readonly ILogger _logger;

        public ToDoFuncApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ToDoFuncApi>();
        }

        [Function("Get Items")]
        public async Task<HttpResponseData> Get(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos")] HttpRequestData req,
           [TableInput(TableNames.TableName, TableNames.PartionKey, Connection = "AzureWebJobsStorage")] IEnumerable<ItemTableEntity> tableEntities)
        {
            _logger.LogInformation("Get all items started!");

            var response = req.CreateResponse();
            var items = tableEntities.Select(Mapper.ToItem);
            await response.WriteAsJsonAsync(items);
            return response;

        }

        [Function("Add Item")]
        public async Task<HttpResponseData> Create(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequestData req)
        // [TableInput("Items", "Todos", Connection = "AzureWebJobsStorage")] TableClient tableClient)
        {
            _logger.LogInformation("Create new todo item");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            //var stream = await new StreamReader(req.Body).ReadToEndAsync();
            var createdItem = JsonSerializer.Deserialize<CreateItem>(req.Body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if (createdItem is null || string.IsNullOrWhiteSpace(createdItem.Text))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var item = new Item
            {
                Text = createdItem.Text
            };

            //ToDo try to remove later!!!
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(item.ToTableEntity());

            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteAsJsonAsync(item);
            response.StatusCode = HttpStatusCode.Created;

            return response;
        }


        [Function("Delete Item")]
        public async Task<HttpResponseData> Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "todos/{id}")] HttpRequestData req,
              // [TableInput(TableNames.TableName, TableNames.PartionKey, "{id}", Connection = "AzureWebJobsStorage")] IEnumerable<ItemTableEntity> tableEntity,
              [FromRoute] string id)
        {
            _logger.LogInformation("Delete item");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            //if(createdItem is null || string.IsNullOrWhiteSpace(createdItem.Text))
            //{
            //    response.StatusCode = HttpStatusCode.BadRequest;
            //    return response;
            //}

            var isOk = await tableClient.DeleteEntityAsync(TableNames.PartionKey, id);

            if (isOk.Status == StatusCodes.Status404NotFound)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }


        private TableClient GetTableClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            return new TableClient(connectionString, TableNames.TableName);
        }
    }
}






//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;

//namespace AzureFunctionsApplication
//{
//    public static class Function1
//    {
//        [FunctionName("Function1")]
//        public static async Task<IActionResult> Run(
//            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
//            ILogger log)
//        {
//            log.LogInformation("C# HTTP trigger function processed a request.");

//            string name = req.Query["name"];

//            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//            dynamic data = JsonConvert.DeserializeObject(requestBody);
//            name = name ?? data?.name;

//            string responseMessage = string.IsNullOrEmpty(name)
//                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
//                : $"Hello, {name}. This HTTP triggered function executed successfully.";

//            return new OkObjectResult(responseMessage);
//        }
//    }
//}
