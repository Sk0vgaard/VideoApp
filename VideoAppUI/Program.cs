using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using VideoAppBLL;
using VideoAppEntity;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();


        static void Main(string[] args)
        {
            //Adds the first video.
            var video1 = new Video
            {
                Title = "Tarzan",
                Genre = "Eventyr",
                Year = 2016
            };
            bllFacade.VideoService.Create(video1);

            //A other way to add a new video.
            bllFacade.VideoService.Create(new Video()
            {
                Title = "Baby",
                Genre = "Drama",
                Year = 2018
            });

            //List of options.
            string[] menuItems =
            {
                "List of videos",
                "Search", //Search the movies
                "Add a video",
                "Edit a video",
                "Delete a video", //Cru(d)
                "Exit"
            };
            // Shows the menu.
            var selection = ShowMenu(menuItems);
            //Closes if the selection is 6.
            while (selection != 6)
            {
                //Switch statement which checks what have been chosen.
                switch (selection)
                {
                    case 1:
                        ListOfVideos(); //Shows the list of all the videos.
                        break;
                    case 2:
                        FindVideoById(); //Search (under development.)
                        break;
                    case 3:
                        AddVideo(); //Adds a video.
                        break;
                    case 4:
                        EditVideo(); //Edits the video (new Title, Genre and Year.)
                        break;
                    case 5:
                        DeleteVideo(); //Deletes a video.
                        break;
                    default:
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                //Show menu agian after an option has been chosen.
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Exiting...");
            Console.ReadLine();
        }

        // The method for editing a video.
        private static void EditVideo()
        {
            // Finds the video to be edited by the ID.
            var video = FindVideoById();
            // If the video has been found then the edit starts.
            if (video != null)
            {
                Console.WriteLine($"Video name: ");
                video.Title = Console.ReadLine();
                Console.WriteLine($"Genre name: ");
                video.Genre = Console.ReadLine();
                Console.WriteLine($"Year of video: ");
                video.Year = int.Parse(Console.ReadLine());
            }
            // If the video isnt found the app will tell the user that the Video isnt found.
            else
            {
                Console.WriteLine("Video not found...");
            }
        }

        //Finds the video by the id.
        private static Video FindVideoById()
        {
            Console.WriteLine("\nId for each video:");
            int id;
            // Checks if the user have used a int and not string.
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number...");
            }
            // Returns the id to the user.
            return bllFacade.VideoService.Get(id);
        }

        //Deletes the video.
        private static void DeleteVideo()
        {
            //Finds the video with id.
            var videoFound = FindVideoById();
            //If the video has been found delete it by the id.
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            // ternarystatement which checks if the video is found and gives one of the options as a result.
            var response =
                videoFound == null ? "Video not found..." : "Video has been deleted...";
            Console.WriteLine(response);
        }

        //Adding a video.
        private static void AddVideo()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            Console.WriteLine("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            //Creates the new video.
            bllFacade.VideoService.Create(new Video()
            {
                Title = title,
                Genre = genre,
                Year = year
            });
        }

        //Shows the list of all the videoes.
        private static void ListOfVideos()
        {
            Console.WriteLine("\nList of videos:\n");
            //Show every video in the list.
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                //Show the info for each video.
                Console.WriteLine(
                    $"Id: {video.Id}\nTitle of video: {video.Title}\nGenre: {video.Genre}\nYear: {video.Year}\n");
            }
            Console.WriteLine("\n");
        }

        //Shows the menu after end option.
        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Choose a option...\n");

            //Gives a number for each option.
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;
            //Checks if it is a int and not string. Can only choose between 1-6.
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                Console.WriteLine("Please select a number between 1-6...");
            }
            Console.WriteLine($"\nYou have selected option: {selection} ({menuItems[selection - 1]})");
            //Returns the selection for the user.
            return selection;
        }
    }
}