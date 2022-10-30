using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Unit18_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            var receiver = new Receiver();
            string url;
            string fileName;

            Console.WriteLine("Введите сслыку на Youtube-видео");
            url = Console.ReadLine();
            Console.WriteLine("Введите название для сохраненного видео");
            fileName = Console.ReadLine();

            sender.AddCommand(new VideoInfo(receiver, url));
            sender.AddCommand(new VideoDownload(receiver, url, fileName));
            sender.Run();
            Console.ReadKey();
        }
    }
}