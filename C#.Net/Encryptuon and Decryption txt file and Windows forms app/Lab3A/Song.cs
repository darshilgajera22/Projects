using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Song class to set movie data and encrypt and decrypt summary
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
    namespace Lab3A
{

    /// <summary>
    /// Song Class
    /// </summary>
    internal class Song : Media
    {
        public string artist { get; private set; } // the artist of song
        public string album { get; private set; } // the album of song

        /// <summary>
        /// Song Constructor
        /// </summary>
        /// <param name="title">Song Title</param>
        /// <param name="year">Song Year</param>
        /// <param name="artist">Song Artist</param>
        /// <param name="album">Song Album</param>
        public Song(string title, int year, string artist, string album) : base(title, year)
        {
            this.artist = artist;
            this.album = album;
        }

        /// <summary>
        /// To Display movie data
        /// </summary>
        /// <returns>A string that contains movie data</returns>
        public override string ToString()
        {
            return "Song: " + base.ToString() + "\n" + "Album: " + album + "\n" + "Artist: " + artist;
        }
    }
}
