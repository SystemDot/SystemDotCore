using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SystemDot.Http
{
    public class PutSender
    {
        public static async void Send(
            Action<Stream> toPerformOnRequest,
            Action<Stream> toPerformOnResponse,
            Action<Exception> toPerformOnError,
            Action toPerformOnCompletion,
            string url)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await SendRequest(toPerformOnRequest, url);
                await ProcessResponse(toPerformOnResponse, httpResponseMessage);
            }
            catch (Exception e)
            {
                toPerformOnError(e);
                return;
            }

            toPerformOnCompletion();
        }

        static async Task<HttpResponseMessage> SendRequest(Action<Stream> toPerformOnRequest, string url)
        {
            var stream = new MemoryStream();
            toPerformOnRequest(stream);
            stream.Position = 0;

            HttpResponseMessage response = await new HttpClient()
                .SendAsync(
                    new HttpRequestMessage(HttpMethod.Put, url)
                    {
                        Content = new StreamContent(stream)
                    });

            stream.Dispose();

            return response;
        }

        static async Task ProcessResponse(Action<Stream> toPerformOnResponse, HttpResponseMessage response)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            responseStream.Position = 0;
            toPerformOnResponse(responseStream);

            responseStream.Dispose();
        }
    }
}