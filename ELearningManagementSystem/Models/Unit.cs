namespace ELearning;

public class Unit
{
    private string _unitCode;
    private string _unitTitle;
    private List<Teacher> _teachers;
    private List<Student> _enrolledStudents;
    private List<Task> _tasks;

    public string UnitCode
    {
        get { return _unitCode; }
        set { _unitCode = value; }
    }
    public string UnitTitle
    {
        get { return _unitTitle; }
        set { _unitCode = value; }
    }
    public List<Teacher> Teachers
    {
        get { return _teachers; }
    }
    public List<Student> EnrolledStudents
    {
        get { return _enrolledStudents; }
    }
    public List<Task> Tasks
    {
        get { return _tasks; }
    }


    public Unit(string unitCode, string UnitTitle)
    {
        _unitCode = unitCode;
        _unitTitle = UnitTitle;

        _teachers = new List<Teacher>();
        _enrolledStudents = new List<Student>();
        _tasks = new List<Task>();
    }

    public void GetUnitInfo()
    {
        Console.WriteLine($"Unit ID: {UnitCode}");
        Console.WriteLine($"Name: {UnitTitle}\n");
    }

    public void AddStudent(Student student)
    {
        if (!_enrolledStudents.Contains(student))
        {
            _enrolledStudents.Add(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        if (_enrolledStudents.Contains(student))
        {
            _enrolledStudents.Remove(student);
        }
    }

    public void AddTeacher(Teacher teacher)
    {
        if (!_teachers.Contains(teacher))
        {
            _teachers.Add(teacher);
        }
    }

    public void RemoveTeacher(Teacher teacher)
    {
        if (_teachers.Contains(teacher))
        {
            _teachers.Remove(teacher);
        }
    }

    public void AddTask(Task task)
    {
        if (!_tasks.Contains(task))
        {
            _tasks.Add(task);
        }
    }
}