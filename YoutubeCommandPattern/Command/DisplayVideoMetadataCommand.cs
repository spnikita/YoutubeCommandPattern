using System;
using System.Threading.Tasks;
using YoutubeCommandPattern.CommandReceiver;

namespace YoutubeCommandPattern.Command
{
    /// <summary>
    /// Команда на отображение информации о видео
    /// </summary>
    internal class DisplayVideoMetadataCommand : AbstractCommand
    {
        /// <summary>
        /// Обработчик команд
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="receiver"><inheritdoc cref="_receiver" path="/summary" /></param>
        public DisplayVideoMetadataCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        /// <inheritdoc />
        public override void Cancel()
        {
            Console.WriteLine("Отмена выполнения команды");
        }

        /// <inheritdoc />
        public override async ValueTask RunAsync(string url)
        {
            await _receiver.DownloadDescriptionAsync(url);
        }
    }
}
