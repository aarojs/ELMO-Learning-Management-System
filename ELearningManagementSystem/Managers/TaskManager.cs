namespace ELearning;

//Controls and manages logic for Tasks
//Implements Factory pattern to Create task (TaskFactory)
public class TaskManager
{

    private List<Task> _tasks = new List<Task>();

    //Create a new Task, once validated and created, adds to list of tasks
    public void CreateTask(Unit unit)
    {
        Console.WriteLine("Choose task type: 1. Assignment, 2. Quiz, 3. Exam");
        string choice = Console.ReadLine();

        Console.WriteLine("Enter Task ID: ");
        string taskId = Console.ReadLine();

        Console.WriteLine("Enter Task Name: ");
        string taskName = Console.ReadLine();

        //Ensure valid DateTime 
        //Without this, exception was raised. 
        DateTime dueDate;
        while (true)
        {
            Console.WriteLine("Enter Due Date (yyyy-mm-dd): ");
            string input = Console.ReadLine();

            //Checking for Valid DateTime
            if (DateTime.TryParseExact(input, "yyyy-mm-dd",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out dueDate))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid date entered. Please match the format of 'yyyy-mm-dd");
            }
        }

        //Valiate double
        double totalMark;
        while (true)
        {
            Console.WriteLine("Enter Total Mark: ");
            string totalMarkStr = Console.ReadLine();
            if (double.TryParse(totalMarkStr, out totalMark))
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }

        Task newTask = null;
        switch (choice)
        {
            case "1":
                Console.WriteLine("Description: ");
                string desc = Console.ReadLine();

                //Declare and validate integer 
                int min;
                while (true)
                {
                    Console.WriteLine("Min Words: ");
                    string minStr = Console.ReadLine();
                    if (int.TryParse(minStr, out min))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer. Please enter a valid whole number");
                    }
                }

                //Declare and validate integer
                int max;
                while (true)
                {
                    Console.WriteLine("Max Words: ");
                    string maxStr = Console.ReadLine();
                    if (int.TryParse(maxStr, out max))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer. Please enter a valid whole number");
                    }
                }

                AssignmentParams ap = new AssignmentParams { Description = desc, MinWords = min, MaxWords = max };
                newTask = TaskFactory.CreateAssignment(taskId, taskName, dueDate, totalMark, unit, ap);
                break;

            case "2":
                int numQ;
                while (true)
                {
                    Console.WriteLine("Number of Questions :");
                    string numQStr = Console.ReadLine();
                    if (int.TryParse(numQStr, out numQ))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer, please enter a valid whole number");
                    }
                }

                //Declare and validate bool
                bool online;
                while (true)
                {
                    Console.WriteLine("Is Online (true/false): ");
                    string onlineStr = Console.ReadLine();
                    if (bool.TryParse(onlineStr, out online))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please answer 'true' or 'false'");
                    }
                }

                QuizParams qp = new QuizParams { NumberOfQuestions = numQ, IsOnline = online };
                newTask = TaskFactory.CreateQuiz(taskId, taskName, dueDate, totalMark, unit, qp);
                break;

            case "3":
                //Validate int
                int duration;
                while (true)
                {
                    Console.WriteLine("Duration in Minutes: ");
                    string durationStr = Console.ReadLine();
                    if (int.TryParse(durationStr, out duration))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a whole number");
                    }
                }

                bool openBook;
                while (true)
                {
                    Console.WriteLine("Is Open Book (true/false): ");
                    string openBookStr = Console.ReadLine();
                    if (bool.TryParse(openBookStr, out openBook))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'true' or 'false'");
                    }
                }

                Console.WriteLine("Location: ");
                string location = Console.ReadLine();

                ExamParams ep = new ExamParams { ExamDurationMins = duration, IsOpenBook = openBook, ExamLocation = location };
                newTask = TaskFactory.CreateExam(taskId, taskName, dueDate, totalMark, unit, ep);
                break;
        }
        if (newTask != null)
        {
            AddTasksToUnit(unit, newTask);
            newTask.DisplayTaskInfo();
        }  
    }

    //Print all tasks
    public void ViewTasks(Unit unit)
    {
        foreach (Task task in unit.Tasks)
        {
            task.DisplayTaskInfo();
        }
    }

    //Find a task given a valid Task ID
    public Task FindTask(string id)
    {
        foreach (Task task in _tasks)
        {
            if (task.TaskId.Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                return task;
            }
        }
        return null;
    }

    //Assign a task to a student, adding it to their list of Pending Tasks
    public void AssignTaskToStudent(Task task, Student student)
    {
        if (!student.PendingTasks.Contains(task))
        {
            student.AddPendingTask(task);
            Console.WriteLine($"Task {task.TaskName} assigned to {student.GetName()}");
        }
        else
        {
            Console.WriteLine("Task is already assigned to student");
        }
    }


    //Add a task to a Unit's list of Tasks.
    public void AddTasksToUnit(Unit unit, Task task)
    {
        if (unit == null || task == null)
        {
            Console.WriteLine("Task is invalid");
            return;
        }
        if (!unit.Tasks.Contains(task))
        {
            unit.AddTask(task);
            _tasks.Add(task);
            Console.WriteLine($"{task.TaskName} added to {unit.UnitTitle}");
            foreach (Student student in unit.EnrolledStudents)
            {
                student.AddPendingTask(task);
                Console.WriteLine($"{task.TaskId} added for {student.GetName()}");
            }
        }
    }
}
