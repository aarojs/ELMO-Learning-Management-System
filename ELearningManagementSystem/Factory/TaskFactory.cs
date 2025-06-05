namespace ELearning;

//Factory pattern hides the logic of Task creation
//Used in conjunction with the Parameter Object design pattern
public static class TaskFactory
{
    public static Task CreateAssignment(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, AssignmentParams ap)
    {
        return new Assignment(taskId, taskName, dueDate, totalMark, unit, ap.Description, ap.MinWords, ap.MaxWords);
    }

    public static Task CreateQuiz(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, QuizParams qp)
    {
        return new Quiz(taskId, taskName, dueDate, totalMark, unit, qp.NumberOfQuestions, qp.IsOnline);
    }

    public static Task CreateExam(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, ExamParams ep)
    {
        return new Exam(taskId, taskName, dueDate, totalMark, unit, ep.ExamDurationMins, ep.ExamLocation, ep.IsOpenBook);
    }
}
