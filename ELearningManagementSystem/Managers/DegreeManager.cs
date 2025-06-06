namespace ELearning;

//Controlls and manages logic for Degree
public class DegreeManager
{
    private UnitManager _unitManager;
    private List<Degree> _degrees = new List<Degree>();

    public DegreeManager(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    //Create new Degree and add to the Degree Manager's list of degrees
    public void CreateDegree()
    {
        Console.WriteLine("Create DegreeID");
        string degreeId = Console.ReadLine();

        Console.WriteLine("Choose Degree Name");
        string degreeName = Console.ReadLine();

        Degree newDegree = new Degree(degreeId, degreeName);

        AddDegree(newDegree);
        Console.WriteLine($"Degree added successfully.");
        newDegree.GetDegreeInfo();
    }

    //Used to add new degree to DegreeManager's list
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

    //Print all degrees
    public void ViewAllDegrees()
    {
        foreach (Degree d in _degrees)
        {
            d.GetDegreeInfo();
        }
    }

    //Used to add a unit to a degree's list of units.
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

    //Will remove a unit from a degree's list of units
    public void RemoveUnit(Degree degree, Unit unit)
    {
        if (degree == null || unit == null)
        {
            Console.WriteLine("Cannot remove unit");
        }

        if (degree.Units.Contains(unit))
        {
            degree.RemoveUnit(unit);
            Console.WriteLine($"Unit {unit.UnitCode} removed from {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine("Unit does not exist within degree");
        }
    }

    //Print all units within a degree
    public void ViewUnitsInDegree(Degree degree)
    {
        foreach (Unit u in degree.Units)
        {
            u.GetUnitInfo();
        }
    }

    //Enrol a student in a degree
    //This uses the UnitManager to ensure the student is also enrolled in the units with the degree.
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
            student.Degree = degree;
            //Use UnitManager to ensure All of the units within the degree are also added to the Students 'Unit' list
            foreach (Unit unit in degree.Units)
            {
                _unitManager.EnrolStudent(unit, student);
            }
            Console.WriteLine($"Student: {student.GetName()} added to {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine($"Student is already enrolled in {degree.DegreeId}");
        }
    }

    //Remove student from a degree, and ensure units are also removed
    public void UnenrolStudent(Degree degree, Student student)
    {
        if (degree == null || student == null)
        {
            Console.WriteLine("Student cannot be unenrolled");
            return;
        }

        if (degree.Students.Contains(student))
        {
            degree.RemoveStudent(student);
            student.Degree = null;
            Console.WriteLine($"Student: {student.GetName()} removed from {degree.DegreeId}");
        }
        else
        {
            Console.WriteLine($"Student is not enrolled in {degree.DegreeId}");
        }
    }

    //Print all students within a Degree's list of enrolled students
    public void ViewStudentsEnrolledInDegree(Degree degree)
    {
        foreach (Student s in degree.Students)
        {
            s.GetUserInfo();
        }
    }

    //Returns a degree given a valid Degree ID
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