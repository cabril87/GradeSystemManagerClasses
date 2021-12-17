namespace GradeSystemManagerClasses
{
    public class Classroom
    {
        public string ClassName { get; set; }
        public List<Student> students = new List<Student>();
        public int count = 1;

        public Classroom() => ClassName = string.Empty;
        public Classroom(string? classname) => this.ClassName = classname;

        public void ClassroomEditor()
        {

            Console.Clear();
            Console.WriteLine($"Currently Editing {ClassName} \nPlease Select an option");
            Console.WriteLine();
            Console.WriteLine("1. Show Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Student Details Menu");
            Console.WriteLine("5. Show Class Average");
            Console.WriteLine("6. Show Top Student");
            Console.WriteLine("7. Show Worst Student");
            Console.WriteLine("8. Compare Two Students");
            Console.WriteLine("9. Exit To Main Menu");
            Console.WriteLine();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowStudents();
                    break;
                case "2":
                    AddStudent();
                    break;
                case "3":
                    RemoveStudent();
                    break;
                case "4":
                    StudentDetailsMenu();
                    break;
                case "5":
                    ShowClassAverage();
                    break;
                case "6":
                    ShowBestStudent();
                    break;
                case "7":
                    ShowWorstStudent();
                    break;
                case "8":
                    CompareTwoStudents();
                    break;
                case "9":
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again by pressing any key.");
                    Console.ReadKey();
                    ClassroomEditor();
                    break;
            }
        }

        public void AddStudent()
        {

            Console.Clear();
            Console.Write("Enter new student name: ");
            string? studentInput = Console.ReadLine();
            Student student = new Student(studentInput);

            students.Add(student);
            Console.WriteLine();
            Console.WriteLine($"{student.StudentName} added to the {ClassName} class");
            Console.WriteLine();
            Console.WriteLine("Press enter to add another student or escape to go back!");

            var keyInput = Console.ReadKey().Key;

            if (keyInput == ConsoleKey.Enter)
            {
                Console.Clear();
                AddStudent();
            }
            else if (keyInput == ConsoleKey.Escape)
            {
                Console.Clear();
                ClassroomEditor();

            }
            else
            {
                Console.Clear();
                ClassroomEditor();
            }


            


        }
        public void DisplayStudents()
        {
            count = 1;
            foreach (var student in students)
            {
                Console.WriteLine($"{count++}) {student.StudentName}");
            }
        }
        public void ShowStudents()
        {
            Console.Clear();
            Console.WriteLine("**ALL STUDENTS**");
            Console.WriteLine();

            DisplayStudents();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to previous menu!");
            Console.ReadKey();
            ClassroomEditor();

        }
        public void RemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("**ALL STUDENTS**");
            Console.WriteLine();
            DisplayStudents();
            Console.WriteLine();
            Console.Write("Enter students name you would like removed: ");

            string? input = Console.ReadLine();
            Student student = new Student();

            foreach (var std in students)
            {
                if (input == std.StudentName)
                {
                    student = std;
                }
            }
            if (student.StudentName.Length == 0)
            {
                Console.WriteLine("Please add student no student in class");
                ClassroomEditor();
            }
            else
            {
                Console.Clear();
                students.Remove(student);
                Console.WriteLine();
                Console.WriteLine($"{student.StudentName} removed from class!!");
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to previos menu!");
                Console.ReadKey();
                ClassroomEditor();
            }
        }

        public void StudentDetailsMenu()
        {
            Console.Clear();
            Console.WriteLine("**Your Students**");
            Console.WriteLine();
            DisplayStudents();
            Console.WriteLine();
            Console.WriteLine("Press ESC to go back to Main Menu");
            Console.WriteLine();

            if (students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Press any key to go back to Main Menu!");
                Console.WriteLine();
                Console.WriteLine("**No students are in the system, please add a student an try again!**");
                Console.WriteLine();
                Console.ReadKey();
                Program.MainMenu();
            }
            else
            {
                Console.Write("Enter a student you would like to edit: ");

                string? studentInput = Console.ReadLine();
                Student selectedStudent = new Student(studentInput);

                for (int i = 0; i < students.Count; i++)
                
                    {
                    if (studentInput == students[i].StudentName)
                    {
                        selectedStudent = students[i];
                        selectedStudent.StudentEditor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Input not valid, Student names are case sensitive");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to try again!");
                        Console.ReadKey();
                        StudentDetailsMenu();
                    }
                }
            }
        }

        public void ShowClassAverage()
        {
            Console.Clear();


            double grade = 0.0;
            var allStudents = students.Count;

            if (allStudents == 0)
            {
                Console.WriteLine();
                Console.WriteLine("There are no students in this class");
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to menu!");
                Console.ReadKey();
                ClassroomEditor();
            }
            else
            {
                Console.Write("The Class Average is : ");
            }

            foreach (Student student in students)
            {
                if (student.GetAverage() == -1)
                {
                    allStudents--;
                }
                else
                {
                    grade += student.GetAverage();
                }
            }

            var classAverage = Math.Round(grade / allStudents);
            Console.WriteLine(classAverage);

            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadKey();
            ClassroomEditor();
        }

        public void ShowBestStudent()
        {
            Console.Clear();
            Console.WriteLine("Top Student: ");
            List<double> averageGrades = new List<double>();
            double studentGrade = 0.0;
            double bestStudentGrade = 0.0;
            string? bestStudentName = "";

            foreach (var student in students)
            {
                studentGrade = student.GetAverage();
                averageGrades.Add(studentGrade);
                bestStudentGrade = averageGrades.Max();
                if (bestStudentGrade == studentGrade)
                {
                    bestStudentName = student.StudentName;
                }
            }
            Console.WriteLine($"{bestStudentName}: {bestStudentGrade}%");

            Console.WriteLine();
        }

        public void ShowWorstStudent()
        {
            Console.Clear();
            Console.WriteLine("Worst Student: ");
            List<double> averageGrades = new List<double>();
            double studentGrade = 0.0;
            double worstStudentGrade = 0.0;
            string? worstStudentName = "";

            foreach (var student in students)
            {
                studentGrade = student.GetAverage();
                averageGrades.Add(studentGrade);
                worstStudentGrade = averageGrades.Min();
                if (worstStudentGrade == studentGrade)
                {
                    worstStudentName = student.StudentName;
                }
            }
            Console.WriteLine($"{worstStudentName}: {worstStudentGrade}%");

            Console.WriteLine();
        }

        public void CompareTwoStudents()
        {
            Console.Clear();
            Console.WriteLine("Compare two students: \n ");
            DisplayStudents();
            Console.WriteLine();
            Console.WriteLine("Enter the first student you woudld like to compare");
            var firstStudentInput = Console.ReadLine();
            var firstStudent = new Student();
            Console.WriteLine("Enter the second student you would like to compare ");
            var secondStudentInput = Console.ReadLine();
            var secondStudent = new Student();
            Console.Clear();

            foreach (var student in students)
            {
                if (firstStudentInput == student.StudentName)
                {
                    firstStudent = student;

                }
                if (secondStudentInput == student.StudentName)
                {
                    secondStudent = student;
                }
            }
            if (firstStudent.StudentName.Length == 0)
            {
                Console.WriteLine("Please enter a student in the class");
                CompareTwoStudents();
            }
            if (secondStudent.StudentName.Length == 0)
            {
                Console.WriteLine("Please enter a student in the class");
                CompareTwoStudents();
            }
            else
            {
                ComparisonInfo(firstStudent);
                Console.WriteLine("----------------------------");
                ComparisonInfo(secondStudent);
            }

            Console.WriteLine();
        }

        public void ComparisonInfo(Student student)
        {
            Console.WriteLine($"{student.StudentName}: {student.GetAverage()}%");
        }
    }
}