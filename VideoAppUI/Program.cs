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
            var video1 = new Video
            {
                Title = "Tarzan",
                Genre = "Eventyr",
                Year = 2016
            };
            bllFacade.VideoService.Create(video1);

            bllFacade.VideoService.Create(new Video()
            {
                Title = "Baby",
                Genre = "Drama",
                Year = 2018
            });

            //Console.WriteLine($"Name: {video1.Title}\nGenre: {video1.Genre}\n");

            string[] menuItems =
            {
                "List of videos",
                "Search", //Search the movies
                "Add a video",
                "Edit a video",
                "Delete a video", //Cru(d)
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListOfVideos();
                        break;
                    case 2:
                        FindVideoById();
                        break;
                    case 3:
                        AddVideo(); //Adds a video.
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        DeleteVideo(); //Deleting a video.
                        break;
                    default:
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Exiting...");
            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            if (video != null)
            {
                Console.WriteLine($"Video name: ");
                video.Title = Console.ReadLine();
                Console.WriteLine($"Genre name: ");
                video.Genre = Console.ReadLine();
                Console.WriteLine($"Year of video: ");
                video.Year = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Video not found...");
            }
        }

        private static Video FindVideoById()
        {
            Console.WriteLine("\nId for each video:");
            //foreach (var video in videos)
            //{
            //    Console.WriteLine($"Id:{video.Id} Title:{video.Title}");
            //}
            //Console.WriteLine("\nChoose the id of the video you wish to edit: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number...");
            }
            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            var response =
                videoFound == null ? "Video not found..." : "Video has been deleted...";
            Console.WriteLine(response);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            Console.WriteLine("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            bllFacade.VideoService.Create(new Video()
            {
                Title = title,
                Genre = genre,
                Year = year
            });
        }

        private static void ListOfVideos()
        {
            Console.WriteLine("\nList of videos:\n");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine(
                    $"Id: {video.Id}\nTitle of video: {video.Title}\nGenre: {video.Genre}\nYear: {video.Year}\n");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Choose a option...\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                Console.WriteLine("Please select a number between 1-6...");
            }
            Console.WriteLine($"\nYou have selected option: {selection} ({menuItems[selection - 1]})");
            return selection;
        }
    }
}