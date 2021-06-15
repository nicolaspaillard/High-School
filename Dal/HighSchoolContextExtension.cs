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
            
            // V ajout de données de test de la base ici V
        }
    }
}
