using Day03.Day5Lab;

namespace Day03
{
    internal class Program
    {

            static void Main(string[] args)
            {
                Console.WriteLine("========== Lab Assignments Test ==========\n");

                // ---------------------------------------------------------
                // 1. Test Point2D Sorting (IComparable)
                // ---------------------------------------------------------
                Console.WriteLine("[1] Testing Point2D Sorting:");
                Point2D[] points = {
                new Point2D(10, 20),
                new Point2D(5, 50),
                new Point2D(5, 10), 
                new Point2D(1, 5)
            };

                Array.Sort(points); 

                foreach (var p in points)
                {
                    Console.WriteLine($"Point: {p}");
                }
                Console.WriteLine();


                // ---------------------------------------------------------
                // 2. Test Utilities (Generics & TryParse)
                // ---------------------------------------------------------
                Console.WriteLine("[2] Testing Generic Utilities:");
        
                int maxNum = Utilities.Max(10, 45, 20, 33);
                Console.WriteLine($"Max Value found: {maxNum}");

             
                if (Utilities.TryParse("500", out int result))
                {
                    Console.WriteLine($"Successfully parsed: {result}");
                }
                Console.WriteLine();


                // ---------------------------------------------------------
                // 3. Test Singleton Config
                // ---------------------------------------------------------
                Console.WriteLine("[3] Testing Singleton Pattern:");
                Config settings = Config.Instance;
                settings.DeviceName = "Lab-PC-01";
                settings.Model = "Dell XPS";

            
                Config secondReference = Config.Instance;
                Console.WriteLine($"Device Name from 2nd reference: {secondReference.DeviceName}");
                Console.WriteLine();


                // ---------------------------------------------------------
                // 4. Test Student & Grade (Indexers & IEnumerable)
                // ---------------------------------------------------------
                Console.WriteLine("[4] Testing Grade Indexers & Foreach:");
                Grade myGrade = new Grade();
                myGrade.AddStudent(new Student { Name = "Ahmed", GPA = 3.2f });
                myGrade.AddStudent(new Student { Name = "Sara", GPA = 3.9f });

                myGrade["Ahmed"] = 3.5f;

             
                Console.WriteLine($"Student at index 0: {myGrade[0]}");

              
                Console.WriteLine("All Students in Grade:");
                foreach (var student in myGrade)
                {
                    Console.WriteLine($"- {student}");
                }
                Console.WriteLine();


                // ---------------------------------------------------------
                // 5. Test Payroll System (Out & Default Parameters)
                // ---------------------------------------------------------
                Console.WriteLine("[5] Testing Payroll System:");
                Payroll payroll = new Payroll();

                payroll.CalculateSalary("Ali", 40, out decimal salary1);
                Console.WriteLine($"Ali's Total Salary (Default Rate): {salary1}");

              
                payroll.CalculateSalary("Mona", 40, out decimal salary2, 100);
                Console.WriteLine($"Mona's Total Salary (Rate 100): {salary2}");
                Console.WriteLine();


                // ---------------------------------------------------------
                // 6. Test Fleet Management (Integrating Concepts)
                // ---------------------------------------------------------
                Console.WriteLine("[6] Testing Fleet Management:");
                FleetManager myFleet = FleetManager.Instance;

                Vehicle v1 = new Vehicle { Id = 101, Type = "Truck", FuelCapacity = 15 };
                v1.AddMileage(100, 50, 20); 
                myFleet.AddVehicle(v1);

             
                string status = string.Empty;
                myFleet[101]?.GetFuelStatus(out status);
                Console.WriteLine($"Vehicle 101 Fuel Status: {status}");
                Console.WriteLine();


                // ---------------------------------------------------------
                // 7. Test Music Playlist (Yield Return & Filters)
                // ---------------------------------------------------------
                Console.WriteLine("[7] Testing Music Playlist Filters:");
            MusicPlaylist playlist = new MusicPlaylist();

           
            playlist.AddSong(new Song { Title = "Song1", Artist = "A", Duration = 120, Genre = "Pop" });
            playlist.AddSong(new Song { Title = "Song2", Artist = "B", Duration = 300, Genre = "Rock" });
            playlist.AddSong(new Song { Title = "Song3", Artist = "C", Duration = 200, Genre = "Pop" });

            Console.WriteLine("All Songs:");
            foreach (var song in playlist)
            {
                Console.WriteLine(song);
            }

            Console.WriteLine("\nEnter Genre:");
            string genre = Console.ReadLine();

            var genreSongs = playlist.GetSongsByGenre(genre);

            Console.WriteLine("Filtered by Genre:");
            foreach (var song in genreSongs)
            {
                Console.WriteLine(song);
            }

            Console.WriteLine("\nEnter minimum duration:");
            int duration = int.Parse(Console.ReadLine());

            var longSongs = playlist.GetLongSongs(duration);

            Console.WriteLine("Long Songs:");
            foreach (var song in longSongs)
            {
                Console.WriteLine(song);
            }

        }
        }
    }
