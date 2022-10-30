using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Unit18_4_1
{
    class Receiver
    {
        private YoutubeClient _client;

        public Receiver()
        {
            _client = new YoutubeClient();
        }

        public async void GetInfo(string url)
        {
            try
            {
                Console.Write("Загрузка...");
                Console.SetCursorPosition(0, Console.CursorTop);

                var video = await _client.Videos.GetAsync(url);

                Console.WriteLine($"Название видео: {video.Title}");
                Console.WriteLine($"Название канала: {video.Author.ChannelTitle}");
                Console.WriteLine($"Продолжительность: {video.Duration}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<StreamManifest> GetVideoManifests(string url)
        {
            var streamManifest = await _client.Videos.Streams.GetManifestAsync(url);
            return streamManifest;
        }

        public async void DownloadVideo(string path, IStreamInfo manifest)
        {
            var progress = new Progress<double>();
         
            var fileName = string.IsNullOrEmpty(path) ? "noname" : path;

            if (Path.GetExtension(fileName) != $".{manifest.Container.Name}")
                fileName += $".{manifest.Container.Name}";

            try
            {
                Console.WriteLine("Загрузка...");
                await _client.Videos.Streams.DownloadAsync(manifest, fileName, progress);
                Console.WriteLine($"\nФайл \"{fileName}\" успешно сохранен.");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}