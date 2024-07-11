using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeCommandPattern.CommandReceiver
{
    /// <summary>
    /// Получатель команд
    /// </summary>
    internal class Receiver
    {
        /// <summary>
        /// Youtube-клиент
        /// </summary>
        private static readonly YoutubeClient Client = new YoutubeClient();

        /// <summary>
        /// Вывести метаданные видео
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async ValueTask DownloadDescriptionAsync(string url)
        {
            try
            {
                var metadata = await Client.Videos.GetAsync(url);

                Console.WriteLine();
                Console.WriteLine("Информация о видео:");
                Console.WriteLine($"→ Id: {metadata.Id};");
                Console.WriteLine($"→ Author: {metadata.Author};");
                Console.WriteLine($"→ Title: {metadata.Title};");
                Console.WriteLine($"→ Description: {metadata.Description};");
                Console.WriteLine($"→ Duration: {metadata.Duration};");
                Console.WriteLine($"→ Engagement: {metadata.Engagement};");
                Console.WriteLine($"→ Thumbnails: {metadata.Thumbnails};");
                Console.WriteLine($"→ UploadDate: {metadata.UploadDate}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вывода информации о видео: {ex.Message}");
            }
        }


        /// <summary>
        /// Загрузить видео
        /// </summary>
        /// <param name="url">URL видео</param>
        /// <returns></returns>
        public async ValueTask DownloadVideoAsync(string url)
        {
            try
            {
                Console.WriteLine("Выполняется загрузка видео...");

                var streamManifest = await Client.Videos.Streams.GetManifestAsync(url);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                var filePath = $"video.{streamInfo.Container}";

                await Client.Videos.Streams.DownloadAsync(streamInfo, filePath);

                Console.WriteLine("Pагрузка видео завершена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки видео: {ex.Message}");
            }
        }
    }
}
