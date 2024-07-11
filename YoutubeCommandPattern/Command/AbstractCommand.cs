using System.Threading.Tasks;

namespace YoutubeCommandPattern.Command
{
    /// <summary>
    /// Абстрактный класс 'команда'
    /// </summary>
    internal abstract class AbstractCommand
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="url">URL видео</param>
        public abstract ValueTask RunAsync(string url);

        /// <summary>
        /// Отменить команду
        /// </summary>
        public abstract void Cancel();
    }
}
