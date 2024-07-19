using System.Security.Principal;
using MovieStoreAppLevelOne.Models;

namespace MovieStoreAppLevelOne
{
    internal class Program
    {
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("----------------------WELCOME----------------------\n");
            while (true) 
            {
                Console.WriteLine("What do you wish to do?\n" +
                    "1.Add New Movie\n" +
                    "2.Display All Movies\n" +
                    "3.Find Movie By Id\n" +
                    "4.Remove Movie By Id\n" +
                    "5.Clear All Movies\n" +
                    "6.Exit\n\n" +
                    "Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(".....................................................");
                DoTask(choice);
            }
        }
        static void DoTask(int choice)
        {
            int maxMovies = 5;
            switch (choice)
            {
                case 1:
                    if(movies.Count < maxMovies)
                        AddNewMovie();
                    else
                        Console.WriteLine("You Can Add Upto Five Movies Only..");
                    break;
                case 2:
                    if (movies.Count() == 0)
                    {
                        Console.WriteLine("No Movies Left To Display..");
                        Console.WriteLine(".....................................................");
                    }
                    else
                    {
                       foreach(Movie movie in movies)
                        {
                            Console.WriteLine(movie);
                            Console.WriteLine(".....................................................");
                        }
                    }
                    break;
                case 3:
                    Movie findMovie =FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Movie Not Found..");
                    Console.WriteLine(".....................................................");
                    break;
                case 4:
                    RemoveMovieById();
                    break;
                case 5:
                    movies.Clear();
                    Console.WriteLine("Movies Were Cleared Successfully");
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input..");
                    break;
            }
        }
        static void AddNewMovie()
        {
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Name: ");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter Genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter Year of Release (YYYY): ");
            int yearOfRelease = Convert.ToInt32(Console.ReadLine());
            Movie newMovie = Movie.AddNewMoiveInfo(movieId, movieName, genre, yearOfRelease);
            movies.Add(newMovie);
            Console.WriteLine("New Movie Added Successfully..");
        }
        static Movie FindMovieById() 
        { 
            Movie findMovie = null;
            Console.WriteLine("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Movie movie in movies) 
            { 
                if(movie.Id == id)
                    findMovie = movie;
            }
            return findMovie;
        }
        static void RemoveMovieById()
        {
            Movie findMovie = FindMovieById();
            if (findMovie == null)
                Console.WriteLine("Movie Not Found..");
            else
                movies.Remove(findMovie);
            Console.WriteLine(".....................................................");
        }
    }
}
