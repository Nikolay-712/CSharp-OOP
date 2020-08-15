using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.OnlineRadioDatabase
{
    public class Song : SongGenerator
    {
        private string artistName;
        private string songName;
        private string duration;

        public Song(string artistName, string songName, string duration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Duration = duration;


        }

        public string Duration
        {
            get { return this.duration; }
            set
            {

                if (value == null)
                {
                    throw new ArgumentException("Invalid song length.");
                }

                var minutes = int.Parse(this.CheckDuration(value)[0]);
                var seconds = int.Parse(this.CheckDuration(value)[1]);

                SongGenerator.InvalidSongMinutes(minutes);
                SongGenerator.InvalidSongSeconds(seconds);


                this.duration = value;
            }
        }


        public string SongName
        {
            get { return this.songName; }
            private set
            {
                SongGenerator.InvalidSongName(value);
                this.songName = value;
            }
        }


        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                SongGenerator.InvalidArtistName(value);
                this.artistName = value;
            }
        }

        private string[] CheckDuration(string duratino)
        {
            var timeInfo = duratino.Split(":", StringSplitOptions.RemoveEmptyEntries);

            return timeInfo;
        }

        public static string ShowPlayListInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Songs added: {SongGenerator.PlayListCount()}")
                .AppendLine($"Playlist length: {SongGenerator.CalculatePlayListLenght()}");

            return stringBuilder.ToString();
        }


    }
}
