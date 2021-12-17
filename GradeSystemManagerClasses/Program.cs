using Timer = System.Timers.Timer;

namespace GradeSystemManagerClasses
{
    class Program
    {
        public static List<Classroom> classRooms = new List<Classroom>();
        public static int counter = 5;
        public static int count = 1;

        public static string title = @"
░█▀▀█ █▀▀█ █▀▀█ █▀▀▄ █▀▀ 　 ░█▀▀▀█ █──█ █▀▀ ▀▀█▀▀ █▀▀ █▀▄▀█ 　 ░█▀▄▀█ █▀▀█ █▀▀▄ █▀▀█ █▀▀▀ █▀▀ █▀▀█ 
░█─▄▄ █▄▄▀ █▄▄█ █──█ █▀▀ 　 ─▀▀▀▄▄ █▄▄█ ▀▀█ ──█── █▀▀ █─▀─█ 　 ░█░█░█ █▄▄█ █──█ █▄▄█ █─▀█ █▀▀ █▄▄▀ 
░█▄▄█ ▀─▀▀ ▀──▀ ▀▀▀─ ▀▀▀ 　 ░█▄▄▄█ ▄▄▄█ ▀▀▀ ──▀── ▀▀▀ ▀───▀ 　 ░█──░█ ▀──▀ ▀──▀ ▀──▀ ▀▀▀▀ ▀▀▀ ▀─▀▀
  ";


        public static void Main(string[] args)
        {

            Console.WriteLine();
    


            while (true)
            {

                Console.WriteLine(title);
                Console.WriteLine();
                Console.WriteLine($"Welcome to the Grade System Manager");
                Console.WriteLine();
                Console.WriteLine("Press any key to get started!");
                Console.WriteLine();
                var cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }

            }
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Welcome to the Grade System Manager");
            Console.WriteLine();
            Console.WriteLine("Press any key to get started!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Show Classrooms");
            Console.WriteLine("2) Add Classrooms");
            Console.WriteLine("3) Remove Classroom");
            Console.WriteLine("4) Classroom Details Menu");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowClassroom();
                    break;
                case "2":
                    AddClassroom();
                    break;
                case "3":
                    RemoveClassroom();
                    break;
                case "4":
                    ClassroomDetailsMenu();
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again by pressing any key.");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        public static void DisplayClassroom()
        {
            count = 1;
            foreach (var classroom in classRooms)
            {
                Console.WriteLine($"{count++}) {classroom.ClassName}");
            }
        }

        public static void AddClassroom()
        {
            Console.Clear();
            Console.Write("Enter new classroom name: ");

            var input = Console.ReadLine();
            Classroom classroom = new Classroom(input);
            classRooms.Add(classroom);

            Console.WriteLine();
            Console.WriteLine($"{count++}) *{classroom.ClassName}* has been added");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to Main Menu!");
            Console.ReadKey();
            MainMenu();

        }
        public static void ShowClassroom()
        {
            if (classRooms.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Press any key to go back to Main Menu!");
                Console.WriteLine();
                Console.WriteLine("**No classes are in the system, please add a class an try again!**");
                Console.WriteLine();
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("****All Classrooms****");
                Console.WriteLine();
                DisplayClassroom();
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to Main Menu!");
                Console.ReadKey();
                MainMenu();
            }
        }

        public static void RemoveClassroom()
        {
            if (classRooms.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Press any key to go back to Main Menu!");
                Console.WriteLine();
                Console.WriteLine("**No classes are in the system, please add a class an try again!**");
                Console.WriteLine();
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("****Your Classrooms****");
                Console.WriteLine();
                DisplayClassroom();
                Console.WriteLine();
                Console.Write("Enter classroom you would like to remove: ");
                
                string? input = Console.ReadLine();
                Classroom foundClassroom = new Classroom(input);

                for (int i = 0; i < classRooms.Count; i++)
                {
                    if (input == classRooms[i].ClassName)
                    {
                        Console.WriteLine($"You just removed: {classRooms[i].ClassName}");
                        classRooms.RemoveAt(i);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to go back to Main Menu!");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Input not valid, Class names are case sensitive");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to try again!");
                        Console.ReadKey();
                        RemoveClassroom();
                    }
                }
                MainMenu();
            }
        }

        public static void ClassroomDetailsMenu()
        {
            Console.Clear();     
            Console.WriteLine();
            Console.WriteLine("**Your Classes**");
            Console.WriteLine();
            DisplayClassroom();
            Console.WriteLine();
            Console.WriteLine("Press ESC to go back to Main Menu");
            Console.WriteLine();

           if(classRooms.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Press any key to go back to Main Menu!");
                Console.WriteLine();
                Console.WriteLine("**No classes are in the system, please add a class an try again!**");
                Console.WriteLine();
                Console.ReadKey();
                Program.MainMenu();
            }
            else
            {
                Console.Write("Enter a class you would like to edit: ");

                string? classroomInput = Console.ReadLine();
                Classroom selectedClassroom;

                foreach (var classroom in classRooms)
                {
                    if (classroomInput == classroom.ClassName)
                    {
                        selectedClassroom = classroom;
                        selectedClassroom.ClassroomEditor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Input not valid, Class names are case sensitive");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to try again!");
                        Console.ReadKey();
                        ClassroomDetailsMenu();
                    }
                }
            }

            
            
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit immediatly and go back to menu!");
            var timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            var reset = Console.ReadKey();
            if (reset != null)
            {
                counter = 5;
                Console.Clear();
            }
            timer.Stop();
            
            MainMenu();
        }

        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine($"Application exiting in {counter--}");
            if (counter < 0)
            {
                Environment.Exit(0);
            }

        }

    }
}