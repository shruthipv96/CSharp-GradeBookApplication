using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            var step = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[step - 1] <= averageGrade)
                return 'A';
            else if (grades[step * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[step * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[step * 4 - 1] <= averageGrade)
                return 'D';
            else
                return base.GetLetterGrade(averageGrade);


        }
    }
}
