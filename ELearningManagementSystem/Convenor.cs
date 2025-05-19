namespace ELearning;
public class Convenor : Teacher
{
    public Convenor(string id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
    {

    }

    public override void MainMenu()
    {
        throw new NotImplementedException();
    }

    public override void RoleDescription()
    {
        throw new NotImplementedException();
    }

}

//Convenor can update unit details, other teachers cannot 