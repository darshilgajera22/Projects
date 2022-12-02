using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Movie class to set movie data and encrypt and decrypt summary
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab3A
{
    /// <summary>
    /// Movie Class
    /// </summary>
    internal class Movie : Media, IEncryptable
    {
        public string director { get; private set; } // Director of the Movie object
        public string summary { get; private set; }  // Summary of movie object

        /// <summary>
        /// Movie Constructor
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <param name="year">Movie Year</param>
        /// <param name="director">Movie Director</param>
        /// <param name="summary">Movie Summary</param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            this.director = director;
            this.summary = summary;
        }

        /// <summary>
        /// To decrypt Summary
        /// </summary>
        /// <returns>A String that contains the summary </returns>
        /// refence: https://www.daniweb.com/programming/software-development/threads/264050/c-rot13-encrypt-decryp
        public string Decrypt()
        {
            char[] summaryDecrypt = summary.ToCharArray();
            for (int i = 0; i < summaryDecrypt.Length; i++)
            {
                int number = (int)summaryDecrypt[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                summaryDecrypt[i] = (char)number;
            }
            return new string(summaryDecrypt);
        }

        /// <summary>
        /// To encrypt Summary
        /// </summary>
        /// <returns>A String that contains the summary </returns>
        /// refence: https://www.daniweb.com/programming/software-development/threads/264050/c-rot13-encrypt-decryp
        public string Encrypt()
        {
            char[] summaryEncrypt = summary.ToCharArray();
            for (int i = 0; i < summaryEncrypt.Length; i++)
            {
                int number = (int)summaryEncrypt[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                summaryEncrypt[i] = (char)number;
            }
            return new string(summaryEncrypt);
        }

        /// <summary>
        /// To Display Movie data
        /// </summary>
        /// <returns>A string that contains Movie data</returns>
        public override string ToString()
        {
            return "Movie: " + base.ToString() + "\n" + "Director: " + director + "\n" + "Summary: " + Decrypt();
        }
    }
}
