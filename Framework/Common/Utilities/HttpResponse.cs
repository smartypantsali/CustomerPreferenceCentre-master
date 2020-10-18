using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utilities
{
    public class HttpResponse : ActionResult
    {
        public byte[] Content { get; set; }       
        public int StatusCode { get; set; }

        public HttpResponse()
        {
        }

        public static HttpResponse GetResultFromHttpResponses(HttpResponse[] httpResponses)
        {
            var res = new HttpResponse();

            var obj = new Dictionary<string, object>();

            for (int i = 0; i < httpResponses.Length; i++)
            {
                var httpResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(UTF8Encoding.UTF8.GetString(httpResponses[i].Content));

                obj[$"{httpResponse.ElementAt(0).Key} + {i}"] = httpResponse.ElementAt(0).Value;
            }

            res.Content = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            res.StatusCode = 418;

            return res;
        }

        public static HttpResponse TeapotResult(ApiOffence offense, string propertName)
        {
            var res = new HttpResponse();
            res.Content = getContent(offense, propertName);
            res.StatusCode = 418;
            return res;
        }

        private static byte[] getContent(ApiOffence offense, string propertName)
        {
            var obj = new Dictionary<string, object>()
            {
                [propertName] = new { ErrorCode = offense.ErrorCode }
            };

            return UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            return ExecuteResultAsync(context.HttpContext);
        }
        public Task ExecuteResultAsync(HttpContext context)
        {
            var resp = context.Response;
            resp.StatusCode = StatusCode;

            if (Content != null)
            {
                resp.ContentType = "application/json";
                return resp.Body.WriteAsync(Content, 0, Content.Length);
            }

            return Task.CompletedTask;
        }
    }
}
