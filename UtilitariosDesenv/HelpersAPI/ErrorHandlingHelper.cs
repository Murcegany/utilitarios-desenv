namespace UtilitariosDesenv
{
    public class ErrorHandlingHelper
    {
        /// <summary>
        /// Formata uma exceção para uma mensagem de erro detalhada.
        /// </summary>
        /// <param name="ex">A exceção a ser formatada.</param>
        /// <returns>Uma string contendo informações detalhadas sobre a exceção.</returns>
        public static string FormatExceptionMessage(Exception ex)
        {
            return $"Erro: {ex.Message}\nStack Trace: {ex.StackTrace}";
        }

        /// <summary>
        /// Registra a exceção em um arquivo de log.
        /// </summary>
        /// <param name="ex">A exceção a ser registrada.</param>
        /// <param name="filePath">O caminho do arquivo de log.</param>
        public static void LogException(Exception ex, string filePath)
        {
            string message = FormatExceptionMessage(ex);
            System.IO.File.AppendAllText(filePath, $"{DateTime.Now}: {message}\n\n");
        }

        /// <summary>
        /// Trata exceções de forma segura, executando uma ação e capturando qualquer exceção lançada.
        /// </summary>
        /// <param name="action">A ação a ser executada.</param>
        /// <param name="onError">Uma ação opcional a ser executada em caso de erro, passando a exceção como parâmetro.</param>
        public static void HandleSafe(Action action, Action<Exception> onError = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
        }
    }
}
