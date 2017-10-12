namespace DictionaryExtensions.StudentsAndCourses
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }

        public int CompareTo(Student other)
        {
            int result = 0;
            if (other == this)
            {
                return result;
            }

            result = this.LastName.CompareTo(other.LastName);

            if (result == 0)
            {
                result = this.FirstName.CompareTo(other.FirstName);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Join(" ", this.FirstName, this.LastName);
        }
    }
}
