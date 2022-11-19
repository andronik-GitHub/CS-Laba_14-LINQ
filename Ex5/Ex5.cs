using System;
using System.Linq;
using System.Text.RegularExpressions;

class Ex5
{
    static void Main()
    {
        List<Student> students = new(); // колекція студентів

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування команди

            if (action != null)
                if (action[0].ToLower() == "end") { Console.WriteLine(); break; } // завершення вводу
                else if (action.Length == 3) // якщо введено 3 слова
                    students.Add(new Student(action[0], action[1], action[2])); // додавання студента
        }

        var SelectedStudents = from s in students
                               where new Regex(@"@gmail.com").IsMatch(s.Email) // якщо хост емейла gmail.com
                               select s;

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine(student);


        Console.ReadKey();
    }
}