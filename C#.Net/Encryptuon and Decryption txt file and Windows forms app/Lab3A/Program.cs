using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    read file and display output as per user's action.
///             User can select list all books, list all movies, list all songs, list all media and serch media with title.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
/// 
namespace Lab3A
{
    /// <summary>
    /// Main file
    /// </summary>
    internal class Program
    {
        private static int mediaArrayIndex; // index for media array
        private static Media[] mediaCollection = new Media[100]; // to  store media
        private static string[] singleData; // to store fetch data of file
        private static string mediaSummary; // to store summary of movie and book
        const string DATAFILE = "Data.txt"; // data file

        static void Main(string[] args)
        { 
            bool flag = true; // to continue loop
            
            do
            {
                try
                {
                    //Options Menu
                    Console.WriteLine("\n\n---------------------------Media Collection-----------------------");
                    Console.WriteLine("-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x-xx-x\n\n");
                    Console.WriteLine("\t\t1. List All Books");
                    Console.WriteLine("\t\t2. List All Movies");
                    Console.WriteLine("\t\t3. List All songs");
                    Console.WriteLine("\t\t4. List all Media");
                    Console.WriteLine("\t\t5. Search All Media with title");
                    Console.WriteLine("\n\t\t6. Exit Program");

                    Console.WriteLine("\n\nEnter your choice: ");
                    int choice = int.Parse(Console.ReadLine()); // user selected option


                    switch (choice)
                    {
                        // to list all books
                        case 1:
                            Console.WriteLine("List of books: ");
                            fileRead("BOOK"); //calling reading method                                                
                            break;
                        // to list all movies
                        case 2:
                            Console.WriteLine("List of Movies: ");
                            fileRead("MOVIE"); //calling reading method                            
                            break;
                        // to list all songs
                        case 3:
                            Console.WriteLine("List of Songs: ");
                            fileRead("SONG"); //calling reading method                           
                            break;
                        // to list all media
                        case 4:
                            Console.WriteLine("List of Media: ");
                            fileRead("ALLMEDIA"); //calling reading method
                            break;
                        // to search media as per title 
                        case 5:
                            Console.Write("Enter a search String: ");
                            string title = Console.ReadLine(); // user input as title
                            Console.WriteLine("List of media: ");
                            
                            fileRead("SEARCHTITLE"); //calling reading method
                            for (int i = 0; i < mediaArrayIndex; i++)
                            {
                                // if user input and media object match
                                if (mediaCollection[i].Search(title))
                                {
                                    Console.WriteLine(mediaCollection[i]); // display media
                                }
                            }
                            break;
                        case 6:
                            Environment.Exit(0);// close the application
                            break;
                        default:
                            Console.WriteLine("xxxxxxx Please enter valid input xxxxxxx");
                            break;
                    }

                }
                //Errors handling through Exceptions
                catch (FormatException)
                {
                    Console.WriteLine("xxxxxxx Please Enter Only Numbers xxxxxxx");
                }
            } while (flag);

            /// <summary>
            /// To display output 
            /// </summary>
            /// <param name="option">User selected media</param>
            void display(string option)
            {
                // display if option is book
                if (option.Equals("BOOK"))
                {
                    Console.WriteLine(singleData[0]);
                    Console.WriteLine("Name:\t" + singleData[1]);
                    Console.WriteLine("Year:\t" + singleData[2]);
                    Console.WriteLine("Author:\t" + singleData[3] + "\n\n");
                }
                // display if option is movie
                else if (option.Equals("MOVIE"))
                {
                    Console.WriteLine(singleData[0]);
                    Console.WriteLine("Name:\t" + singleData[1]);
                    Console.WriteLine("Year:\t" + singleData[2]);
                    Console.WriteLine("Director:\t" + singleData[3] + "\n\n");
                }
                // display if option is song
                else if (option.Equals("SONG"))
                {
                    Console.WriteLine(singleData[0]);
                    Console.WriteLine("Album:\t" + singleData[1]);
                    Console.WriteLine("Year:\t" + singleData[2]);
                    Console.WriteLine("Artist:\t" + singleData[3] + "\n\n");
                }
                
            }

            /// <summary>
            /// To read file 
            /// </summary>
            /// <param name="option">User selected media</param>
            void fileRead(string option)
            {
                try
                {
                    mediaArrayIndex = 0; // to store media on index
                    StreamReader streamReader = new StreamReader(DATAFILE); // StreamReader to read the file
                    while (!streamReader.EndOfStream) // reading untile the end of file
                    {
                        // to store one part of data
                        singleData = streamReader.ReadLine().Split('|');

                        if (option.Equals("ALLMEDIA") || option.Equals("SEARCHTITLE"))
                        {
                            if (singleData[0] == "BOOK")
                            {
                                //reading data file
                                mediaSummary = streamReader.ReadLine();
                                // line separation using -----
                                while (streamReader.ReadLine() != "-----")
                                {
                                    // to store summary
                                    mediaSummary += streamReader.ReadLine();
                                }
                                // adding book in to media collection
                                mediaCollection[mediaArrayIndex] = new Book(singleData[1], int.Parse(singleData[2]), singleData[3], mediaSummary);
                                mediaArrayIndex++;
                                if (option.Equals("ALLMEDIA"))
                                {
                                    Console.WriteLine(singleData[0]);
                                    Console.WriteLine("Name:\t" + singleData[1]);
                                    Console.WriteLine("Year:\t" + singleData[2]);
                                    Console.WriteLine("Author:\t" + singleData[3] + "\n\n");
                                }
                            }
                            else if (singleData[0] == "MOVIE")
                            {
                                //reading data file
                                mediaSummary = streamReader.ReadLine();
                                // line separation using -----
                                while (streamReader.ReadLine() != "-----")
                                {
                                    // to store summary
                                    mediaSummary += streamReader.ReadLine();
                                }
                                // adding movie in to media collection
                                mediaCollection[mediaArrayIndex] = new Movie(singleData[1], int.Parse(singleData[2]), singleData[3], mediaSummary);
                                mediaArrayIndex++;

                                if (option.Equals("ALLMEDIA"))
                                {
                                    // displaying data if option is allmedia
                                    Console.WriteLine(singleData[0]);
                                    Console.WriteLine("Name:\t" + singleData[1]);
                                    Console.WriteLine("Year:\t" + singleData[2]);
                                    Console.WriteLine("Director:\t" + singleData[3] + "\n\n");
                                }
                            }
                            else if (singleData[0] == "SONG")
                            {
                                // adding song in to media collection
                                mediaCollection[mediaArrayIndex] = new Song(singleData[1], int.Parse(singleData[2]), singleData[3], singleData[4]);
                                mediaArrayIndex++;

                                if (option.Equals("ALLMEDIA"))
                                {
                                    // displaying data if option is allmedia
                                    Console.WriteLine(singleData[0]);
                                    Console.WriteLine("Album:\t" + singleData[1]);
                                    Console.WriteLine("Year:\t" + singleData[2]);
                                    Console.WriteLine("Artist:\t" + singleData[3] + "\n\n");
                                }
                            }
                        }
                        if (option.Equals("BOOK"))
                        {
                            // when user selects list all book option
                            if (singleData[0] == "BOOK")
                            {
                                //reading data file
                                mediaSummary = streamReader.ReadLine();
                                // line separation using -----
                                while (streamReader.ReadLine() != "-----")
                                {
                                    // to store summary
                                    mediaSummary += streamReader.ReadLine();
                                }
                                //adding media in mediacollection
                                mediaCollection[mediaArrayIndex] = new Book(singleData[1], int.Parse(singleData[2]), singleData[3], mediaSummary);
                                mediaArrayIndex++; // incrementing index

                                display(option);
                            }

                        }
                        if (option.Equals("SONG"))
                        {
                            //When user select list all song option
                            if (singleData[0] == "SONG")
                            {
                                // adding song in media collection
                                mediaCollection[mediaArrayIndex] = new Song(singleData[1], int.Parse(singleData[2]), singleData[3], singleData[4]);
                                mediaArrayIndex++;
                                display(option);
                            }
                        }
                        if (option.Equals("MOVIE"))
                        {
                            //When user select list all movie option
                            if (singleData[0] == "MOVIE")
                            {
                                //reading data file
                                mediaSummary = streamReader.ReadLine();
                                while (streamReader.ReadLine() != "-----")
                                {
                                    // reading summary
                                    mediaSummary += streamReader.ReadLine();
                                }
                                // adding movie in media collection
                                mediaCollection[mediaArrayIndex] = new Movie(singleData[1], int.Parse(singleData[2]), singleData[3], mediaSummary);
                                mediaArrayIndex++; // incresing index of media collection

                                display(option);
                            }
                        }
                        


                    }
                    streamReader.Close();
                }
                //Errors handling through Exceptions
                catch (IOException)
                {
                    Console.WriteLine("File not found!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error!!");
                }
            }




        }
    }
}
