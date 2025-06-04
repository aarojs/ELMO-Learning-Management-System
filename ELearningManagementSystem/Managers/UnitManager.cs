namespace ELearning;

public class UnitManager
{
    private List<Unit> _units = new List<Unit>();

    public void CreateUnit()
    {
        Console.WriteLine("Create Unit ID");
        string unitId = Console.ReadLine();

        Console.WriteLine("Create Unit Title");
        string unitTitle = Console.ReadLine();

        Unit newUnit = new Unit(unitId, unitTitle);

        AddUnit(newUnit);
        Console.WriteLine("Unit Created Successfully.");
    }

    public void AddUnit(Unit unit)
    {
        if (unit == null)
        {
            Console.WriteLine("Cannot create unit");
            return;
        }

        foreach (Unit u in _units)
        {
            if (u.UnitCode == unit.UnitCode)
            {
                Console.WriteLine("Unit with that Unit Code already exists. Cannot create unit");
                return;
            }
        }

        _units.Add(unit);
    }

    public void ViewAllUnits()
    {
        foreach (Unit u in _units)
        {
            Console.WriteLine($"ID: {u.UnitCode}");
            Console.WriteLine($"Unit Name: {u.UnitTitle}\n");
        }
    }




    public void EnrolStudent(Unit unit, Student student)
    {
        if (unit == null || student == null)
        {
            Console.WriteLine("Student cannot be enrolled");
            return;
        }
        if (!unit.EnrolledStudents.Contains(student))
        {
            unit.AddStudent(student);
            
            Console.WriteLine($"Student {student.FirstName} {student.LastName} added to {unit.UnitCode}");
        }
        if (!student.EnrolledUnits.Contains(unit))
        {
            student.AddUnit(unit);
            //Add all tasks within Unit to Student's task list
            foreach (Task task in unit.Tasks)
            {
                student.AddPendingTask(task);
            }
            Console.WriteLine($"Unit successfully added to Student's enrollment");
        }
        else
        {
            Console.WriteLine($"Student is already enrolled in {unit.UnitCode}");
        }
    }

    public void UnenrolStudent(Unit unit, Student student)
    {
        if (unit == null || student == null)
        {
            Console.WriteLine("Student cannot be unenrolled");
            return;
        }

        if (!unit.EnrolledStudents.Contains(student))
        {
            unit.RemoveStudent(student);
            Console.WriteLine($"Student {student.FirstName} {student.LastName} removed from {unit.UnitTitle}");
        }
        if (!student.EnrolledUnits.Contains(unit))
        {
            student.RemoveUnit(unit);
            //Remove tasks 
            foreach (Task task in student.PendingTasks)
            {
                student.RemovePendingTask(task);
            }
            foreach (Task task in student.SubmittedTasks)
            {
                student.RemoveSubmittedTask(task);
            }
            Console.WriteLine("Unit and corresponding tasks successfully removed from Student's file.");
        }
        else
        {
            Console.WriteLine($"Student is not enrolled in {unit.UnitCode}");
        }
    }

    public void ViewStudents(Unit unit)
    {
        foreach (Student s in unit.EnrolledStudents)
        {
            Console.WriteLine($"ID: {s.UserId}");
            Console.WriteLine($"First Name: {s.FirstName}");
            Console.WriteLine($"Last Name: {s.LastName}");
        }

    }
    public void AssignTeacher(Unit unit, Teacher teacher)
    {
        if (unit == null || teacher == null)
        {
            Console.WriteLine("Cannot assign teacher");
            return;
        }

        if (!unit.Teachers.Contains(teacher))
        {
            unit.AddTeacher(teacher);
            Console.WriteLine($"Teacher {teacher.FirstName} {teacher.LastName} assigned to unit {unit.UnitCode}");
        }
        if (!teacher.TeachingUnits.Contains(unit))
        {
            teacher.AddUnit(unit);
            Console.WriteLine("Unit successfully added to Teacher's schedule");
        }
        else
        {
            Console.WriteLine("Teacher already assigned to this unit");
        }
    }

    public void UnassignTeacher(Unit unit, Teacher teacher)
    {
        if (unit == null || teacher == null)
        {
            Console.WriteLine("Cannot unassign teacher");
            return;
        }

        if (!unit.Teachers.Contains(teacher))
        {
            unit.RemoveTeacher(teacher);
            Console.WriteLine($"Teacher {teacher.FirstName} {teacher.LastName} removed from {unit.UnitCode}");
        }
        else
        {
            Console.WriteLine("Teacher is not assigned to this unit");
        }
    }

    public void ViewTeachers(Unit unit)
    {
        foreach (Teacher t in unit.Teachers)
        {
            Console.WriteLine($"ID: {t.UserId}");
            Console.WriteLine($"First Name: {t.FirstName}");
            Console.WriteLine($"Last Name: {t.LastName} ");
            Console.WriteLine($"Role: {t.Role}");
        }

    }

    public void RemoveUnit(Unit unit)
    {

    }

    public Unit FindUnit(string unitCode)
    {
        foreach (Unit u in _units)
        {
            if (u.UnitCode.Equals(unitCode, StringComparison.OrdinalIgnoreCase))
            {
                return u;
            }
        }
        return null;

    }
}