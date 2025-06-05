namespace ELearning;

public class Degree
{
    private string _degreeId;
    private string _degreeName;
    private List<Unit> _units;
    private List<Student> _students;

    //Degrees could have faculties, this could be an enum
    //If you have time?

    public string DegreeId
    {
        get { return _degreeId; }
        set { _degreeId = value; }
    }
    public string DegreeName
    {
        get { return _degreeName; }
        set { _degreeName = value; }
    }
    public List<Unit> Units
    {
        get { return _units; }
    }
    //public list bad
    public List<Student> Students
    {
        get { return _students; }
    }

    public Degree(string degreeId, string degreeName)
    {
        _degreeId = degreeId;
        _degreeName = degreeName;
        _units = new List<Unit>();
        _students = new List<Student>();
    }

    public void GetDegreeInfo()
    {
        Console.WriteLine($"Degree ID: {DegreeId}");
        Console.WriteLine($"Name: {DegreeName}\n");
    }

    public void AddUnit(Unit unit)
    {
        if (!_units.Contains(unit))
        {
            _units.Add(unit);
        }
    }

    public void RemoveUnit(Unit unit)
    {
        if (!_units.Contains(unit))
        {
            _units.Remove(unit);
        }
    }

    public void AddStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            _students.Add(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            _students.Remove(student);
        }
    }
}