using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Book class to set book data and encrypt and decrypt summary
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab3A
{
    /// <summary>
    /// Book Class
    /// </summary>
    internal class Book : Media, IEncryptable
    {
        public string author { get; private set; } // Book Author
        public string summary { get; private set; } // Book Summary


        /// <summary>
        /// Constructor Book
        /// </summary>
        /// <param name="title">Book Title</param>
        /// <param name="year">Book Year</param>
        /// <param name="author">Book Author</param>
        /// <param name="summary">Book Summary</param>
        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            this.author = author;
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
        /// To Display Book data
        /// </summary>
        /// <returns>A string that contains book data</returns>
        public override string ToString()
        {
            return "BOOK: \n" + base.ToString() + "\n" + "Author: " + author + "\n" + "Summary: " + Decrypt();
        }
    }
}
