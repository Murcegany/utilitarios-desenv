using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UtilitariosDesenv
{
    public class HttpHelper
    {
        private readonly HttpClient _httpClient;

        public HttpHelper(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Envia uma requisição GET para a URL especificada e retorna a resposta como string.
        /// </summary>
        /// <param name="url">A URL para onde enviar a requisição GET.</param>
        /// <returns>O conteúdo da resposta como string.</returns>
        public async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao fazer requisição GET para {url}", ex);
            }
        }

        /// <summary>
        /// Envia uma requisição POST para a URL especificada com um conteúdo JSON e retorna a resposta como string.
        /// </summary>
        /// <param name="url">A URL para onde enviar a requisição POST.</param>
        /// <param name="jsonContent">O conteúdo JSON para enviar no corpo da requisição.</param>
        /// <returns>O conteúdo da resposta como string.</returns>
        public async Task<string> PostAsync(string url, string jsonContent)
        {
            try
            {
                HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao fazer requisição POST para {url}", ex);
            }
        }

        /// <summary>
        /// Envia uma requisição PUT para a URL especificada com um conteúdo JSON e retorna a resposta como string.
        /// </summary>
        /// <param name="url">A URL para onde enviar a requisição PUT.</param>
        /// <param name="jsonContent">O conteúdo JSON para enviar no corpo da requisição.</param>
        /// <returns>O conteúdo da resposta como string.</returns>
        public async Task<string> PutAsync(string url, string jsonContent)
        {
            try
            {
                HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao fazer requisição PUT para {url}", ex);
            }
        }

        /// <summary>
        /// Envia uma requisição DELETE para a URL especificada e retorna a resposta como string.
        /// </summary>
        /// <param name="url">A URL para onde enviar a requisição DELETE.</param>
        /// <returns>O conteúdo da resposta como string.</returns>
        public async Task<string> DeleteAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao fazer requisição DELETE para {url}", ex);
            }
        }

        /// <summary>
        /// Define um cabeçalho de autenticação Bearer para o cliente HTTP.
        /// </summary>
        /// <param name="token">O token de autenticação Bearer.</param>
        public void SetBearerToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Remove todos os cabeçalhos de autenticação definidos.
        /// </summary>
        public void ClearAuthorizationHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
