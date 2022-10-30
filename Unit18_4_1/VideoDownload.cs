using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

namespace Unit18_4_1
{
    class VideoDownload : Command
    {
        private string _url;
        private string _fileName;
        private Receiver _reciever;
        public VideoDownload(Receiver reciever, string url, string fileName)
        {
            _reciever = reciever;
            _url = url;
            _fileName = fileName;
        }
        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            try
            {
               
                var manifest = _reciever.GetVideoManifests(_url).Result;
                if (manifest == null) return;


                var streamInfo = (MuxedStreamInfo)manifest.GetMuxedStreams();


                _reciever.DownloadVideo(_fileName, streamInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
