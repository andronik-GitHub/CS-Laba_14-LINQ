using System;
using System.Linq;
using System.Text.RegularExpressions;

class Ex8
{
    static void Main()
    {
        List<Student> students = new(); // колекція студентів

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування команди

            if (action != null)
                if (action[0].ToLower() == "end") { Console.WriteLine(); break; } // завершення вводу
                else if (action.Length >= 3) // якщо введено 3 слова
                {
                    int[] temp = new int[action.Length - 2]; // для запису оцінок
                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = Convert.ToInt32(action[i + 2]); // запис оцінки

                    students.Add(new Student(action[0], action[1], temp)); // додавання студента
                }
        }

        var SelectedStudents = from s in students
                               where s.Marks.Where(m => m <= 3).Count() >= 2 // якщо у s.Marks є хоча б 2 оцінки нижче 3 включно
                               select s; // то s записуєтся в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine(student);


        Console.ReadKey();
    }
}