namespace ELearning;

//Handles Main Menu and Sub-Menu logic for Admin
public class AdminMenu
{
    private Admin _admin;

    public AdminMenu(Admin admin)
    {
        _admin = admin;
    }

    //Main Menu
    public void ShowMenu()
    {
        _admin.IsLoggedIn = true;
        while (_admin.IsLoggedIn)
        {
            Console.WriteLine("Admin menu ");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Degree");
            Console.WriteLine("3. Mangage Units");
            Console.WriteLine("4. Logout");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ManageUsers();
                    break;
                case "2":
                    ManageDegrees();
                    break;
                case "3":
                    ManageUnits();
                    break;
                case "4":
                    _admin.Logout();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

    //Main Menu option 1
    public void ManageUsers()
    {
        bool userFinished = false;
        while (!userFinished)
        {
            Console.WriteLine("Manage Users Menu");
            Console.WriteLine("1. Create a User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Return to Main Menu");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    _admin.UserManager.CreateUser();
                    break;
                case "2":
                    _admin.UserManager.ViewAllUsers();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    //Main Menu Option 2
    public void ManageDegrees()
    {
        bool degreeFinished = false;

        while (!degreeFinished)
        {
            Console.WriteLine("Manage Degrees");
            Console.WriteLine("1. Create Degree");
            Console.WriteLine("2. View Degrees");
            Console.WriteLine("3. Select Degree");
            Console.WriteLine("4. Return to Main Menu");
            string degreeChoice = Console.ReadLine();

            switch (degreeChoice)
            {
                case "1":
                    _admin.DegreeManager.CreateDegree();
                    break;
                case "2":
                    _admin.DegreeManager.ViewAllDegrees();
                    break;
                case "3":
                    SelectDegree();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
    }

    //Degrees Menu, Option 3 - Manage Individual Degree
    public void SelectDegree()
    {
        Console.WriteLine("Enter Degree ID: ");
        string id = Console.ReadLine();
        Degree degree = _admin.DegreeManager.FindDegree(id);

        if (degree == null)
        {
            Console.WriteLine("Degree not found");
            return;
        }

        bool finished = false;
        while (!finished)
        {
            Console.WriteLine($"{degree.DegreeId} - {degree.DegreeName}");
            Console.WriteLine("1. Add Units to Degree");
            Console.WriteLine("2. Enroll student in Degree");
            Console.WriteLine("3. View Students Enrolled in Degree");
            Console.WriteLine("4. View Units in Degree");
            Console.WriteLine("5. Unenrol a student from degree");
            Console.WriteLine("6. Remove a unit from degree");
            Console.WriteLine("7. Return to Previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter a Unit ID");
                    string unitId = Console.ReadLine();
                    Unit unit = _admin.UnitManager.FindUnit(unitId);
                    if (unit != null)
                    {
                        _admin.DegreeManager.AddUnitsToDegree(degree, unit);
                        break;
                    }
                    Console.WriteLine("Unit not found.");
                    return; 
                    
                case "2":
                    Console.WriteLine("Enter StudentID");
                    string studentId = Console.ReadLine();
                    User testStudent = _admin.UserManager.FindUser(studentId);
                    if (testStudent != null && testStudent is Student student)
                    {
                        _admin.DegreeManager.EnrolStudent(degree, student);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return; 

                case "3":
                    _admin.DegreeManager.ViewStudentsEnrolledInDegree(degree);
                    break;

                case "4":
                    _admin.DegreeManager.ViewUnitsInDegree(degree);
                    break;

                case "5":
                    Console.WriteLine("Enter Student ID");
                    string studId = Console.ReadLine();

                    User testStud = _admin.UserManager.FindUser(studId);

                    if (testStud != null && testStud is Student stud)
                    {
                        _admin.DegreeManager.UnenrolStudent(degree, stud);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;

                    
                case "6":
                    Console.WriteLine("Enter Unit Code");
                    string unitCode = Console.ReadLine();

                    Unit testUnit = _admin.UnitManager.FindUnit(unitCode);

                    if (testUnit != null)
                    {
                        _admin.DegreeManager.RemoveUnit(degree, testUnit);
                        break;
                    }
                    Console.WriteLine("Unit not found");
                    return;

                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
    }

    //Unit Menu Option 3 - Manage Units
    public void ManageUnits()
    {
        bool unitsFinished = false;

        while (!unitsFinished)
        {
            Console.WriteLine("Manage Units");
            Console.WriteLine("1. Create Unit");
            Console.WriteLine("2. View Units");
            Console.WriteLine("3. Select Unit");
            Console.WriteLine("4. Return to Main Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _admin.UnitManager.CreateUnit();
                    break;
                case "2":
                    _admin.UnitManager.ViewAllUnits();
                    break;
                case "3":
                    SelectUnit();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    //Unit Menu - Ooption 3 - Manage Single Unit
    public void SelectUnit()
    {
        Console.WriteLine("Enter Unit Code: ");
        string code = Console.ReadLine();
        Unit unit = _admin.UnitManager.FindUnit(code);

        if (unit == null)
        {
            Console.WriteLine("Unit not found");
            return;
        }

        bool finished = false;

        while (!finished)
        {
            Console.WriteLine($"{unit.UnitCode} - {unit.UnitTitle}");
            Console.WriteLine("1. Manage tasks for Unit");
            Console.WriteLine("2. Enroll Student in Unit");
            Console.WriteLine("3. Assign Teacher to Unit");
            Console.WriteLine("4. View Students enrolled in unit");
            Console.WriteLine("5. View Teachers assigned to Unit");
            Console.WriteLine("6. Unenrol student from Unit");
            Console.WriteLine("7. Unassign teacher from Unit");
            Console.WriteLine("8. Return to previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageTasks(unit);
                    break;
                case "2":
                    Console.WriteLine("Enter Student ID: ");
                    string studentId = Console.ReadLine();

                    User testStudent = _admin.UserManager.FindUser(studentId);

                    if (testStudent != null && testStudent is Student student)
                    {
                        _admin.UnitManager.EnrolStudent(unit, student);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;

                case "3":
                    Console.WriteLine("Enter Teacher ID: ");
                    string teacherId = Console.ReadLine();

                    User testTeacher = _admin.UserManager.FindUser(teacherId);

                    if (testTeacher != null && testTeacher is Teacher teacher)
                    {
                        _admin.UnitManager.AssignTeacher(unit, teacher);
                        break;
                    }
                    Console.WriteLine("Teacher not found.");
                    return;

                case "4":
                    _admin.UnitManager.ViewStudents(unit);
                    break;
                case "5":
                    _admin.UnitManager.ViewTeachers(unit);
                    break;
                case "6":
                    Console.WriteLine("Enter Student ID");
                    string studId = Console.ReadLine();

                    User testStud = _admin.UserManager.FindUser(studId);

                    if (testStud != null && testStud is Student stud)
                    {
                        _admin.UnitManager.UnenrolStudent(unit, stud);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;
                case "7":
                    Console.WriteLine("Enter Teacher ID");
                    string teachId = Console.ReadLine();

                    User testTeach = _admin.UserManager.FindUser(teachId);

                    if (testTeach != null && testTeach is Teacher teach)
                    {
                        _admin.UnitManager.UnassignTeacher(unit, teach);
                        break;
                    }
                    Console.WriteLine("Teacher not found");
                    return;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
    }

    //Select unit submenu - Manage Tasks
    public void ManageTasks(Unit unit)
    {
        bool finished = false;

        while (!finished)
        {
            Console.WriteLine($"Managing tasks for {unit.UnitTitle}");
            Console.WriteLine("1. View all tasks for unit");
            Console.WriteLine("2. Add task to unit");
            Console.WriteLine("3. Return to previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _admin.TaskManager.ViewTasks(unit);
                    break;
                case "2":
                    _admin.TaskManager.CreateTask(unit);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

}