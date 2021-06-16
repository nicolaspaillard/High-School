using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<Student> students = new List<Student>
            {
                new Student() { FirstName = "Douglas", LastName = "Dominic", Email = "felis@Fuscealiquam.com", BirthDate = DateTime.ParseExact("11/06/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Hughes", LastName = "Callum", Email = "parturient.montes@enimSuspendisse.ca", BirthDate = DateTime.ParseExact("22/08/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Richard", LastName = "Quentin", Email = "malesuada.id.erat@fringillaeuismod.co.uk", BirthDate = DateTime.ParseExact("14/02/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Sims", LastName = "Giselle", Email = "tellus.faucibus@nullaIn.org", BirthDate = DateTime.ParseExact("06/01/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Cross", LastName = "Whilemina", Email = "ut.ipsum.ac@InfaucibusMorbi.ca", BirthDate = DateTime.ParseExact("09/03/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Carver", LastName = "Leo", Email = "non.justo.Proin@penatibusetmagnis.edu", BirthDate = DateTime.ParseExact("23/09/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Price", LastName = "Lara", Email = "posuere@maurisidsapien.edu", BirthDate = DateTime.ParseExact("24/03/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Gutierrez", LastName = "Cole", Email = "Nunc.mauris.sapien@Inatpede.org", BirthDate = DateTime.ParseExact("19/06/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Serrano", LastName = "Odette", Email = "Mauris.ut.quam@ac.org", BirthDate = DateTime.ParseExact("05/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Hyde", LastName = "Nigel", Email = "neque.sed@Pellentesque.co.uk", BirthDate = DateTime.ParseExact("15/01/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Reilly", LastName = "Philip", Email = "ac.mattis@Curabitur.com", BirthDate = DateTime.ParseExact("23/03/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Chaney", LastName = "Timon", Email = "in.consectetuer@sedsem.org", BirthDate = DateTime.ParseExact("16/11/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Conner", LastName = "Stewart", Email = "mus@vulputateveliteu.co.uk", BirthDate = DateTime.ParseExact("23/08/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Marshall", LastName = "Quin", Email = "nisl.sem.consequat@disparturientmontes.com", BirthDate = DateTime.ParseExact("11/03/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Lester", LastName = "Madeson", Email = "Phasellus@felisegetvarius.org", BirthDate = DateTime.ParseExact("17/12/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Wilson", LastName = "Kevin", Email = "Nunc.ut@nuncsedlibero.ca", BirthDate = DateTime.ParseExact("29/10/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mckenzie", LastName = "Henry", Email = "nunc.risus.varius@elementumloremut.net", BirthDate = DateTime.ParseExact("17/06/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Butler", LastName = "Adara", Email = "erat.vel@eleifend.com", BirthDate = DateTime.ParseExact("09/04/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Harris", LastName = "Carissa", Email = "nec@ornare.com", BirthDate = DateTime.ParseExact("22/12/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Burt", LastName = "Caldwell", Email = "adipiscing.enim@magna.ca", BirthDate = DateTime.ParseExact("29/05/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Farrell", LastName = "Hedley", Email = "id.blandit@velit.co.uk", BirthDate = DateTime.ParseExact("25/06/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Orr", LastName = "Knox", Email = "mi.tempor.lorem@nuncid.ca", BirthDate = DateTime.ParseExact("27/04/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Floyd", LastName = "Evangeline", Email = "nunc@vestibulum.com", BirthDate = DateTime.ParseExact("10/07/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Patterson", LastName = "Aretha", Email = "inceptos@blanditcongueIn.org", BirthDate = DateTime.ParseExact("29/05/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Hall", LastName = "Geraldine", Email = "nunc@tortordictumeu.ca", BirthDate = DateTime.ParseExact("02/09/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Doyle", LastName = "Henry", Email = "justo.Praesent@infaucibusorci.co.uk", BirthDate = DateTime.ParseExact("01/01/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Hawkins", LastName = "Macon", Email = "aptent.taciti.sociosqu@atlacus.net", BirthDate = DateTime.ParseExact("27/04/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Wolf", LastName = "Maya", Email = "accumsan.neque.et@nullaInteger.edu", BirthDate = DateTime.ParseExact("22/04/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mcgee", LastName = "Henry", Email = "ipsum.non.arcu@nibh.ca", BirthDate = DateTime.ParseExact("16/10/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Vasquez", LastName = "Lara", Email = "sodales@tortorNunc.ca", BirthDate = DateTime.ParseExact("04/04/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Bernard", LastName = "Olympia", Email = "Etiam.imperdiet@dapibusgravida.co.uk", BirthDate = DateTime.ParseExact("08/02/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Franklin", LastName = "Ariana", Email = "dui.lectus.rutrum@egetvolutpatornare.edu", BirthDate = DateTime.ParseExact("15/08/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Good", LastName = "Tashya", Email = "eu@adipiscingMauris.org", BirthDate = DateTime.ParseExact("18/06/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Garza", LastName = "James", Email = "rhoncus.id@ipsumCurabiturconsequat.co.uk", BirthDate = DateTime.ParseExact("05/06/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mercer", LastName = "Athena", Email = "at@quisurna.org", BirthDate = DateTime.ParseExact("28/08/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Day", LastName = "Asher", Email = "congue.turpis@risusvarius.ca", BirthDate = DateTime.ParseExact("27/10/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Black", LastName = "Aquila", Email = "neque@Crasegetnisi.net", BirthDate = DateTime.ParseExact("12/10/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Gay", LastName = "James", Email = "convallis@egestasDuisac.co.uk", BirthDate = DateTime.ParseExact("29/06/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Booker", LastName = "Jolie", Email = "dolor@aliquet.org", BirthDate = DateTime.ParseExact("07/06/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Stark", LastName = "Karen", Email = "lobortis.ultrices@ac.com", BirthDate = DateTime.ParseExact("14/04/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mccray", LastName = "Clayton", Email = "diam@gravidasit.co.uk", BirthDate = DateTime.ParseExact("29/11/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Charles", LastName = "Armando", Email = "at.pretium@adipiscinglacus.co.uk", BirthDate = DateTime.ParseExact("13/02/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Norton", LastName = "Martina", Email = "ut.mi@nonenimcommodo.ca", BirthDate = DateTime.ParseExact("09/07/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Ramos", LastName = "Kenyon", Email = "Donec@etarcuimperdiet.co.uk", BirthDate = DateTime.ParseExact("03/03/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Collier", LastName = "Cecilia", Email = "In@augueut.net", BirthDate = DateTime.ParseExact("05/06/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mccall", LastName = "Lareina", Email = "lectus.Nullam.suscipit@sitametrisus.edu", BirthDate = DateTime.ParseExact("04/05/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Norris", LastName = "Leroy", Email = "Nullam.feugiat.placerat@Nam.net", BirthDate = DateTime.ParseExact("21/05/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Gentry", LastName = "Hakeem", Email = "commodo.at.libero@conubia.com", BirthDate = DateTime.ParseExact("29/10/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Shannon", LastName = "Rashad", Email = "Mauris.ut@Integeraliquamadipiscing.edu", BirthDate = DateTime.ParseExact("30/09/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Chaney", LastName = "Hyatt", Email = "ut@arcuNuncmauris.net", BirthDate = DateTime.ParseExact("03/11/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Boyd", LastName = "Martin", Email = "eget.nisi.dictum@feugiat.ca", BirthDate = DateTime.ParseExact("19/05/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Daniel", LastName = "Hillary", Email = "arcu.ac@DonectinciduntDonec.com", BirthDate = DateTime.ParseExact("20/11/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Graves", LastName = "Patience", Email = "Nullam.vitae@tincidunt.edu", BirthDate = DateTime.ParseExact("02/09/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Villarreal", LastName = "Colleen", Email = "lectus@dolor.co.uk", BirthDate = DateTime.ParseExact("29/10/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Chambers", LastName = "Kamal", Email = "Cras.vehicula.aliquet@egestasAliquamnec.org", BirthDate = DateTime.ParseExact("15/11/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Whitehead", LastName = "Evan", Email = "ante@Suspendisse.edu", BirthDate = DateTime.ParseExact("04/08/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Wynn", LastName = "Jessica", Email = "lectus.rutrum@euismodet.org", BirthDate = DateTime.ParseExact("07/08/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Franks", LastName = "Leandra", Email = "nec.orci@consequatauctornunc.ca", BirthDate = DateTime.ParseExact("27/09/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Ellis", LastName = "Tallulah", Email = "bibendum@metus.com", BirthDate = DateTime.ParseExact("10/07/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Williamson", LastName = "Jillian", Email = "pede.Suspendisse@cubilia.org", BirthDate = DateTime.ParseExact("06/06/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Bass", LastName = "Gray", Email = "sit.amet.orci@Donec.co.uk", BirthDate = DateTime.ParseExact("04/08/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Huber", LastName = "Dahlia", Email = "quam@in.ca", BirthDate = DateTime.ParseExact("30/09/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Burgess", LastName = "Kermit", Email = "lobortis.quam@rutrum.net", BirthDate = DateTime.ParseExact("06/04/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Cherry", LastName = "Howard", Email = "mus.Donec@Donec.org", BirthDate = DateTime.ParseExact("12/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "James", LastName = "Beverly", Email = "ligula.tortor@laciniamattis.edu", BirthDate = DateTime.ParseExact("10/08/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Little", LastName = "Rama", Email = "Donec.feugiat@montes.net", BirthDate = DateTime.ParseExact("10/03/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Washington", LastName = "Gay", Email = "Phasellus.dolor.elit@nislMaecenasmalesuada.edu", BirthDate = DateTime.ParseExact("28/11/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Ortiz", LastName = "Teagan", Email = "ultricies.sem.magna@Morbinonsapien.com", BirthDate = DateTime.ParseExact("16/12/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Sellers", LastName = "Chava", Email = "id.enim@non.com", BirthDate = DateTime.ParseExact("26/02/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Solis", LastName = "Rhona", Email = "ante@magna.net", BirthDate = DateTime.ParseExact("04/06/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Dunlap", LastName = "Erin", Email = "pede.Praesent.eu@fermentumrisus.edu", BirthDate = DateTime.ParseExact("27/10/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Salazar", LastName = "Jessica", Email = "lorem@atiaculis.co.uk", BirthDate = DateTime.ParseExact("08/09/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Ashley", LastName = "Maia", Email = "ac@ametorciUt.com", BirthDate = DateTime.ParseExact("13/05/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Dorsey", LastName = "Alfonso", Email = "euismod.mauris@sapienCras.org", BirthDate = DateTime.ParseExact("08/02/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mcclain", LastName = "Nasim", Email = "euismod.et@egestasFusce.co.uk", BirthDate = DateTime.ParseExact("17/10/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Meadows", LastName = "Nasim", Email = "Sed.diam.lorem@risusDonecegestas.ca", BirthDate = DateTime.ParseExact("03/12/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Key", LastName = "Donovan", Email = "lorem.ipsum@blanditmattis.edu", BirthDate = DateTime.ParseExact("06/02/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Salas", LastName = "Myra", Email = "et.malesuada.fames@tempus.org", BirthDate = DateTime.ParseExact("07/10/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Perkins", LastName = "Indira", Email = "non.cursus@enimnectempus.net", BirthDate = DateTime.ParseExact("22/07/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Harvey", LastName = "Aphrodite", Email = "egestas.Aliquam@hendrerit.ca", BirthDate = DateTime.ParseExact("29/11/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Pollard", LastName = "Cora", Email = "Proin.nisl.sem@Nullam.edu", BirthDate = DateTime.ParseExact("06/08/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Wells", LastName = "Harlan", Email = "quis.accumsan.convallis@in.com", BirthDate = DateTime.ParseExact("28/03/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Dodson", LastName = "Emma", Email = "interdum@mifringillami.net", BirthDate = DateTime.ParseExact("07/08/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Larsen", LastName = "Keiko", Email = "accumsan@mi.edu", BirthDate = DateTime.ParseExact("04/11/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Salinas", LastName = "Adam", Email = "eleifend.egestas.Sed@Aliquam.net", BirthDate = DateTime.ParseExact("10/06/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Thompson", LastName = "Marcia", Email = "Donec@scelerisqueloremipsum.net", BirthDate = DateTime.ParseExact("30/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Sanchez", LastName = "James", Email = "Quisque@primis.co.uk", BirthDate = DateTime.ParseExact("02/11/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Robinson", LastName = "Zephania", Email = "convallis@vel.co.uk", BirthDate = DateTime.ParseExact("20/07/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mayer", LastName = "Melvin", Email = "tempor.augue.ac@eratsemper.com", BirthDate = DateTime.ParseExact("15/07/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mason", LastName = "Jeremy", Email = "laoreet.libero@commodohendrerit.ca", BirthDate = DateTime.ParseExact("13/03/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Sanchez", LastName = "Jerry", Email = "Integer.sem@Nunc.com", BirthDate = DateTime.ParseExact("11/12/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Donaldson", LastName = "Vielka", Email = "sapien.gravida.non@ornarefacilisis.net", BirthDate = DateTime.ParseExact("10/04/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Stanton", LastName = "Michael", Email = "ac.facilisis@facilisisegetipsum.org", BirthDate = DateTime.ParseExact("23/07/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Frank", LastName = "Quamar", Email = "sociis@Ut.net", BirthDate = DateTime.ParseExact("09/11/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mack", LastName = "Dustin", Email = "mattis.Integer.eu@Morbi.edu", BirthDate = DateTime.ParseExact("06/02/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Craig", LastName = "Hunter", Email = "est.Nunc@sempercursusInteger.net", BirthDate = DateTime.ParseExact("16/08/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Burks", LastName = "Grady", Email = "pede.sagittis.augue@arcuetpede.org", BirthDate = DateTime.ParseExact("28/10/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Mckinney", LastName = "Violet", Email = "mollis.Duis@ligulaAliquam.org", BirthDate = DateTime.ParseExact("30/04/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Jensen", LastName = "Erin", Email = "Curabitur@Suspendisse.co.uk", BirthDate = DateTime.ParseExact("26/05/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new Student() { FirstName = "Burch", LastName = "Abel", Email = "libero@egestas.edu", BirthDate = DateTime.ParseExact("27/05/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) }
            };
            #endregion
            #region SUBJECTS
            List<Subject> subjects = new List<Subject>()
            {
                new Subject(){ Name = "Français"},
                new Subject(){ Name = "C#"},
                new Subject(){ Name = "Mathématiques"},
                new Subject(){ Name = "ASP.NET"},
                new Subject(){ Name = "Anglais"},
            };
            #endregion
            #region GROUPS
            List<Group> groups = new List<Group>()
            {

            };
            #endregion
            #region TEACHERS
            List<Teacher> teachers = new List<Teacher>()
            {
                new { FirstName = "Cassady", LastName = "Wagner", Email = "tellus@turpisIncondimentum.co.uk", BirthDate = DateTime.ParseExact("09/26/1987", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Camilla", LastName = "Walsh", Email = "Donec@sit.co.uk", BirthDate = DateTime.ParseExact("10/21/1981", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Stuart", LastName = "Bush", Email = "lorem@metusAeneansed.net", BirthDate = DateTime.ParseExact("05/05/1972", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Rowan", LastName = "Obrien", Email = "dapibus@porttitorinterdum.net", BirthDate = DateTime.ParseExact("11/28/1981", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Edward", LastName = "Chambers", Email = "fringilla@purus.org", BirthDate = DateTime.ParseExact("02/03/1988", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Jada", LastName = "Terrell", Email = "sagittis.Nullam.vitae@auguescelerisquemollis.com", BirthDate = DateTime.ParseExact("10/29/1980", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Mohammad", LastName = "Mclaughlin", Email = "vitae.mauris@accumsan.com", BirthDate = DateTime.ParseExact("03/07/1982", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Guy", LastName = "Fields", Email = "orci.lacus.vestibulum@fermentum.ca", BirthDate = DateTime.ParseExact("05/16/1993", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Rogan", LastName = "Dixon", Email = "Lorem@vestibulummassa.edu", BirthDate = DateTime.ParseExact("03/01/1982", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Hayfa", LastName = "Rice", Email = "porttitor.eros.nec@Sedpharetra.net", BirthDate = DateTime.ParseExact("06/24/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Lance", LastName = "Mcclure", Email = "mi@Curabitur.co.uk", BirthDate = DateTime.ParseExact("12/31/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Preston", LastName = "Aguilar", Email = "nascetur.ridiculus.mus@libero.org", BirthDate = DateTime.ParseExact("06/04/1984", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Laith", LastName = "Simpson", Email = "Suspendisse.sagittis.Nullam@nonenimcommodo.org", BirthDate = DateTime.ParseExact("10/10/1993", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Wayne", LastName = "Rios", Email = "eu@convallis.org", BirthDate = DateTime.ParseExact("04/16/1974", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Nicholas", LastName = "Cantu", Email = "scelerisque.neque@diam.net", BirthDate = DateTime.ParseExact("09/17/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Gray", LastName = "Frost", Email = "bibendum@orci.edu", BirthDate = DateTime.ParseExact("02/23/1992", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Clementine", LastName = "Franklin", Email = "eleifend@auctorullamcorper.org", BirthDate = DateTime.ParseExact("11/27/1982", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Kieran", LastName = "Harvey", Email = "condimentum.eget.volutpat@dui.org", BirthDate = DateTime.ParseExact("10/03/1994", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Meredith", LastName = "Kinney", Email = "Aenean.massa.Integer@sed.ca", BirthDate = DateTime.ParseExact("11/11/1995", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Victor", LastName = "Parsons", Email = "Mauris.ut@consequat.com", BirthDate = DateTime.ParseExact("10/27/1974", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Ferris", LastName = "Davenport", Email = "semper.dui@ligulaconsectetuer.edu", BirthDate = DateTime.ParseExact("02/12/1975", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Galena", LastName = "Mccarty", Email = "Lorem.ipsum@enimgravida.edu", BirthDate = DateTime.ParseExact("10/30/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Karly", LastName = "Beck", Email = "sed.leo@natoquepenatibuset.ca", BirthDate = DateTime.ParseExact("11/30/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Damon", LastName = "Hicks", Email = "lacus.vestibulum@elitAliquamauctor.ca", BirthDate = DateTime.ParseExact("01/09/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Samantha", LastName = "Gilliam", Email = "nec.enim@Integerurna.com", BirthDate = DateTime.ParseExact("12/23/1995", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Xanthus", LastName = "Michael", Email = "ante.bibendum.ullamcorper@duiquisaccumsan.net", BirthDate = DateTime.ParseExact("03/15/1993", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Brody", LastName = "Robbins", Email = "interdum@miAliquamgravida.edu", BirthDate = DateTime.ParseExact("06/25/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Michael", LastName = "Flynn", Email = "nec.eleifend.non@gravida.com", BirthDate = DateTime.ParseExact("04/01/1992", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Hadassah", LastName = "Jimenez", Email = "ac.arcu@elitelitfermentum.ca", BirthDate = DateTime.ParseExact("07/23/1992", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Kylee", LastName = "Pruitt", Email = "torquent.per.conubia@id.edu", BirthDate = DateTime.ParseExact("08/13/1986", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Emi", LastName = "Mcclain", Email = "Integer@seddui.co.uk", BirthDate = DateTime.ParseExact("10/13/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Hector", LastName = "Mendoza", Email = "cubilia@quispede.edu", BirthDate = DateTime.ParseExact("05/05/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Charissa", LastName = "Murray", Email = "primis.in@rutrumeu.ca", BirthDate = DateTime.ParseExact("12/19/1970", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Dara", LastName = "Ramos", Email = "sit.amet@eudui.org", BirthDate = DateTime.ParseExact("05/19/1973", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Kennan", LastName = "Castaneda", Email = "orci.Phasellus.dapibus@pharetra.co.uk", BirthDate = DateTime.ParseExact("01/11/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Arden", LastName = "Eaton", Email = "commodo.at.libero@Integer.co.uk", BirthDate = DateTime.ParseExact("05/02/1973", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Desiree", LastName = "Gray", Email = "nec.luctus@Inornaresagittis.co.uk", BirthDate = DateTime.ParseExact("09/20/1988", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Madeson", LastName = "Gilbert", Email = "dolor.elit@Nullatemporaugue.ca", BirthDate = DateTime.ParseExact("02/17/1996", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Fredericka", LastName = "Hamilton", Email = "quis.accumsan@egestashendrerit.net", BirthDate = DateTime.ParseExact("02/20/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Clare", LastName = "Morgan", Email = "nulla.In.tincidunt@pellentesqueafacilisis.ca", BirthDate = DateTime.ParseExact("07/27/1988", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Cherokee", LastName = "Christian", Email = "Quisque@FuscefeugiatLorem.co.uk", BirthDate = DateTime.ParseExact("09/30/1977", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Geoffrey", LastName = "Skinner", Email = "odio@tellus.ca", BirthDate = DateTime.ParseExact("06/18/1970", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Lois", LastName = "Sears", Email = "Proin.eget.odio@inlobortistellus.co.uk", BirthDate = DateTime.ParseExact("12/30/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Jerry", LastName = "Nixon", Email = "augue@gravidanon.net", BirthDate = DateTime.ParseExact("03/06/1990", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Philip", LastName = "Blackburn", Email = "velit.Sed@elitEtiam.net", BirthDate = DateTime.ParseExact("09/14/1988", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Fuller", LastName = "Colon", Email = "ultricies@Nullasempertellus.co.uk", BirthDate = DateTime.ParseExact("04/21/1970", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Meghan", LastName = "Keller", Email = "eget.laoreet@Uttinciduntorci.com", BirthDate = DateTime.ParseExact("11/04/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Zachary", LastName = "Velazquez", Email = "Mauris.ut.quam@Nunc.net", BirthDate = DateTime.ParseExact("01/30/1984", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Brady", LastName = "Workman", Email = "non.lobortis@eu.edu", BirthDate = DateTime.ParseExact("02/27/1984", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Austin", LastName = "Kline", Email = "montes.nascetur@Nullaaliquet.net", BirthDate = DateTime.ParseExact("10/25/1981", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Athena", LastName = "Weiss", Email = "vulputate.dui.nec@odioauctor.co.uk", BirthDate = DateTime.ParseExact("04/15/1980", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Griffith", LastName = "Navarro", Email = "lorem.fringilla@velit.org", BirthDate = DateTime.ParseExact("06/09/1971", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Maile", LastName = "Garza", Email = "malesuada.fames.ac@convallisconvallis.edu", BirthDate = DateTime.ParseExact("04/03/1976", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Zeus", LastName = "Peterson", Email = "rutrum.Fusce.dolor@Cras.org", BirthDate = DateTime.ParseExact("09/16/1979", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Ashton", LastName = "Delaney", Email = "Nulla.tincidunt.neque@sedduiFusce.edu", BirthDate = DateTime.ParseExact("02/05/1983", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Camilla", LastName = "Murray", Email = "Mauris.vestibulum@nuncsitamet.org", BirthDate = DateTime.ParseExact("08/06/1972", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Cassandra", LastName = "Albert", Email = "fermentum.arcu.Vestibulum@ultriciesligulaNullam.org", BirthDate = DateTime.ParseExact("01/21/1970", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Hammett", LastName = "Herrera", Email = "odio.semper@facilisis.com", BirthDate = DateTime.ParseExact("05/28/1988", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Rudyard", LastName = "Strong", Email = "et@turpisegestas.ca", BirthDate = DateTime.ParseExact("02/19/1991", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Justin", LastName = "Beard", Email = "cursus@anteipsum.edu", BirthDate = DateTime.ParseExact("09/17/1995", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Dana", LastName = "Austin", Email = "consectetuer.adipiscing@arcu.com", BirthDate = DateTime.ParseExact("05/14/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Coby", LastName = "Pena", Email = "dolor@augueacipsum.co.uk", BirthDate = DateTime.ParseExact("06/15/1979", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Penelope", LastName = "Bender", Email = "montes.nascetur@enimcommodohendrerit.ca", BirthDate = DateTime.ParseExact("06/13/1992", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Ezekiel", LastName = "Yates", Email = "Pellentesque@semvitaealiquam.com", BirthDate = DateTime.ParseExact("11/21/1981", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Charity", LastName = "Ayers", Email = "tempus.scelerisque@aliquetmagnaa.co.uk", BirthDate = DateTime.ParseExact("07/14/1993", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Cooper", LastName = "Gallegos", Email = "cursus@odio.com", BirthDate = DateTime.ParseExact("04/27/1996", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Kirk", LastName = "Blackwell", Email = "eget.volutpat.ornare@Vestibulumanteipsum.net", BirthDate = DateTime.ParseExact("06/24/1978", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Yvonne", LastName = "Cook", Email = "Duis.a.mi@vehiculaaliquetlibero.org", BirthDate = DateTime.ParseExact("01/29/1987", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Quincy", LastName = "Dalton", Email = "arcu@Proinsedturpis.edu", BirthDate = DateTime.ParseExact("11/25/1977", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Xyla", LastName = "Randolph", Email = "Donec.egestas@auctorMaurisvel.edu", BirthDate = DateTime.ParseExact("10/11/1996", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Wade", LastName = "Rogers", Email = "sit.amet.risus@adipiscingligulaAenean.com", BirthDate = DateTime.ParseExact("07/02/1971", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Cullen", LastName = "Kelley", Email = "Aenean.sed.pede@Quisquetincidunt.com", BirthDate = DateTime.ParseExact("06/28/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Owen", LastName = "Moss", Email = "Etiam.vestibulum@nonummyut.com", BirthDate = DateTime.ParseExact("05/03/1972", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Silas", LastName = "Orr", Email = "nec.ligula@non.org", BirthDate = DateTime.ParseExact("12/07/1995", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
	            new { FirstName = "Willow", LastName = "Curry", Email = "dui@vitae.ca", BirthDate = DateTime.ParseExact("06/11/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) }
            };
            #endregion
            #region CLASSROOM
            List<Classroom> classrooms = new List<Classroom>()
            {
                new Classroom(){},
                new Classroom(){},
                new Classroom(){},
                new Classroom(){},
                new Classroom(){},
                new Classroom(){},
            };
            #endregion
            #region COURSES
            List<Course> courses = new List<Course>()
            {

            };
            #endregion
            #region GRADES
            List<Grade> grades = new List<Grade>()
            {

            };
            #endregion
            #region MISSING
            List<Missing> missings = new List<Missing>()
            {

            };
            #endregion
            context.Students.AddRange(students);
            context.Teachers.AddRange(teachers);
            context.Subjects.AddRange(subjects);
            context.Groups.AddRange(groups);
            context.Classrooms.AddRange(classrooms);
            context.Courses.AddRange(courses);
            context.Grades.AddRange(grades);
            context.Missings.AddRange(missings);
            context.SaveChanges();
            // V ajout de données de test de la base ici V
        }
    }
}
