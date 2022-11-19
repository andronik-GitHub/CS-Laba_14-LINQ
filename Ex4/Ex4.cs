using System;
using System.Linq;

class Ex4
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

        var SelectedStudents = students // сортування
                                        .OrderBy(s => s.LastName) // спочатку по зростанню за прізвищем
                                        .OrderByDescending(s => s.FirstName); // потім по спаданню за іменем

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine(student);


        Console.ReadKey();
    }
}