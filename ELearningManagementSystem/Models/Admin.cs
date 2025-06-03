namespace ELearning;

public sealed class Admin : User
{
    //Access to manager instances 
    private UserManager _userManager;
    private DegreeManager _degreeManager;
    private UnitManager _unitManager;
    private TaskManager _taskManager;

    //Creating a single instance for the Singleton pattern
    private static Admin _instance = null;

    //Private admin constructor to prevent outside initialisation
    private Admin(string userId, string password, string firstName, string lastName, string email) : base(userId, password, firstName, lastName, email)
    {

    }


    //Creates Admin instance on access of Instance Property.
    public static Admin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Admin("admin", "admin", "System", "Admin", "admin@learning.com");
            }
            return _instance;
        }
    }

    //This is getting big.
    //If you have time. look into breaking things out into a MenuHandler class. Or AdminController
    public override void MainMenu()
    {


        bool finished = false;

        while (!finished)
        {
            Console.WriteLine("Admin menu ");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Degree");
            Console.WriteLine("3. Mangage Units");
            Console.WriteLine("4. Manage Tasks");
            Console.WriteLine("5. Logout");
            String input = Console.ReadLine();

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
                    ManageTasks();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }


    }

    public void ManageUsers()
    {
        bool userFinished = false;
        while (!userFinished)
        {
            Console.WriteLine("Manage Users Menu");
            Console.WriteLine("1. Create a User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Remove a User");
            Console.WriteLine("4. Return to Main Menu");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    _userManager.CreateUser();
                    break;
                case "2":
                    _userManager.ViewAllUsers();
                    break;
                case "3":
                    Console.WriteLine("Enter UserID to remove: ");
                    string userToDelete = Console.ReadLine(); 
                    _userManager.RemoveUserById(userToDelete);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

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
                    _degreeManager.CreateDegree();
                    break;
                case "2":
                    _degreeManager.ViewAllDegrees();
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

    public void SelectDegree()
    {
        Console.WriteLine("Enter Degree ID: ");
        string id = Console.ReadLine();
        Degree degree = _degreeManager.FindDegree(id);

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
            Console.WriteLine("7. Remove degree from system");
            Console.WriteLine("8. Return to Previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter a Unit ID");
                    string unitId = Console.ReadLine();
                    Unit unit = _unitManager.FindUnit(unitId);
                    if (unitId == null)
                    {
                        Console.WriteLine("Unit not found.");
                        return;
                    }
                    _degreeManager.AddUnitsToDegree(degree, unit);
                    break;
                case "2":
                    Console.WriteLine("Enter StudentID");
                    string studentId = Console.ReadLine();
                    User testStudent = _userManager.FindUser(studentId);
                    if (testStudent != null && testStudent is Student student)
                    {
                        _degreeManager.EnrolStudent(degree, student);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;
                case "3":
                    _degreeManager.ViewStudentsEnrolledInDegree(degree);
                    break;
                case "4":
                    _degreeManager.ViewUnitsInDegree(degree);
                    break;
                case "5":
                    Console.WriteLine("Enter Student ID");
                    string studId = Console.ReadLine();

                    User testStud = _userManager.FindUser(studId);

                    if (testStud != null && testStud is Student stud)
                    {
                        _degreeManager.UnenrolStudent(degree, stud);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;
                case "6":
                    Console.WriteLine("Enter Student ID");
                    string unitCode = Console.ReadLine();

                    Unit testUnit = _unitManager.FindUnit(unitCode);

                    if (testUnit == null)
                    {
                        Console.WriteLine("Unit not found");
                        return;
                    }
                    _degreeManager.RemoveUnit(degree, testUnit);
                    break;
                case "7":
                    Console.WriteLine("Are you sure? Enter admin username and password to confirm");
                    _degreeManager.RemoveDegree(degree);
                    break;

                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
    }


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
                    _unitManager.CreateUnit();
                    break;
                case "2":
                    _unitManager.ViewAllUnits();
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

    public void SelectUnit()
    {
        Console.WriteLine("Enter Unit Code: ");
        string code = Console.ReadLine();
        Unit unit = _unitManager.FindUnit(code);

        if (unit == null)
        {
            Console.WriteLine("Unit not found");
            return;
        }

        bool finished = false;

        while (!finished)
        {
            Console.WriteLine($"{unit.UnitCode} - {unit.UnitTitle}");
            Console.WriteLine("1. Add Tasks to Unit");
            Console.WriteLine("2. Enroll Student in Unit");
            Console.WriteLine("3. Assign Teacher to Unit");
            Console.WriteLine("4. View Students enrolled in unit");
            Console.WriteLine("5. View Teachers assigned to Unit");
            Console.WriteLine("6. Unenrol student from Unit");
            Console.WriteLine("7. Unassign teacher from Unit");
            Console.WriteLine("8. Remove Unit");
            Console.WriteLine("9. Return to previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _unitManager.AddTasksToUnit(unit);
                    break;
                case "2":
                    Console.WriteLine("Enter Student ID: ");
                    string studentId = Console.ReadLine();

                    User testStudent = _userManager.FindUser(studentId);

                    if (testStudent != null && testStudent is Student student)
                    {
                        _unitManager.EnrolStudent(unit, student);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;

                case "3":
                    Console.WriteLine("Enter Teacher ID: ");
                    string teacherId = Console.ReadLine();

                    User testTeacher = _userManager.FindUser(teacherId);

                    if (testTeacher != null && testTeacher is Teacher teacher)
                    {
                        _unitManager.AssignTeacher(unit, teacher);
                        break;
                    }
                    Console.WriteLine("Teacher not found.");
                    return;

                case "4":
                    _unitManager.ViewStudents(unit);
                    break;
                case "5":
                    _unitManager.ViewTeachers(unit);
                    break;
                case "6":
                    Console.WriteLine("Enter Student ID");
                    string studId = Console.ReadLine();

                    User testStud = _userManager.FindUser(studId);

                    if (testStud != null && testStud is Student stud)
                    {
                        _unitManager.UnenrolStudent(unit, stud);
                        break;
                    }
                    Console.WriteLine("Student not found");
                    return;
                case "7":
                    Console.WriteLine("Enter Teacher ID");
                    string teachId = Console.ReadLine();

                    User testTeach = _userManager.FindUser(teachId);

                    if (testTeach != null && testTeach is Teacher teach)
                    {
                        _unitManager.UnassignTeacher(unit, teach);
                        break;
                    }
                    Console.WriteLine("Teacher not found");
                    return;
                case "8":
                    _unitManager.RemoveUnit(unit);
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
    }

    public void ManageTasks()
    {

    }

    public void SetManagers(UserManager userManager, DegreeManager degreeManager, UnitManager unitManager, TaskManager taskManager)
    {
        _userManager = userManager;
        _degreeManager = degreeManager;
        _unitManager = unitManager;
        _taskManager = taskManager;
    }



}