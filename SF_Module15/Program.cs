using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace SF_Module15
{
    class Program
    {
        // [15.2.8]
        /*
        public static List<int> Numbers = new List<int>();
        */

        static void Main(string[] args)
        {
            // [15.1.4]
            /*
            static int CountCommon(string word1, string word2)
            {
                var amount = word1.Intersect(word2).Count();

                return amount;
            }

            Console.WriteLine(CountCommon("one", "two"));
            */

            // [15.1.5]
            /*
            var softwareManufacturers = new List<string>()
            {
                "Microsoft", "Apple", "Oracle"
            };

            var hardwareManufacturers = new List<string>()
            {
                "Apple", "Samsung", "Intel"
            };

            var itCompanies = softwareManufacturers.Union(hardwareManufacturers);

            foreach (var companies in itCompanies)
                Console.WriteLine(companies);
            */

            // [15.1.6]
            /*
            Console.WriteLine("Введите текст:");

            var text = Console.ReadLine();
            
            var punctuation = new List<char>() { ' ', ',', '.', ';', ':', '!', '?' };

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Вы ввели пустой текст");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Текст без знаков препинания: ");

            var noPunctuation = text.Except(punctuation).ToArray();

            Console.WriteLine(noPunctuation);
            */

            // [15.2.1]
            /*
            static long Factorial(int number)
            {
                var numbers = new List<int>();

                for (int i = 1; i <= number; i++)
                    numbers.Add(i);

                return numbers.Aggregate((x, y) => x * y);
            }
            */

            // [15.2.2]
            /*
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 79994500508 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675334 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            var invalidContacts =
                (from contact in contacts
                 let phoneString = contact.Phone.ToString()
                 where !phoneString.StartsWith('7') || phoneString.Length != 11
                 select contact)
                 .Count();
            */

            // [15.2.3]
            /*
            static double Average(int[] numbers)
            {
                return numbers.Sum() / (double)numbers.Length;
            }
            */

            // [15.2.8]
            /*
            while (true)
            {
                var input = Console.ReadLine();

                var isInteger = Int32.TryParse(input, out int inputNum);

                if (!isInteger)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы ввели не число");
                }
                else
                {
                    Numbers.Add(inputNum);

                    Console.WriteLine("Число " + input + " добавлено в список.");
                    Console.WriteLine($"Всего в списке  { Numbers.Count} чисел");
                    Console.WriteLine($"Сумма:  {Numbers.Sum()}");
                    Console.WriteLine($"Наибольшее:  {Numbers.Max()}");
                    Console.WriteLine($"Наименьшее:  {Numbers.Min()}");
                    Console.WriteLine($"Среднее:  {Numbers.Average()}");

                    Console.WriteLine();
                }
            }
            */

            // [15.3.3]
            /*
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

            var grouped = phoneBook.GroupBy(c => c.Email.Split("@").Last());

            foreach (var group in grouped)
            {
                if (group.Key.Contains("example"))
                {
                    Console.WriteLine("Фейковые адреса: ");

                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }
                else
                {
                    Console.WriteLine("Реальные адреса: ");
                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }

                Console.WriteLine();
            }
            */

            // [15.4.1]
            /*
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var employeeAndDep = from employee in employees
                                 join dep in departments on employee.DepartmentId equals dep.Id
                                 select new
                                 {
                                     EmployeeName = employee.Name,
                                     DepartmentName = dep.Name
                                 };

            foreach (var item in employeeAndDep)
                Console.WriteLine(item.EmployeeName + ", отдел: " + item.DepartmentName);
            */

            // [15.4.2]
            /*
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var depsWithEmployees = departments.GroupJoin(
                employees,
                d => d.Id,
                e => e.DepartmentId,
                (d, emps) => new
                {
                    Name = d.Name,
                    Employees = emps.Select(e => e.Name)
                });

            foreach (var dep in depsWithEmployees)
            {
                Console.WriteLine(dep.Name + ":");

                foreach (string emp in dep.Employees)
                    Console.WriteLine(emp);

                Console.WriteLine();
            }
            */

            // [15.5.4]
            /*
            var names = new List<string>() { "Вася", "Вова", "Петя", "Андрей" };

            var experiment = names.Where(name => name.StartsWith("В"));

            names.Remove("Вася");
            names.Remove("Вова");

            foreach (var word in experiment)
                Console.WriteLine(word);
            */
            /*
            var names = new List<string>() { "Вася", "Вова", "Петя", "Андрей" };

            var experiment = names.Where(name => name.StartsWith("В")).ToArray();

            names.Remove("Вася");
            names.Remove("Вова");

            foreach (var word in experiment)
                Console.WriteLine(word);
            */
        }

        // [15.2.2]
        /*
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
        }
        */

        // [15.3.3]
        /*
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
            public string Email { get; set; }

            public Contact(string name, long phone, string email)
            {
                Name = name;
                Phone = phone;
                Email = email;
            }
        }
        */

        // [15.4.1 - 15.4.2]
        /*
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Employee
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
        }
        */
    }
}