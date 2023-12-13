using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11
{
    public enum Gender
    {
        Male,
        Female
    }

    public struct Employee : IPrint
    {
        public string FirstName;
        public string LastName;
        public DateTime HireDate;
        public decimal Salary;
        public string Position;
        public Gender Gender;

        public string Print()
        {
            return $"{FirstName} {LastName}, Position: {Position}, Salary: {Salary}, Gender: {Gender}, Hire Date: {HireDate.ToShortDateString()}";
        }
    }

}
