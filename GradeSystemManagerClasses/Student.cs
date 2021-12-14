namespace GradeSystemManagerClasses
{
    class Student
    {
        public string? Name { get; set; }
        public double Grade { get; set; }

        public Student()
        {
        
        }
        public Student(string name)
        {
            this.Name = name;
        }
        public Student(double grade)
        {
            this.Grade = grade;
        }
        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
        public void studentSummary()
        {
            Console.WriteLine("Student Summary\n");
            string[] options = {"1.Student Summary", "2.Assign Work", "3.Unassign Work", "4. Show Best Grades", "5.Show Worst Grades", "6.Student Average", "7.Go Back" };
            foreach (string option in options)
                Console.WriteLine(option);

            
        }

        //public void studentSummary() { }
        public void assignWork() { }
        public void unassignWork() { }
        public void showBest() { }
        public void showWorst() { }
        public static void Average() { }
        public void goBack() { }
    }
}