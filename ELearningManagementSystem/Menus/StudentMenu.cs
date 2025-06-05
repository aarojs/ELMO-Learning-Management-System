namespace ELearning;

public class StudentMenu
{
    private Student _student;

    public StudentMenu(Student student)
    {
        _student = student;
    }
    public void ShowMenu()
    {
        _student.IsLoggedIn = true;
        while (_student.IsLoggedIn)
        {
            Console.WriteLine("Student Menu:");
            Console.WriteLine("1. View Units");
            Console.WriteLine("2. Change password");
            Console.WriteLine("3. Logout");

            String choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    UnitMenu();
                    break;
                case "2":
                    _student.ChangePassword();
                    break;
                case "3":
                    _student.Logout();
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    public void UnitMenu()
    {
        if (_student.EnrolledUnits.Any())
        {
            Console.WriteLine("Enrolled Units:");
            foreach (Unit u in _student.EnrolledUnits)
            {
                Console.WriteLine($"{u.UnitCode} - {u.UnitTitle}");
            }
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
                    Unit unit = _student.UnitManager.FindUnit(unitId);
                    
                    if (unit != null && _student.EnrolledUnits.Contains(unit))
                    {
                        ManageUnit(unit);
                        break;
                    }
                    Console.WriteLine("Unit not found");
                    break;
                case "2":
                    return;
            }
        }
    }

    public void ManageUnit(Unit unit)
    {
        bool finished = false;
        while (!finished)
        {
            Console.WriteLine($"{unit.UnitCode} - {unit.UnitTitle}");
            Console.WriteLine("1. View pending tasks");
            Console.WriteLine("2. View Submitted tasks");
            Console.WriteLine("3. Submit a task");
            Console.WriteLine("4. Return to previous menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool tasksPending = false;

                    foreach (Task task in _student.PendingTasks)
                    {
                        if (unit == task.ParentUnit)
                        {
                            task.DisplayTaskInfo();
                            tasksPending = true;
                        }
                    }
                    if (!tasksPending)
                    {
                        Console.WriteLine("No pending tasks for this unit");
                    }
                    break;

                case "2":
                    bool submittedTasks = false;

                    foreach (Task task in _student.SubmittedTasks)
                    {
                        if (unit == task.ParentUnit)
                        {
                            task.DisplayTaskInfo();
                            Console.WriteLine($"Grade: {task.GetGrade()}");
                            if (task.Graded)
                            {
                                Console.WriteLine("Task has been graded");
                            }
                            else
                            {
                                Console.WriteLine("Task has not been graded.");
                            }
                            submittedTasks = true;
                        }
                    }
                    if (!submittedTasks)
                    {
                        Console.WriteLine("No submitted tasks for this unit");
                    }
                    break;

                case "3":
                    Console.WriteLine("Enter task ID");
                    string taskId = Console.ReadLine();
                    Task taskToSubmit = _student.TaskManager.FindTask(taskId);

                    //Testing
                    Console.WriteLine();

                    if (taskToSubmit != null && taskToSubmit is ISubmittable submittableTask)
                    {
                        submittableTask.Submit();
                        _student.RemovePendingTask(taskToSubmit);
                        _student.AddSubmittedTask(taskToSubmit);
                        Console.WriteLine($"{taskToSubmit.TaskName} successfully submitted");
                    }
                    else
                    {
                        Console.WriteLine("Task not submitted");
                    }
                    break;
                case "4":
                    return;
            }
        }
    }
}