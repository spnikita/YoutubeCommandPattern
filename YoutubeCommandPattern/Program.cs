using System;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using YoutubeCommandPattern.CommandReceiver;
using YoutubeCommandPattern.Command;
using YoutubeCommandPattern.CommandSender;

namespace YoutubeCommandPattern
{
    class Program
    {
        /// <summary>
        /// Обработчик команд
        /// </summary>
        private static readonly Receiver Receiver = new Receiver();

        /// <summary>
        /// Отправитель команд
        /// </summary>
        private static readonly Sender Sender = new Sender();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите ссылку на youtube-видео: ");

                var youtubeUrl = Console.ReadLine();

                if (string.IsNullOrEmpty(youtubeUrl))
                {
                    Console.WriteLine("Введена пустая строка. Повторите попытку.");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine();
                Console.WriteLine("Возможные действия:");
                Console.WriteLine("1 - вывести информацию о видео;");
                Console.WriteLine("2 - скачать видео;");
                Console.WriteLine("'x' - выйти из меню выбора.");

                await ProcessVideoAsync(youtubeUrl);

                Console.Write("Для выхода из программы нажмите 'x', для продолжения нажмите любую клавишу: ");
                var character = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (character.Equals('x'))
                    break;
            }
        }

        /// <summary>
        /// Обработать URL видео
        /// </summary>
        /// <param name="url">URL видео</param>
        private static async ValueTask ProcessVideoAsync(string url)
        {
            while (true)
            {
                Console.WriteLine();

                Console.Write("Выберите действие: ");
                var character = Console.ReadKey().KeyChar;

                Console.WriteLine();

                if (character.Equals('x'))
                    break;

                AbstractCommand command;
                switch (character)
                {
                    case '1':
                        command = new DisplayVideoMetadataCommand(Receiver);
                        Sender.SetCommand(command);
                        await Sender.RunAsync(url);
                        break;
                    case '2':
                        command = new DownloadVideoCommand(Receiver);
                        Sender.SetCommand(command);
                        await Sender.RunAsync(url);
                        break;
                    default:
                        Console.WriteLine("Введен недопустимый символ.");
                        break;
                }
            }
        }
    }
}
