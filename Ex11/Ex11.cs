using System;
using System.Linq;
using System.Collections.Generic;

class Ex11
{
    static void Main()
    {
        List<Student> students = new(); // студенти
        List<StudentSpeciality> specialities = new(); // спеціальності

        int index = 0; // 0 - запис спеціальностей, 0< - запис студентів
        while(true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування інформації

            if (action != null)
                if (action[0].ToLower() == "end") { Console.WriteLine(); break; } // завершення зчитування
                else
                {
                    if (action[0].ToLower() == "student" ||
                        action[0].ToLower() == "student:" ||
                        action[0].ToLower() == "students" ||
                        action[0].ToLower() == "students:") index++; // перехід на ввід студентів
                    else if (index == 0 && action.Length >= 2) // додавання спеціальності
                        specialities.Add(new StudentSpeciality(string.Join(' ', action[0..^1]), action[^1]));
                    else if (action.Length == 3) // додавання студента
                        students.Add(new Student(action[1], action[2], action[0]));
                }
        }

        var SelectedStudents = from s in students // береться значення з студентів
                               join ss in specialities // береться значення з спеціальностей
                               on s.FacultyNumber equals ss.FacultyNumber // критерії з'єднування
                               orderby s.FirstName // сортування за іменем студентів
                               select new // новий об'єкт
                               {
                                   s.FirstName, // ім'я
                                   s.LastName, // прізвище
                                   ss.FacultyNumber, // номер спеціальності
                                   ss.SpecialityName // назва спеціальності
                               };

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.FacultyNumber} {student.SpecialityName}");


        Console.ReadKey();
    }
}

record class Student(string FirstName, string LastName, string FacultyNumber);
record class StudentSpeciality(string SpecialityName, string FacultyNumber);