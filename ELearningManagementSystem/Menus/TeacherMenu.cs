namespace ELearning;

public class TeacherMenu
{
    private Teacher _teacher;

    public TeacherMenu(Teacher teacher)
    {
        _teacher = teacher;
    }

    //Main Menu
    public void ShowMenu()
    {
        //Main Menu loop
        _teacher.IsLoggedIn = true;
        while (_teacher.IsLoggedIn)
        {
            Console.WriteLine("Teacher Menu:");
            Console.WriteLine("1. Manage Units");
            Console.WriteLine("2. Change Password");
            Console.WriteLine("3. Logout");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UnitMenu();
                    break;
                case "2":
                    _teacher.ChangePassword();
                    break;
                case "3":
                    _teacher.Logout();
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    //Teacher Unit menu
    public void UnitMenu()
    {
        if (_teacher.TeachingUnits.Any())
        {
            Console.WriteLine("You are teaching these units:");
            foreach (Unit u in _teacher.TeachingUnits)
            {
                u.GetUnitInfo();
            }

            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("1. Select Unit");
                Console.WriteLine("2. Return to previous menu");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Unit ID");
                        string unitId = Console.ReadLine();
                        Unit unit = _teacher.UnitManager.FindUnit(unitId);
                        if (unit != null && _teacher.TeachingUnits.Contains(unit))
                        {
                            ManageUnit(unit);
                        }
                        else
                        {
                            Console.WriteLine("Unit not found.");
                        }
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("You are not teaching any units");
            return;
        }

    }

    //Manage a selected unit menu
    public void ManageUnit(Unit unit)
    {
        bool finished = false;
        while (!finished)
        {
            unit.GetUnitInfo();
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. View tasks for unit");
            Console.WriteLine("3. Add task to unit");
            Console.WriteLine("4. Return to Previous Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageStudents(unit);
                    break;
                case "2":
                    _teacher.TaskManager.ViewTasks(unit);
                    break;
                case "3":
                    _teacher.TaskManager.CreateTask(unit);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    //View all students, and choose to select a student to manage
    public void ManageStudents(Unit unit)
    {
        bool finished = false;
        while (!finished)
        {
            if (unit.EnrolledStudents.Any())
            {
                Console.WriteLine($"Students enrolled in {unit.UnitTitle}:");
                foreach (Student s in unit.EnrolledStudents)
                {
                    s.GetUserInfo();
                }
                Console.WriteLine("1. Select student");
                Console.WriteLine("2. Return to previous menu");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Student ID");
                        string studentId = Console.ReadLine();
                        User user = _teacher.UserManager.FindUser(studentId);
                        if (user != null && user is Student student)
                        {
                            SelectStudent(student);
                        }
                        else
                        {
                            Console.WriteLine("Could not find student");
                        }
                        break;
                    case "2":
                        finished = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no students enrolled in this unit yet");
                break;
            }
        }
    }

    //Manage a selected student, their tasks and grading
    public void SelectStudent(Student student)
    {
        bool finished = false;
        while (!finished)
        {

            Console.WriteLine($"Task Portal for {student.FirstName} {student.LastName}");
            Console.WriteLine("1. View Pending Tasks");
            Console.WriteLine("2. View Submitted Tasks");
            Console.WriteLine("3. View Ungraded tasks");
            Console.WriteLine("4. View Graded Tasks");
            Console.WriteLine("5. Grade task");
            Console.WriteLine("6. Return to previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (student.PendingTasks.Any())
                    {
                        Console.WriteLine($"Pending tasks for {student.GetName}: ");
                        foreach (Task task in student.PendingTasks)
                        {
                            task.DisplayTaskInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pending tasks for this student");
                    }
                    break;


                case "2":
                    if (student.SubmittedTasks.Any())
                    {
                        Console.WriteLine($"Submitted tasks for {student.GetName}");
                        foreach (Task task in student.SubmittedTasks)
                        {
                            task.DisplayTaskInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No submitted tasks for this student");
                    }
                    break;

                case "3":
                    foreach (Task task in student.SubmittedTasks)
                    {
                        if (!task.Graded)
                        {
                            task.DisplayTaskInfo();
                            Console.WriteLine($"Total Mark {task.TotalMark}");
                        }
                    }

                    break;
                case "4":
                    foreach (Task task in student.SubmittedTasks)
                    {
                        if (task.Graded)
                        {
                            task.DisplayTaskInfo();
                            Console.WriteLine($"Mark {task.AchievedMark} / {task.TotalMark}");
                        }
                    }
                    break;

                case "5":
                    Console.WriteLine("Enter task ID");
                    string taskId = Console.ReadLine();
                    Task taskToGrade = _teacher.TaskManager.FindTask(taskId);
                    if (taskToGrade != null && !taskToGrade.Graded)
                    {
                        //Validate grade entered
                        double mark;
                        while (true)
                        {
                            Console.WriteLine("Enter mark");
                            string markStr = Console.ReadLine();
                            if (double.TryParse(markStr, out mark))
                            {
                                //Grade task if double input is valid.
                                //GradeTask checks if mark is within total score range
                                if (taskToGrade.GradeTask(mark))
                                {
                                    Console.WriteLine("Task graded successfully.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid mark. Please enter a mark within 0 and {taskToGrade.TotalMark}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid grade");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Task not found, or is already graded");
                    }
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }
    }
}