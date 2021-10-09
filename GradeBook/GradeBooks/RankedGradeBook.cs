﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int studentsWithHigherGrade = 0;
            foreach (Student s in Students)
            {
                if (s.AverageGrade > averageGrade)
                {
                    studentsWithHigherGrade++;
                }
            }

            int twentyPercentOfStudents = Students.Count / 5;
            int gradeLevelsToDrop = studentsWithHigherGrade / twentyPercentOfStudents;
            switch (gradeLevelsToDrop)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
