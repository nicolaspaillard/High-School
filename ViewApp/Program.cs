using System;
using Dal;
using Models;

namespace ViewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HighSchoolContext())
            {
                context.Initialize(true);
                //on s'amuse
            }
        }
    }
}
