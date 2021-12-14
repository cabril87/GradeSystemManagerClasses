

namespace GradeSystemManagerClasses
{
    class Program
    {
        public static List<Classroom> classRooms = new List<Classroom>();



        public static void Main(string[] args)
        {
            Console.WriteLine();
            string title = @"
░█▀▀█ █▀▀█ █▀▀█ █▀▀▄ █▀▀ 　 ░█▀▀▀█ █──█ █▀▀ ▀▀█▀▀ █▀▀ █▀▄▀█ 　 ░█▀▄▀█ █▀▀█ █▀▀▄ █▀▀█ █▀▀▀ █▀▀ █▀▀█ 
░█─▄▄ █▄▄▀ █▄▄█ █──█ █▀▀ 　 ─▀▀▀▄▄ █▄▄█ ▀▀█ ──█── █▀▀ █─▀─█ 　 ░█░█░█ █▄▄█ █──█ █▄▄█ █─▀█ █▀▀ █▄▄▀ 
░█▄▄█ ▀─▀▀ ▀──▀ ▀▀▀─ ▀▀▀ 　 ░█▄▄▄█ ▄▄▄█ ▀▀▀ ──▀── ▀▀▀ ▀───▀ 　 ░█──░█ ▀──▀ ▀──▀ ▀──▀ ▀▀▀▀ ▀▀▀ ▀─▀▀
  ";

            Console.WriteLine(title);
            Console.WriteLine($"Welcome to the Grade System Manager");
            Console.WriteLine();
            Console.WriteLine("Press any key to get started!");
            Console.WriteLine();
            while (true)
            {
                var input = Console.ReadLine();

                if (input != null)
                {
                    Console.Clear();
                    MainMenu();

                    switch (input)
                    {
                        case "1":
                            MainMenu();
                            break;
                        case "2":
                            StudentMenu();
                            break;
                        case "3":
                            AssignmentMenu();
                            break;
                        case "4":
                            Exit();
                            break;
                        default:
                            break;
                    }
                }


                Console.WriteLine();
            }



        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine();
           // Console.WriteLine(title);
            Console.WriteLine($"Welcome to the Grade System Manager");
            Console.WriteLine();
            Console.WriteLine("Press any key to get started!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Classrooms");
            Console.WriteLine("2) Students");
            Console.WriteLine("3) Assingments");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ClassroomMenu();
                    break;
                case "2":
                    StudentMenu();
                    break;
                case "3":
                    AssignmentMenu();
                    break;
                case "4":
                    MainMenu();
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again.");
                    break;
            }
        }
        public static void ClassroomMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add classroom");
            Console.WriteLine("2) Show classrooms");
            Console.WriteLine("3) Edit classroom");
            Console.WriteLine("4) Remove classroom");
            Console.WriteLine("5) Get Class Average");
            Console.WriteLine("6) Get Top Student");
            Console.WriteLine("7) Get Worst Student");
            Console.WriteLine("8) Compare Students");
            Console.WriteLine("6) Main Menu");
            Console.WriteLine("6) Students");
            Console.WriteLine("7) Exit");
            Console.Write("\r\nSelect an option: ");

            var input = Console.ReadLine();
            //Classroom classes = new Classroom();

            switch (input)
            {
                case "1":
                    AddClassroom();

                    break;

                case "2":
                    ShowClassroom();

                    break;

                case "3":
                    EditClassroom();

                    break;

                case "4":
                    RemoveClassroom();


                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            //switch (input)
            //{
            //    Classroom addClass = new Classroom();

            //case "1":

            //    break;
            //case "2":
            //    //show classrooms method();
            //    break;
            //case "3":
            //    //edit classrooms method(); //will need to access list of classroom to select from 
            //    break;
            //case "4":
            //    //remove classrooms method(); // will need to access list of classrooms to select from 
            //    break;
            //case "5":
            //    //get class average method(); //choose class, 
            //case "6":
            ////get Top student average(); 
            //case "7":
            //    //exit method();//do we want this to return to mainmenu or close app?

            //default:
            //    break


        }
        public static void StudentMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Reverse String");
            Console.WriteLine("2) Remove Whitespace");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");



        }
        public static void AssignmentMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Get best grade");
            Console.WriteLine("2) Show worst grade");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
        }
        public static void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        public static void AddClassroom()
        {
            Console.Clear();
            Console.WriteLine("Enter a new classroom name: ");
            var input = Console.ReadLine();
            Classroom classroom = new Classroom(input);
            //classroom.ClassName = input;

            classRooms.Add(classroom);

                Console.WriteLine($"You just added a class named: {classroom.ClassName}");
          
            

            //ClassroomMenu();




        }
        public static void ShowClassroom()
        {
            Console.WriteLine();
            Console.WriteLine("****Your Classes****");
            Console.WriteLine();
            foreach (var classRoom in classRooms)
            {
                Console.WriteLine(classRoom.ClassName);
            }
            Console.ReadKey();

            ClassroomMenu();
        }

        public static void EditClassroom()
        {
            //while (true)
            Console.WriteLine("Please select a Classroom you wish visit: ");
            foreach (var classRoom in classRooms)
            {
                Console.WriteLine(classRoom.ClassName);
            }

            //string selectedClass;
            //selectedClass = Console.ReadLine();
            //Classroom selectedClassroom = new Classroom();

            ////after choosing a class (display options to see students>>>>>assignments, 

            //EditTheActualInformation(selectedClass);
            var classroomEntered = Console.ReadLine();
            var foundClassroom = new Classroom();

            foreach (var classroom in classRooms)
            {
                if (classroomEntered.Equals(classroom.ClassName))
                {
                    // we found the classroom 
                    foundClassroom = classroom;
                }
            }
            if (foundClassroom.ClassName.Length == 0)
            {
                Console.WriteLine("Please select a valid class");
                EditClassroom();
            }
            else
            {
                //Classroom.ClassroomEditor(Classroom foundClassroom);

                ClassroomEditor(foundClassroom);
            }

            Console.WriteLine();

        }

        public static void ClassroomEditor(Classroom foundClassroom)
        {
            Console.WriteLine("entering classroom editor");



            //later on when you call the methods it will be
            // foundClassroom.ShowStudent();
        }

        public static void RemoveClassroom()
        {
            //Console.Clear();
            Console.WriteLine("Select classroom to remove: ");
            foreach (var classroom in classRooms)
            {
                Console.WriteLine(classroom.ClassName);
            }
            var input = Console.ReadLine();
            var foundClassroom = new Classroom();
            foundClassroom.ClassName = input;



            for (int i = 0; i < classRooms.Count; i++)
            {
                if(input == classRooms[i].ClassName)
                {
                    classRooms.RemoveAt(i);
                    Console.WriteLine($"You just removed a class named: {i}");
                }

            }

            

            ClassroomMenu();
        }
    }
}