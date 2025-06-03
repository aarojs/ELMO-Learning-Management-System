namespace ELearning;

public static class TaskFactory
{
    public static Task CreateAssignment(string taskId, string taskName, DateTime dueDate, int totalMark, AssignmentParams ap)
    {
        return new Assignment(taskId, taskName, dueDate, totalMark, ap.Description, ap.MinWords, ap.MaxWords);
    }

    public static Task CreateQuiz(string taskId, string taskName, DateTime dueDate, int totalMark, QuizParams qp)
    {
        Quiz quiz = new Quiz(taskId, taskName, dueDate, totalMark, qp.NumberOfQuestions);
        quiz.IsOnline = qp.IsOnline;
        return quiz;
    }

    public static Task CreateExam(string taskId, string taskName, DateTime dueDate, int totalMark, ExamParams ep)
    {
        Exam exam = new Exam(taskId, taskName, dueDate, totalMark, ep.ExamDurationMins, ep.ExamLocation);
        exam.IsOpenBook = ep.IsOpenBook;
        exam.IsOnline = ep.IsOnline;
        return exam;
    }
}
