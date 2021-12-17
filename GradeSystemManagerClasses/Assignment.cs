namespace GradeSystemManagerClasses
{
    public class Assignment
    {
        public string? AssignmentName { get; set; }
        public double AssignmentGrade { get; set; }
        public bool IsComplete { get; set; }


        public Assignment() => this.AssignmentName = string.Empty;
        public Assignment(string? name) => this.AssignmentName = name;

        public Assignment(string name, double grade)
        {
            this.AssignmentName = name;
            this.AssignmentGrade = grade;
        }
    }
}