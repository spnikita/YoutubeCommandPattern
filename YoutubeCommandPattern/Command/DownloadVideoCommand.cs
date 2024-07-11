using System;
using System.Threading.Tasks;
using YoutubeCommandPattern.CommandReceiver;

namespace YoutubeCommandPattern.Command
{
    /// <summary>
    /// Команда на загрузку видео
    /// </summary>
    internal class DownloadVideoCommand : AbstractCommand
    {
        /// <summary>
        /// Обработчик команд
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="receiver"><inheritdoc cref="_receiver" path="/summary" /></param>
        public DownloadVideoCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        /// <inheritdoc />
        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override async ValueTask RunAsync(string url)
        {
            await _receiver.DownloadVideoAsync(url);
        }
    }
}
