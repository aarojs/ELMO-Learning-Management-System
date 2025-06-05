namespace ELearning;
//A task using this interface can be graded by a teacher 
public interface IGradable
{
    bool GradeTask(double mark);

    double GetGrade();

    bool IsGraded();
}
