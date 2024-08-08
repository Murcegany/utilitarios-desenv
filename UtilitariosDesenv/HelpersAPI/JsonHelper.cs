using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UtilitariosDesenv
{
    public class JsonHelper
    {
        private readonly JsonSerializerOptions _options;

        public JsonHelper()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public JsonHelper(JsonSerializerOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Serializa um objeto para uma string JSON.
        /// </summary>
        /// <typeparam name="T">O tipo do objeto a ser serializado.</typeparam>
        /// <param name="obj">O objeto a ser serializado.</param>
        /// <returns>Uma string JSON representando o objeto.</returns>
        public string Serialize<T>(T obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj, _options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao serializar objeto para JSON", ex);
            }
        }

        /// <summary>
        /// Desserializa uma string JSON para um objeto do tipo especificado.
        /// </summary>
        /// <typeparam name="T">O tipo do objeto a ser desserializado.</typeparam>
        /// <param name="json">A string JSON a ser desserializada.</param>
        /// <returns>O objeto desserializado.</returns>
        public T Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, _options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao desserializar JSON para objeto", ex);
            }
        }

        /// <summary>
        /// Converte um objeto anônimo em uma string JSON.
        /// </summary>
        /// <param name="obj">O objeto anônimo a ser convertido.</param>
        /// <returns>Uma string JSON representando o objeto anônimo.</returns>
        public string SerializeAnonymous(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj, obj.GetType(), _options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao serializar objeto anônimo para JSON", ex);
            }
        }

        /// <summary>
        /// Formata uma string JSON para torná-la mais legível.
        /// </summary>
        /// <param name="json">A string JSON a ser formatada.</param>
        /// <returns>Uma string JSON formatada com indentação.</returns>
        public string FormatJson(string json)
        {
            try
            {
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                return JsonSerializer.Serialize(jsonElement, _options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao formatar JSON", ex);
            }
        }
    }
}
