using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _04.OnlineRadioDatabase
{
    public class SongGenerator
    {
        private static List<Song> PlayList = new List<Song>();

        protected static void InvalidSongName(string songName)
        {
            if (songName.Length < 3 || songName.Length > 30 || string.IsNullOrEmpty(songName))
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");

            }
        }

        protected static void InvalidArtistName(string artistName)
        {
            if (artistName.Length < 3 || artistName.Length > 20 || string.IsNullOrEmpty(artistName))
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
        }

        protected static void InvalidSongMinutes(int minutes)
        {

            if (minutes < 0 || minutes > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }


        }

        protected static void InvalidSongSeconds(int seconds)
        {
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
        }

        public static string CalculatePlayListLenght()
        {
            double totalSeconds = 0;

            foreach (var song in PlayList)
            {
                var durationInfo = song.Duration.Split(":").Select(int.Parse).ToArray();

                totalSeconds = totalSeconds + durationInfo[0] * 60;
                totalSeconds = totalSeconds + durationInfo[1];
            }


            TimeSpan t = TimeSpan.FromSeconds(totalSeconds);
            return $"{t.Hours}h {t.Minutes}m {t.Seconds}s";
        }

        public static void CheckInputInfo(string[] info)
        {
            if (string.IsNullOrEmpty(info[1]) || string.IsNullOrWhiteSpace(info[1]))
            {
                throw new ArgumentException("Invalid song.");
            }


            int minutes;
            int seconds;

            var validTime = info[2].Split(":");
            
            if (string.IsNullOrEmpty(info[2]) 
                || string.IsNullOrWhiteSpace(info[2]) 
                || !int.TryParse((validTime[0]), out minutes) 
                || !int.TryParse((validTime[1]), out seconds))
            {
                throw new ArgumentException("Invalid song length.");
            }
        }

        public static void AddSong(Song song)
        {
            PlayList.Add(song);
        }

        public static int PlayListCount()
        {
            return PlayList.Count();
        }




    }
}
