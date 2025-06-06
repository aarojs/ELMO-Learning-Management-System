namespace ELearning;

//Controls and manages logic for units
public class UnitManager
{
    private List<Unit> _units = new List<Unit>();

    //Create a new unit, and adds to the list of units
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

    //Print all units
    public void ViewAllUnits()
    {
        foreach (Unit u in _units)
        {
            u.GetUnitInfo();
        }
    }


    //Enrol student in Unit, ensuring all tasks within a unit are added to the students list of tasks
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

            Console.WriteLine($"Student: {student.GetName()} added to {unit.UnitCode}");
        }
        if (!student.EnrolledUnits.Contains(unit))
        {
            student.AddUnit(unit);
            //Add all tasks within Unit to Student's task list
            foreach (Task task in unit.Tasks)
            {
                student.AddPendingTask(task);
            }
            Console.WriteLine($"Unit {unit.UnitTitle} successfully added to Student's enrollment");
        }
        else
        {
            Console.WriteLine($"Student is already enrolled in {unit.UnitCode}");
        }
    }

    //Unenrol student, removing it from their list of units along with its associated tasks
    public void UnenrolStudent(Unit unit, Student student)
    {
        if (unit == null || student == null)
        {
            Console.WriteLine("Student cannot be unenrolled");
            return;
        }

        if (unit.EnrolledStudents.Contains(student))
        {
            unit.RemoveStudent(student);
            Console.WriteLine($"Student: {student.GetName()} removed from {unit.UnitTitle}");
        }
        if (student.EnrolledUnits.Contains(unit))
        {
            student.RemoveUnit(unit);
            //Remove tasks, iterate over list before removing.
            foreach (Task task in student.PendingTasks.ToList())
            {
                student.RemovePendingTask(task);
            }
            foreach (Task task in student.SubmittedTasks.ToList())
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

    //Print all students enrolled in a unit
    public void ViewStudents(Unit unit)
    {
        foreach (Student s in unit.EnrolledStudents)
        {
            s.GetUserInfo();
        }

    }

    //Assign a teacher to the unit, adding it to the unit's list of teachers, and the teacher's list of units
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
            Console.WriteLine($"Teacher: {teacher.GetName()} assigned to unit {unit.UnitCode}");
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

    //Removes a teacher from the list of units, and removes the unit from the teacher's list
    public void UnassignTeacher(Unit unit, Teacher teacher)
    {
        if (unit == null || teacher == null)
        {
            Console.WriteLine("Cannot unassign teacher");
            return;
        }

        if (unit.Teachers.Contains(teacher))
        {
            unit.RemoveTeacher(teacher);
            Console.WriteLine($"Teacher: {teacher.GetName()} removed from {unit.UnitCode}");
        }
        if (teacher.TeachingUnits.Contains(unit))
        {
            teacher.RemoveUnit(unit);
            Console.WriteLine("Unit successfully removed from Teacher's unit list.");
        }
        else
        {
            Console.WriteLine("Teacher is not assigned to this unit");
        }
    }

    //View all assigned teachers for a given unit
    public void ViewTeachers(Unit unit)
    {
        foreach (Teacher t in unit.Teachers)
        {
            t.GetUserInfo();
        }

    }

    //Find a unit given a valid unit ID
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