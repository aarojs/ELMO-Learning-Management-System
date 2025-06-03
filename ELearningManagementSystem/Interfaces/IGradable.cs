namespace ELearning;
//A task using this interface can be graded by a teacher 
public interface IGradable
{
    void GradeTask(string username, double mark);

    double GetGrade(string username);

    bool IsGraded(string username);
}
