namespace ELearning;

//A task using this interface can be Submitted by a Student.
public interface ISubmittable
{
    void Submit(string username, string submission);

    bool IsSubmitted(string username);
}