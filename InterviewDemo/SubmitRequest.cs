using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace InterviewDemo
{
    public static class SubmitRequest
    {
        [FunctionName("SubmitRequest")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("Processing",Connection = "ServiceBusConnection" , EntityType = ServiceBusEntityType.Queue)] IAsyncCollector<QueueMessage> serviceBusCollector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            QueueMessage data = JsonConvert.DeserializeObject<QueueMessage>(requestBody);

            await serviceBusCollector.AddAsync(data);

            String ordernumber = data.Order.Id;

            string responseMessage = string.IsNullOrEmpty(ordernumber)
                ? "This HTTP triggered function executed successfully"
                : $"Order, {ordernumber}. added to the processing queue successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
