namespace ELearning;

public static class TaskFactory
{
    public static Task CreateAssignment(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, AssignmentParams ap)
    {
        return new Assignment(taskId, taskName, dueDate, totalMark, unit, ap.Description, ap.MinWords, ap.MaxWords);
    }

    public static Task CreateQuiz(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, QuizParams qp)
    {
        Quiz quiz = new Quiz(taskId, taskName, dueDate, totalMark, unit, qp.NumberOfQuestions);
        quiz.IsOnline = qp.IsOnline;
        return quiz;
    }

    public static Task CreateExam(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, ExamParams ep)
    {
        Exam exam = new Exam(taskId, taskName, dueDate, totalMark, unit, ep.ExamDurationMins, ep.ExamLocation);
        exam.IsOpenBook = ep.IsOpenBook;
        return exam;
    }
}
