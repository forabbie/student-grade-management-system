namespace student_grade_management_system;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, double> Grades { get; set; } = new Dictionary<string, double>();

    public void AddGrade(string subject, double grade)
    {
        Grades[subject] = grade;
    }

    public double CalculateAverage()
    {
        if (Grades.Count == 0)
            return 0;

        double total = 0;
        foreach (var grade in Grades.Values)
        {
            total += grade;
        }
        return total / Grades.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Average Grade: {CalculateAverage():F2}");
        Console.WriteLine("Grades:");
        foreach (var entry in Grades)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value}");
        }
    }
}

class StudentManager
{
    private Dictionary<int, Student> students = new Dictionary<int, Student>();

    public void AddStudent(int id, string name)
    {
        if (students.ContainsKey(id))
        {
            Console.WriteLine("Student ID already exists!");
            return;
        }
        students[id] = new Student { Id = id, Name = name };
        Console.WriteLine("Student added successfully.");
    }

    public void AssignGrade(int id, string subject, double grade)
    {
        if (students.ContainsKey(id))
        {
            students[id].AddGrade(subject, grade);
            Console.WriteLine("Grade assigned successfully.");
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    public void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }
        foreach (var student in students.Values)
        {
            student.DisplayInfo();
            Console.WriteLine("----------------------------------");
        }
    }
}


class Program
{
    static void Main()
    {
        StudentManager manager = new StudentManager();

        while (true)
        {
            Console.WriteLine("\nStudent Grade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Assign Grade");
            Console.WriteLine("3. Display Students");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Student ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();
                    manager.AddStudent(id, name);
                    break;
                case "2":
                    Console.Write("Enter Student ID: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Subject: ");
                    string subject = Console.ReadLine();
                    Console.Write("Enter Grade: ");
                    double grade = double.Parse(Console.ReadLine());
                    manager.AssignGrade(id, subject, grade);
                    break;
                case "3":
                    manager.DisplayStudents();
                    break;
                case "4":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }
}
