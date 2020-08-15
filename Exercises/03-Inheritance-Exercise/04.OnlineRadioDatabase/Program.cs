using System;
using System.Globalization;

namespace _04.OnlineRadioDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {

            int playListLenght = int.Parse(Console.ReadLine());

            for (int song = 0; song < playListLenght; song++)
            {
                try
                {
                    var songInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                    SongGenerator.CheckInputInfo(songInfo);

                    Song song1 = new Song(songInfo[0], songInfo[1], songInfo[2]);
                    Console.WriteLine("Song added.");

                    SongGenerator.AddSong(song1);

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
               
            }
            Console.WriteLine(Song.ShowPlayListInfo());
        }
    }
}
