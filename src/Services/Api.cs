using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace alab.Services {
    class Api {
        private readonly string host;
        private readonly string port;
        private readonly string protocol;
        private readonly HttpClient client;

        public Api(string host, string port, bool isSecure = true) {
            this.client = new HttpClient();
            this.host = host;
            this.port = port;
            this.protocol = isSecure ? "https" : "http";
        }

        public async Task<T> GetData<T>(string path) {
            string basePath = GetBasePath();
            return await client.GetJsonAsync<T>(basePath + path);
        }

        protected string GetBasePath() => $"{protocol}://{host}:{port}";
    }
}
