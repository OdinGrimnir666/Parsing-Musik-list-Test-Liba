using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class ParseMusic
    {
        public PLylist Model { get; set; }

        public string url { get; set; }

        public HtmlDocument htmlDoc { get; set; }



        public ParseMusic(string url)
        {

            Model = new PLylist();
            Model.Music = new List<Music>();
            this.url = url;

            htmlDoc = new HtmlDocument();

            this.htmlDoc.LoadHtml(TextHtml(this.url).Result);


            Initilizator();

        }


        public async Task<string> TextHtml(string url)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        private void Initilizator()
        {
            InitilizatorPlylist();
            InitilizatorPlylistImfo();
        }


        public void InitilizatorPlylistImfo()
        {
            var PLylistname = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='dj-name']//a").InnerText.ToString();

            var AvatarImages = htmlDoc.DocumentNode.SelectNodes("//div[@class='image']//img").ToList()[1].Attributes[0].Value.ToString();


            var Date = htmlDoc.DocumentNode.SelectSingleNode("//h3[@class='show-title']").InnerText.
                ToString().Trim().Replace("Sam T ","").ToString();

            Model.PlaylistName = PLylistname;
            Model.AvatarImages = AvatarImages;
            Model.ReleaseDate = DateTime.Parse(Date);



        }

        public void InitilizatorPlylist()
        {
            var Recordlebel = htmlDoc.DocumentNode.SelectNodes("//span[@class='label']")
                .Select(x => x.InnerText.ToString()).ToList();




            var NameMusic = htmlDoc.DocumentNode.SelectNodes("//span[@class='release']")
                .Select(x => x.InnerText.ToString()).ToList();




            var NameAlbom = htmlDoc.DocumentNode.SelectNodes("//span[@class='song']")
                .Select(x => x.InnerText.ToString()).ToList();


            var name = htmlDoc.DocumentNode.SelectNodes("//span[@class='artist']")
                .Select(x => x.InnerText.ToString()).ToList();

            var Image = htmlDoc.DocumentNode.SelectNodes("//div[@class='spin-art-container']//img")
                .Select(x => x.Attributes[0].Value.ToString()).ToList();



            var tinme = htmlDoc.DocumentNode.SelectNodes("//td[@class='spin-time']")
                .Select(x => x.InnerText.ToString()).ToList();


            for (int i = 0; i < name.Count(); i++)
            {
                Model.Music.Add(new Music()
                {
                    RecordLabel = i<Recordlebel.Count()?Recordlebel[i]:null,
                    NameArtist = name[i],
                    NameAlbom = NameAlbom[i],
                    Img = Image[i],
                    Time = DateTime.Parse(tinme[i]),
                    NameMusic = i < name.Count() ? name[i] : null,

                });
            }
        }
    }
     
}
