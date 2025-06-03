namespace ELearning;

public class Quiz : Task
{
    private int _numberOfQuestions;
    private bool _isOnline;

    public int NumberOfQuestions
    {
        get { return _numberOfQuestions; }
        set { _numberOfQuestions = value; }
    }
    public bool IsOnline
    {
        get { return _isOnline; }
        set { _isOnline = value; }
    }

    public Quiz(string taskId, string taskName, DateTime dueDate, int totalMark, int numberOfQuestions) : base(taskId, taskName, dueDate, totalMark)
    {
        _numberOfQuestions = numberOfQuestions;
    }

    public override void DisplayTaskInfo()
    {
        Console.WriteLine($"Quiz: {TaskName}, Due: {DueDate.ToShortDateString()}, Questions: {NumberOfQuestions}");
    }

    
}