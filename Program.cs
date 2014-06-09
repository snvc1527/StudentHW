using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHW
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Student> StudentList = new List<Student> { // Intialize LIst Collection for student objects
                new Student("Stefan", "Vujovic", "snvc1527@aubih.edu.ba"),
                new Student("Nedim", "Sarajlic", "nmsc1524@aubih.edu.ba"),
                new Student("Eldin", "Kasapovic", "enkc1535@aubih.edu.ba"),
                new Student("Nedim", "Kulasin", "nmkn1507@aubih.edu.ba"),
                new Student("Kerim", "Krdzevic", "kmkc1501@aubih.edu.ba"),
                new Student("Haris", "Memovic", "hsmc1504@aubih.edu.ba"),
                new Student("Dino", "Praso", "dopo1504@aubih.edu.ba"),
                new Student("Semir", "Masic", "srmc1506@aubih.edu.ba"),
                new Student("Amina", "Bajraktarevic", "aabc1511@aubih.edu.ba"),
                };

                StudentList.Sort(); // Call Sort() method to sort the list of objects
                StudentList.ForEach(student => Console.WriteLine(student)); // This is going to write out all the students that are mentioned in this code bz using lambdz expression to minimize core
            }
            catch (PersonException)
            {
                Console.WriteLine("Please try again\n"); // Its telling us that there was some exception and that we should try again
            }
            finally
            {
                Console.WriteLine("Press Enter to Exit..."); // This is displaying us a message that is telling us to press enter to exit aplication or to close it
                Console.ReadLine();
            }
        }
    }

    class PersonException : Exception
    {
        public PersonException(string text, string value) // Exception constructor
        {
            Console.WriteLine("Error: Value \"{0}\" is not valid. {1}\n", value, text); // Its telling us that there is an error with the value
            return;
        }
    }
    abstract class Person
    {
        protected string name, LName;
        protected string FName
        {
            set
            {
                if (value.Length <= 2) // This is telling us that lenght can't be under two or it has to be longer than two
                {
                    throw new PersonException("Must be longer than 2", value);
                }

                char[] cArray = value.ToCharArray(); // Convert string to character array
                foreach (char c in cArray)
                {
                    if (!char.IsLetter(c)) // It can't be any special characters only letters
                    {
                        throw new PersonException("Can be only letter", value); // Show exception
                    }
                }

                if (!char.IsUpper(cArray[0])) // It must start with uppercase letter
                {
                    throw new PersonException("Name must start with an uppercase letter", value);
                }

                name = value;
            }
            get
            {
                return name;
            }
        }

        protected Person(string firsName, string lastName) // person constructor
        {
            this.FName = firsName;
            this.LName = lastName;
        }

        protected string GetPersonInformations() // Method to display info of the person class
        {
            return FName + ", " + LName; // This will return presons FirstName and LastName info
        }
    }

    class Student : Person, IComparable<Student>
    {
        public string email { get; set; }
        private string Location;
        public string location
        {
            get
            {
                if (Location == "SA") // If user typed in SA it will recognize it as he typed in Sarajevo
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ") // If user typed in TZ it will recognize it as he typed in Tuzla
                {
                    return "Tuzla";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo") // This is when someone types in SA, SARAJEVO or Sarajevo this is going to recognize it as he typed in Sarajevo
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla") // This is when someone types in TZ, TUZLA or Tuzla this is going to recognize it as he typed in Tuzla
                {
                    Location = "Tuzla";
                }
                else
                {
                    Location = "NA";
                }
            }
        }
        public Student() // empty stduent constructor with call to base class constructor with hardcoded parametyers
            : base("Stefan", "Vujovic")
        {
            this.email = "email@aubih.edu.ba";
            this.location = "Sarajevo";
        }

        ~Student() // empty student destructor
        {

        }

        public Student(string name, string lastname, string email) // Student constructor with 3 parameters
            : base(name, lastname)
        {
            this.email = email;
            this.location = "Sarajevo";
        }

        public string GetStudentInformations() // metod to display return from personinfo method ad well as data from student class
        {
            return base.GetPersonInformations() + ", " + this.email + ", " + this.location; // this is getting students email and location
        }

        public override string ToString() // Override of the tostring method to return getstudentinfo instead
        {
            return GetStudentInformations();
        }

        public int CompareTo(Student student)  // implementation of compareto method for Icomaprable
        {
            return this.name.CompareTo(student.name); // This is comparing it with student.name
        }
    }
}
