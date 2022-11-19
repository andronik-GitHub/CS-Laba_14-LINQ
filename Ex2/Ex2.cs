using System;
using System.Linq;

class Ex2
{
    static void Main()
    {
        List<Student> students = new(); // колекція студентів

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування команди

            if (action != null)
                if (action[0].ToLower() == "end") { Console.WriteLine(); break; } // завершення вводу
                else if (action.Length == 2)
                    students.Add(new Student(action[0], action[1])); // додавання студента
        }

        var SelectedStudents = from s in students // кожен елемент з students педерається в s
                               where string.Compare(s.FirstName, s.LastName) <= 0 // при умові що FirstName >= LastName
                               select s; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine(student);


        Console.ReadKey();
    }
}