namespace ELearning;

public class TeacherMenu
{
    private Teacher _teacher;

    public TeacherMenu(Teacher teacher)
    {
        _teacher = teacher;
    }

    public void ShowMenu()
    {
        bool finished = false;

        //Main Menu loop
        while (!finished)
        {
            Console.WriteLine("Teacher Menu:");
            Console.WriteLine("1. Manage Units");
            Console.WriteLine("2. Change Password");
            Console.WriteLine("3. Logout");
            String input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UnitMenu();
                    break;
                case "2":
                    _teacher.ChangePassword();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }

    public void UnitMenu()
    {
        if (_teacher.TeachingUnits.Any())
        {
            Console.WriteLine("You are teaching these units:");
            foreach (Unit u in _teacher.TeachingUnits)
            {
                Console.WriteLine($"{u.UnitCode} - {u.UnitTitle}");
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
                }
            }
        }
        else
        {
            Console.WriteLine("You are not teaching any units");
            return;
        }

    }

    public void ManageUnit(Unit unit)
    {
        bool finished = false;
        while (!finished)
        {
            Console.WriteLine($"{unit.UnitCode} - {unit.UnitTitle}");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Return to Previous Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageStudents(unit);
                    break;
                case "2":
                    return;
            }
        }
    }

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
                    Console.WriteLine($"{s.FirstName} {s.LastName} ({s.UserId})\n");
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
                            SelectStudent(unit, student);
                        }
                        else
                        {
                            Console.WriteLine("Could not find student");
                        }
                        break;
                    case "2":
                        finished = true;
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

    //View pending tasks
    //View submitted tasks
    //View ungraded tasks
    //View graded tasks 
    //Grade task
    //Overall grade?
    public void SelectStudent(Unit unit, Student student)
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
                    Console.WriteLine($"Pending tasks for {student.FirstName} {student.LastName}: ");
                    foreach (Task task in student.PendingTasks)
                    {
                        Console.WriteLine($"Task ID: {task.TaskId}: ");
                        Console.WriteLine($"{task.TaskName}\n");
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
                    Console.WriteLine($"Submitted tasks for {student.FirstName} {student.LastName}");
                    foreach (Task task in student.SubmittedTasks)
                    {
                        Console.WriteLine($"Task ID: {task.TaskId}: ");
                        Console.WriteLine($"{task.TaskName}\n");
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
                        Console.WriteLine($"Task ID: {task.TaskId}: ");
                        Console.WriteLine($"{task.TaskName}\n");
                        Console.WriteLine($"Total Mark {task.TotalMark}");
                    }
                }

                break;
            case "4":
                foreach (Task task in student.SubmittedTasks)
                {
                    if (task.Graded)
                    {
                        Console.WriteLine($"Task ID: {task.TaskId}: ");
                        Console.WriteLine($"{task.TaskName}\n");
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
                    Console.WriteLine("Enter mark");
                    double mark = Convert.ToDouble(Console.ReadLine());
                    taskToGrade.GradeTask(mark);
                    Console.WriteLine("Task graded successfully.");
                }
                else
                {
                    Console.WriteLine("Task cannot be graded");
                }
                break;
            case "6":
                return;

        }

    }

}