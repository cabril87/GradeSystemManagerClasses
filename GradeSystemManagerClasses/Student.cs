namespace GradeSystemManagerClasses
{
    public class Student
    {
        public string StudentName { get; set; }
        public List<Assignment> AssignmentList = new List<Assignment>();

        public Student() => StudentName = string.Empty;
        public Student(string? name) => StudentName = name;

        public void StudentEditor()
        {

            Console.Clear();
            Console.WriteLine($"Currently Editing {StudentName} \nPlease Select an option: ");
            Console.WriteLine();
            Console.WriteLine("1. Show Student Summary");
            Console.WriteLine("2. Add Assignment");
            Console.WriteLine("3. Show Assignment");
            Console.WriteLine("4. Remove Assignments");
            Console.WriteLine("5. Grade Assignments");
            Console.WriteLine($"6. Show {StudentName}'s Best Grade");
            Console.WriteLine($"7. Show {StudentName}'s Worst Grade");
            Console.WriteLine($"8. Show {StudentName}'s Average");
            Console.WriteLine("9. Select different class!");
            Console.WriteLine();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowStudentSummary();
                    break;
                case "2":
                    AddAssignment();
                    break;
                case "3":
                    ShowAssignments();
                    break;
                case "4":
                    RemoveAssignment();
                    break;
                case "5":
                    GradeAssignment();
                    break;
                case "6":
                    ShowBestGrade();
                    break;
                case "7":
                    ShowWorstGrade();
                    break;
                case "8":
                    GetAverage();
                    break;
                case "9":
                    Program.ClassroomDetailsMenu();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again by pressing any key.");
                    Console.ReadKey();
                    StudentEditor();
                    break;
            }
        }

        public void ShowStudentSummary()
        {
            Console.Clear();
            Console.WriteLine("**Student Summary**");
            Console.WriteLine();

            if (AssignmentList.Count == 0)
            {
                Console.WriteLine("This student has no assingments on record yet, press any key to go back to menu.");
                Console.WriteLine();
                Console.ReadKey();
                StudentEditor();
            }
            else
            {
                foreach (Assignment assignment in AssignmentList)
                {
                    Console.WriteLine($"Assingment name: {assignment.AssignmentName}");
                    Console.WriteLine();
                    Console.WriteLine($"Current Grade: {assignment.AssignmentGrade}");
                    Console.WriteLine($"Completion Status: {assignment.IsComplete}");
                    Console.WriteLine("---------------------------------");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to menu!");
                Console.ReadKey();
                StudentEditor();
            }
        }

        public void AddAssignment()
        {
            Console.Clear();
            Console.Write("Enter assingment name: ");
            var assignmentInput = Console.ReadLine();
            Assignment assignment = new Assignment(assignmentInput);

            AssignmentList.Add(assignment);
            assignment.IsComplete = false;

            Console.WriteLine();
            Console.WriteLine($"{assignment.AssignmentName} added, press any key to go to Menu!");
            Console.WriteLine();
            Console.ReadKey();
            StudentEditor();



        }

        public void ShowAssignments()
        {
            Console.Clear();
            Console.WriteLine($"**{StudentName} Assignments**");
            Console.WriteLine();
            if (AssignmentList.Count == 0)
            {
                Console.WriteLine("This student has no assingments on record yet, press any key to go back to menu.");
                Console.WriteLine();
                Console.ReadKey();
                StudentEditor();
            }
            else
            {
                foreach (var assignment in AssignmentList)
                {
                    Console.WriteLine(assignment.AssignmentName);
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadKey();
            StudentEditor();
        }

        public void RemoveAssignment()
        {
            Console.Clear();

            foreach (var assignment in AssignmentList)
            {
                Console.WriteLine($"Assingment name: {assignment.AssignmentName}");
                Console.WriteLine();
                Console.WriteLine($"Current Grade: {assignment.AssignmentGrade}");
                Console.WriteLine($"Completion Status: {assignment.IsComplete}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine();
            Console.Write("Enter the assignment name you would like removed or press ENTER to return: ");

            var assignmentInput = Console.ReadLine();
            var getAssignment = new Assignment();

            foreach (var assignment in AssignmentList)
            {
                if (assignmentInput == assignment.AssignmentName)
                {
                    getAssignment = assignment;
                }
            }

            if (getAssignment.AssignmentName.Length == 0)
            {
                Console.WriteLine("No assignment found");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                StudentEditor();
            }
            else
            {
                AssignmentList.Remove(getAssignment);
                Console.WriteLine($"{getAssignment.AssignmentName} removed");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                StudentEditor();
            }
            Console.WriteLine();

        }
        public void GradeAssignment()
        {
            Console.Clear();
            Console.WriteLine("**Assingments**");
            Console.WriteLine();
            foreach (var assignment in AssignmentList)
            {
                Console.WriteLine(assignment.AssignmentName);
            }
            Console.WriteLine();
            Console.Write("Please select the assignment you want to grade: ");
            var assignmentInput = Console.ReadLine();
            Assignment assignmentNameFound = new Assignment();

            foreach (var assignment in AssignmentList)
            {
                if (assignmentInput == assignment.AssignmentName)
                {
                    // we found the classroom 
                    assignmentNameFound = assignment;
                }
            }
            if (assignmentNameFound.AssignmentName.Length == 0)
            {
                Console.WriteLine("Please select a valid assignment");
                GradeAssignment();
            }
            else
            {
                Console.Write($"Add the grade for {assignmentNameFound.AssignmentName}: ");
                var grade = Convert.ToInt32(Console.ReadLine());
                assignmentNameFound.AssignmentGrade = grade;
                assignmentNameFound.IsComplete = true;

                Console.WriteLine();
                Console.WriteLine($"Grade {grade} saved.");
                Console.WriteLine();
                Console.WriteLine("Press ENTER to add another grade or ESC to return");

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    StudentEditor();
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    GradeAssignment();
                }
                else
                {
                    StudentEditor();
                }
            }
        }
        public void ShowBestGrade()
        {
            Console.Clear();
            Console.Write($"**{StudentName} best grade**");
            
            double bestGrade = 0.0;

            for (int i = 0; i < AssignmentList.Count; i++)
            {
                if(bestGrade < AssignmentList[i].AssignmentGrade)
                {
                    bestGrade = AssignmentList[i].AssignmentGrade;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{bestGrade}");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadKey();
            StudentEditor();
        }

        public void ShowWorstGrade()
        {
            Console.Clear();
            Console.Write($"**{StudentName} worst grade**");

            double worstGrade = 101;

            for (int i = 0; i < AssignmentList.Count; i++)
            {
                if (worstGrade > AssignmentList[i].AssignmentGrade)
                {
                    worstGrade = AssignmentList[i].AssignmentGrade;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{worstGrade}");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadKey();
            StudentEditor();
        }

        public double GetAverage()
        {
            double allGrades = 0.0;
            var allAssignments = AssignmentList.Count;

            if (allAssignments == 0)
            {
                return -1;
            }
            // average is total grade total / number of assignments 

            foreach (var assignment in AssignmentList)
            {
                allGrades += assignment.AssignmentGrade;
            }

            var averageGrade = allGrades / allAssignments;
            return averageGrade;
        }

    }
}