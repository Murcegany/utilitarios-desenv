using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UtilitariosDesenv
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;

        public ApiHelper(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Envia uma requisição GET para a API e retorna a resposta como uma string.
        /// </summary>
        /// <param name="url">A URL da API para onde enviar a requisição GET.</param>
        /// <returns>A resposta da API como uma string.</returns>
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
                // Aqui você pode adicionar logging ou manipulação de erros
                throw new ApplicationException($"Erro ao fazer requisição GET para {url}", ex);
            }
        }

        /// <summary>
        /// Envia uma requisição POST para a API com um corpo JSON e retorna a resposta como uma string.
        /// </summary>
        /// <param name="url">A URL da API para onde enviar a requisição POST.</param>
        /// <param name="jsonContent">O conteúdo JSON para enviar no corpo da requisição.</param>
        /// <returns>A resposta da API como uma string.</returns>
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
                // Aqui você pode adicionar logging ou manipulação de erros
                throw new ApplicationException($"Erro ao fazer requisição POST para {url}", ex);
            }
        }

        /// <summary>
        /// Adiciona um cabeçalho de autenticação Bearer ao HttpClient.
        /// </summary>
        /// <param name="token">O token de autenticação Bearer.</param>
        public void SetBearerToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
