using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace SerializedClient
{

    public class SerializedClientCredentials : ServiceClientCredentials
    {
        private readonly string accessKey;
        private readonly string secretAccessKey;

        public SerializedClientCredentials(string accessKey, string secretAccessKey)
        {
            this.accessKey = accessKey;
            this.secretAccessKey = secretAccessKey;
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException("request");

            request.Headers.Add("Serialized-Access-Key", accessKey);
            request.Headers.Add("Serialized-Secret-Access-Key", secretAccessKey);

            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }

    }

}