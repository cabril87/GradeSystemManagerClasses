namespace GradeSystemManagerClasses
{
    public class Classroom
    {
        //List<Student> stuList = new List<Student>();
        public string ClassName { get; set; }

        public Classroom()
        {
            ClassName = "";
        }

        public Classroom(string classname)
        {
            this.ClassName = classname;
        }



        // public List<string> classrooms = new List<string>();

        //public void AddClassroom()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Enter a new classroom name: ");
        //    var input = Console.ReadLine();
        //    if (input != null)
        //    {
        //        classRooms.Add(input);

        //        Console.WriteLine($"You just added a class named: {input}");
        //    }
        //    Program.ClassroomMenu();




        //}
        //public void ShowClassroom()
        //{
        //    foreach (var classRoom in classRooms)
        //    {
        //        Console.WriteLine(classRoom);
        //    }

        //    Program.ClassroomMenu();
        //}


        //public static void DisplayClassrooms()
        //{
        //    foreach (Classroom classroom in listOfClasses)
        //    {
        //        Console.WriteLine(classroom.className);
        //    }
        //    Console.WriteLine("Press any key to continue");
        //    Console.ReadKey();
        //}

        //public static void ClassroomEditor(Classroom foundClassroom)
        //{
        //    Console.WriteLine("entering classroom editor");



        //    //later on when you call the methods it will be
        //    // foundClassroom.ShowStudent();
        //}

        //public void RemoveClassroom()
        //{

        //}

    }
}