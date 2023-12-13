using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество сотрудников: ");
            int employeeCount = int.Parse(Console.ReadLine());

            // Создаем массив сотрудников
            Employee[] employees = new Employee[employeeCount];

            // Заполняем массив сотрудниками
            for (int i = 0; i < employeeCount; i++)
            {
                employees[i] = ReadEmployeeFromConsole();
            }

            // a. Вывести полную информацию обо всех сотрудниках
            PrintAllEmployees(employees);

            // b. Вывести полную информацию о сотрудниках выбранной должности
            Console.Write("\nEnter position to filter by: ");
            string positionFilter = Console.ReadLine();
            PrintEmployeesByPosition(employees, positionFilter);

            // c. Найти менеджеров с зарплатой больше средней зарплаты клерков
            PrintManagersAboveClerkAverageSalary(employees);

            // d. Распечатать информацию о сотрудниках, принятых на работу позже определенной даты
            Console.Write("\nEnter hire date filter (MM/dd/yyyy): ");
            DateTime hireDateFilter = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
            PrintEmployeesHiredAfter(employees, hireDateFilter);

            // e. Вывести информацию о всех сотрудниках в зависимости от пола
            Console.Write("\nEnter gender filter (Male/Female/All): ");
            string genderFilter = Console.ReadLine();
            PrintEmployeesByGender(employees, genderFilter);

            Console.ReadLine(); // Чтобы консольное окно не закрылось сразу
        }

        // Метод для ввода данных о сотруднике с консоли
        static Employee ReadEmployeeFromConsole()
        {
            Employee employee = new Employee();

            Console.Write("Enter first name: ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            employee.LastName = Console.ReadLine();

            Console.Write("Enter hire date (MM/dd/yyyy): ");
            employee.HireDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

            Console.Write("Enter salary: ");
            employee.Salary = decimal.Parse(Console.ReadLine());

            Console.Write("Enter position: ");
            employee.Position = Console.ReadLine();

            Console.Write("Enter gender (Male/Female): ");
            employee.Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());

            return employee;
        }

        // Метод для вывода информации о всех сотрудниках
        static void PrintAllEmployees(Employee[] employees)
        {
            Console.WriteLine("\nAll Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Print());
            }
        }

        // Метод для вывода информации о сотрудниках выбранной должности
        static void PrintEmployeesByPosition(Employee[] employees, string positionFilter)
        {
            Console.WriteLine($"\nEmployees with position '{positionFilter}':");
            foreach (var employee in employees.Where(e => e.Position == positionFilter))
            {
                Console.WriteLine(employee.Print());
            }
        }

        // Метод для поиска и вывода информации о менеджерах с зарплатой выше средней зарплаты клерков
        static void PrintManagersAboveClerkAverageSalary(Employee[] employees)
        {
            decimal clerkAverageSalary = employees
                .Where(e => e.Position == "Clerk")
                .Average(e => e.Salary);

            Console.WriteLine("\nManagers with salary above average Clerk salary:");
            foreach (var manager in employees.Where(e => e.Position == "Manager" && e.Salary > clerkAverageSalary).OrderBy(e => e.LastName))
            {
                Console.WriteLine(manager.Print());
            }
        }

        // Метод для вывода информации о сотрудниках, принятых на работу позже определенной даты
        static void PrintEmployeesHiredAfter(Employee[] employees, DateTime hireDateFilter)
        {
            Console.WriteLine($"\nEmployees hired after {hireDateFilter.ToShortDateString()}:");
            foreach (var employee in employees.Where(e => e.HireDate > hireDateFilter).OrderBy(e => e.LastName))
            {
                Console.WriteLine(employee.Print());
            }
        }

        // Метод для вывода информации о сотрудниках в зависимости от пола
        static void PrintEmployeesByGender(Employee[] employees, string genderFilter)
        {
            Console.WriteLine($"\nEmployees with gender '{genderFilter}':");
            foreach (var employee in employees.Where(e =>
                (genderFilter == "Male" && e.Gender == Gender.Male) ||
                (genderFilter == "Female" && e.Gender == Gender.Female) ||
                genderFilter == "All"))
            {
                Console.WriteLine(employee.Print());
            }


        }
    }
}
