namespace ELearning;

public class TaskManager
{
    private List<Task> _tasks = new List<Task>();

    //Look back over this what are we even doing here
    public void CreateTask()
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
        int totalMark = int.Parse(Console.ReadLine());

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
                newTask = TaskFactory.CreateAssignment(taskId, taskName, dueDate, totalMark, ap);
                break;

            case "2":
                Console.WriteLine("Number of Questions: ");
                int numQ = int.Parse(Console.ReadLine());

                Console.WriteLine("Is Online (true/false): ");
                bool online = bool.Parse(Console.ReadLine());

                QuizParams qp = new QuizParams { NumberOfQuestions = numQ, IsOnline = online };
                newTask = TaskFactory.CreateQuiz(taskId, taskName, dueDate, totalMark, qp);
                break;

            case "3":
                Console.WriteLine("Duration in Minutes: ");
                int duration = int.Parse(Console.ReadLine());

                Console.WriteLine("Is Open Book (true/false): ");
                bool openBook = bool.Parse(Console.ReadLine());

                Console.WriteLine("Is Online (true/false): ");
                bool isOnline = bool.Parse(Console.ReadLine());

                Console.WriteLine("Location: ");
                string location = Console.ReadLine();

                ExamParams ep = new ExamParams { ExamDurationMins = duration, IsOpenBook = openBook, IsOnline = isOnline, ExamLocation = location };
                newTask = TaskFactory.CreateExam(taskId, taskName, dueDate, totalMark, ep);
                break;
        }

        if (newTask != null)
        {
            _tasks.Add(newTask);
            Console.WriteLine("Task added successfully!\n");
            newTask.DisplayTaskInfo();
        }
    }

    public void ViewTasks()
    {
        foreach (Task task in _tasks)
        {
            Console.WriteLine($"Task name: {task.TaskName}");
        }
    }
}
