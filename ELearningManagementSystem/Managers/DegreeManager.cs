namespace ELearning;

public class DegreeManager
{
    private List<Degree> _degrees = new List<Degree>();

    public void CreateDegree()
    {
        Console.WriteLine("Create DegreeID");
        string degreeId = Console.ReadLine();

        Console.WriteLine("Choose Degree Name");
        string degreeName = Console.ReadLine();

        Degree newDegree = new Degree(degreeId, degreeName);

        AddDegree(newDegree);
        Console.WriteLine($"Degree added successfully.");
        Console.WriteLine($"ID: {newDegree.DegreeId}");
        Console.WriteLine($"Degree name: {newDegree.DegreeName}");
    }

    public void AddDegree(Degree degree)
    {
        if (degree == null)
        {
            Console.WriteLine("Cannot add degree");
            return;
        }

        foreach (Degree d in _degrees)
        {
            if (d.DegreeId == degree.DegreeId)
            {
                Console.WriteLine("Degree with that Degree ID already exists");
                return;
            }
        }

        _degrees.Add(degree);
    
    }

    public void ViewAllDegrees()
    {
        foreach (Degree d in _degrees)
        {
            Console.WriteLine($"ID: {d.DegreeId}");
            Console.WriteLine($"Degree name: {d.DegreeName}\n");
        }
    }

    public void AddUnitsToDegree(Degree degree, Unit unit)
    {
        if (degree == null || unit == null)
        {
            Console.WriteLine("Cannot add unit");
            return;
        }

        if (!degree.Units.Contains(unit))
        {
            degree.AddUnit(unit);
            Console.WriteLine($"Unit {unit.UnitCode} added to degree {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine("Unit already exists within this degree");
        }
    }

    public void RemoveUnit(Degree degree, Unit unit)
    {
        if (degree == null || unit == null)
        {
            Console.WriteLine("Cannot remove unit");
        }

        if (!degree.Units.Contains(unit))
        {
            degree.RemoveUnit(unit);
            Console.WriteLine($"Unit {unit.UnitCode} removed from {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine("Unit does not exist within degree");
        }
    }

    public void ViewUnitsInDegree(Degree degree)
    {
        foreach (Unit u in degree.Units)
        {
            Console.WriteLine($"ID: {u.UnitCode}");
            Console.WriteLine($"Unit Name: {u.UnitTitle}\n");
        }

    }

    public void EnrolStudent(Degree degree, Student student)
    {
        if (degree == null || student == null)
        {
            Console.WriteLine("Student cannot be enrolled");
            return;
        }

        if (!degree.Students.Contains(student))
        {
            degree.AddStudent(student);
            Console.WriteLine($"Student {student.FirstName} {student.LastName} added to {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine($"Student is already enrolled in {degree.DegreeId}");
        }
    }

    public void UnenrolStudent(Degree degree, Student student)
    {
        if (degree == null || student == null)
        {
            Console.WriteLine("Student cannot be unenrolled");
            return;
        }

        if (!degree.Students.Contains(student))
        {
            degree.RemoveStudent(student);
            Console.WriteLine($"Student {student.FirstName} {student.LastName} removed from {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine($"Student is not enrolled in {degree.DegreeId}");
        }
    }

    public void ViewStudentsEnrolledInDegree(Degree degree)
    {
        foreach (Student s in degree.Students)
        {
            Console.WriteLine($"ID: {s.UserId}");
            Console.WriteLine($"First Name: {s.FirstName}");
            Console.WriteLine($"Last Name: {s.LastName}");
        }

    }

    public void RemoveDegree(Degree degree)
    {

    }

    public Degree FindDegree(string id)
    {
        foreach (Degree d in _degrees)
        {
            if (d.DegreeId.Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                return d;
            }
        }
        return null;

    }
    
}