namespace ELearning;
public abstract class Teacher : User
{
    private List<Unit> _teachingUnits;

    public List<Unit> TeachingUnits
    {
        get {return _teachingUnits;} //fix
    }

    public Teacher(string id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
    {
        _teachingUnits = new List<Unit>();
    }


    public abstract void RoleDescription(); //this is a placeholder to describe the teacher child class roles .
    
}