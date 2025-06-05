namespace ELearning;

public class Quiz : Task, ISubmittable
{
    private int _numberOfQuestions;
    private bool _isOnline;
    private bool _submitted;

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

    public Quiz(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, int numberOfQuestions, bool isOnline) : base(taskId, taskName, dueDate, totalMark, unit)
    {
        _numberOfQuestions = numberOfQuestions;
        _isOnline = isOnline;
    }

    public override void DisplayTaskInfo()
    {
        base.DisplayTaskInfo();
        Console.WriteLine($"Number of questions: {NumberOfQuestions}");
        Console.WriteLine($"Online quiz: {IsOnline}\n");
    }

    public void Submit()
    {
        _submitted = true;
    }

    public bool IsSubmitted()
    {
        if (_submitted)
        {
            return true;
        }
        return false;
    }


}