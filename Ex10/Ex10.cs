using System;
using System.Linq;
using System.Text.RegularExpressions;

class Ex10
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
                    students.Add(new Student(action[0] + " " + action[1], Convert.ToInt32(action[2]))); // додавання студента
        }

        var Groups = students.GroupBy(s => s.Group) // групується за групою
                             .OrderBy(g => g.Key); // згрупований результат сортирується за ключем(групою)

        foreach (var group in Groups) // вивід студентів з Groups
        {
            Console.Write(group.Key + " - "); // виведення ключа(групи)

            List<string> temp = new(); // для імен студентів
            foreach (var student in group)
                temp.Add(student.Name); // записування кожного студента з цієї групи
            
            Console.WriteLine(string.Join(", ", temp)); // вивід імен студентів
        }


        Console.ReadKey();
    }
}