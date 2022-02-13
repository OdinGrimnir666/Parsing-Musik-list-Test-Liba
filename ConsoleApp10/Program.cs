
using ConsoleApp10;


    var ParseMusic = new ParseMusic("https://spinitron.com/KXLU/pl/15248856/Sam-T-02-03-2022");


Console.WriteLine(ParseMusic.Model.PlaylistName);

Console.WriteLine(ParseMusic.Model.ReleaseDate.ToString("MMM/dd/yyyy"));

Console.WriteLine(ParseMusic.Model.AvatarImages);

foreach (var item in ParseMusic.Model.Music)
{
    Console.WriteLine(item.Time.ToString("mm:ss"));
}


Console.WriteLine(ParseMusic);

Console.ReadKey();