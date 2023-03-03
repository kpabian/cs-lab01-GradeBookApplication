using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            int less = 0, more = 0;
            foreach(Student student in Students)
            {
                if (averageGrade > student.AverageGrade)
                    less++;
                else
                    more++;
            }
            if (less + more < 5)
                throw new InvalidOperationException();
            else
            {
                double rank = (double)more / (more + less);
                if (rank <= 0.2)
                    return 'A';
                else if (rank <= 0.4)
                    return 'B';
                else if (rank <= 0.6)
                    return 'C';
                else if (rank <= 0.8)
                    return 'D';
                else
                    return 'F';

            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
