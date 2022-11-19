using System;
using System.Collections.Generic;
using System.Linq;

class Ex1
{
    static void Main()
    {
        List<Student> students = new(); // колекція студентів

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування команди

            if (action != null)
                if (action[0].ToLower() == "end") { Console.WriteLine(); break; } // завершення вводу
                else if (action.Length == 3)
                    students.Add(new Student(action[0], action[1], Convert.ToInt32(action[2]))); // додавання студента
        }

        var SelectedStudents = from s in students // кожен елемент з students педерається в s
                               where s.Group == 2 // при умові що Group = 2
                               orderby s.FirstName // сортирування по спаданню за іменем
                               select s; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine(student.FirstName + " " + student.LastName);


        Console.ReadKey();
    }
}