using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    //Permet d'initialiser la base en utilisant le contexte
    // Contexte.Initialise();
    public static class HighSchoolContextExtension
    {
        public static void Initialize(this HighSchoolContext context, bool dropAlways = false)
        {
            if (dropAlways)
                context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            //if db has been already seeded
            if (context.Students.Any())
                return;
            #region STUDENTS

            #endregion
            #region SUBJECTS

            #endregion
            #region GROUPS

            #endregion
            #region TEACHERS

            #endregion
            #region CLASSROOM

            #endregion
            #region COURSES

            #endregion
            #region GRADES

            #endregion
            #region MISSING

            #endregion
            context.Students.AddRange();
            context.Teachers.AddRange();
            context.Subjects.AddRange();
            context.Groups.AddRange();
            context.Classrooms.AddRange();
            context.Courses.AddRange();
            context.Grades.AddRange();
            context.Missings.AddRange();

            // V ajout de données de test de la base ici V
        }
    }
}
