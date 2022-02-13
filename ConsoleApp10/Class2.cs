using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class PLylist
    {
        public string PlaylistName { get; set; }

        public string AvatarImages { get; set; }

        //"MMM/dd/yyyy"
        public DateTime ReleaseDate { get; set; }

        //жанр
        public List<Music> Music { get; set; }


    }
    public class Music
    {

        public string? RecordLabel { get; set; }

        public string? NameMusic { get; set; }

        public string? NameArtist { get; set; }

        public string? NameAlbom { get; set; }

        public DateTime Time { get; set; }

        public string? Img { get; set; }





    }

}
