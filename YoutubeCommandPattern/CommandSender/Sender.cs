using System.Threading.Tasks;
using YoutubeCommandPattern.Command;

namespace YoutubeCommandPattern.CommandSender
{
    /// <summary>
    /// Отправитель команд
    /// </summary>
    internal class Sender
    {
        /// <summary>
        /// Команда
        /// </summary>
        private AbstractCommand Command { get; set; }

        /// <summary>
        /// Установить команду
        /// </summary>
        /// <param name="command"><inheritdoc cref="Command" path="/summary"/></param>
        public void SetCommand(AbstractCommand command)
        {
            Command = command;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async ValueTask RunAsync(string url)
        {
            if (Command != null)
                await Command.RunAsync(url);
            else
                await Task.CompletedTask;
        }

        /// <summary>
        /// Отменить команду
        /// </summary>
        public void Cancel()
        {
            Command?.Cancel();
        }
    }
}
