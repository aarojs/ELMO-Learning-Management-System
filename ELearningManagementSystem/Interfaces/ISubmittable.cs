namespace ELearning;

//A task using this interface can be Submitted by a Student.
public interface ISubmittable
{
    void Submit();

    bool IsSubmitted();
}