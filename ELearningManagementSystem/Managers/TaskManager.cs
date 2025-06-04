namespace ELearning;

public class TaskManager
{
    private List<Task> _tasks = new List<Task>();


    //Look back over this what are we even doing here
    public void CreateTask(Unit unit)
    {
        Console.WriteLine("Choose task type: 1. Assignment, 2. Quiz, 3. Exam");
        string choice = Console.ReadLine();

        Console.WriteLine("Enter Task ID: ");
        string taskId = Console.ReadLine();

        Console.WriteLine("Enter Task Name: ");
        string taskName = Console.ReadLine();

        Console.WriteLine("Enter Due Date (yyyy-mm-dd): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Total Mark: ");
        double totalMark = double.Parse(Console.ReadLine());

        Task newTask = null;

        switch (choice)
        {
            case "1":
                Console.WriteLine("Description: ");
                string desc = Console.ReadLine();

                Console.WriteLine("Min Words: ");
                int min = int.Parse(Console.ReadLine());

                Console.WriteLine("Max Words: ");
                int max = int.Parse(Console.ReadLine());

                AssignmentParams ap = new AssignmentParams { Description = desc, MinWords = min, MaxWords = max };
                newTask = TaskFactory.CreateAssignment(taskId, taskName, dueDate, totalMark, unit, ap);
                break;

            case "2":
                Console.WriteLine("Number of Questions: ");
                int numQ = int.Parse(Console.ReadLine());

                Console.WriteLine("Is Online (true/false): ");
                bool online = bool.Parse(Console.ReadLine());

                QuizParams qp = new QuizParams { NumberOfQuestions = numQ, IsOnline = online };
                newTask = TaskFactory.CreateQuiz(taskId, taskName, dueDate, totalMark, unit, qp);
                break;

            case "3":
                Console.WriteLine("Duration in Minutes: ");
                int duration = int.Parse(Console.ReadLine());

                Console.WriteLine("Is Open Book (true/false): ");
                bool openBook = bool.Parse(Console.ReadLine());

                Console.WriteLine("Location: ");
                string location = Console.ReadLine();

                ExamParams ep = new ExamParams { ExamDurationMins = duration, IsOpenBook = openBook, ExamLocation = location };
                newTask = TaskFactory.CreateExam(taskId, taskName, dueDate, totalMark, unit, ep);
                break;
        }

        if (newTask != null)
        {
            //Add to TaskManager global task list
            _tasks.Add(newTask);
            //Add to specific Unit's internal task list 
            unit.AddTask(newTask);

            Console.WriteLine("Task added successfully!\n");
            newTask.DisplayTaskInfo();
        }
    }

    public void ViewTasks(Unit unit)
    {
        foreach (Task task in unit.Tasks)
        {
            Console.WriteLine($"Task name: {task.TaskName}");
        }
    }

    public Task FindTask(string id)
    {
        foreach (Task t in _tasks)
        {
            if (t.TaskId.Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                return t;
            }
        }
        return null;
    }

    public void AssignTaskToStudent(Task task, Student student)
    {
        if (!student.PendingTasks.Contains(task))
        {
            student.AddPendingTask(task);
            Console.WriteLine($"Task {task.TaskName} assigned to {student.FirstName} {student.LastName}");
        }
        else
        {
            Console.WriteLine("Task is already assigned to student");
        }
    }


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
        }
    }
}
