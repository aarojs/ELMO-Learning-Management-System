namespace ELearning;
public class Student : User
{
    private Degree _degree;
    private List<Unit>_enrolledUnits;
    public Degree Degree { get { return _degree; } set { _degree = value; }}
    public List<Unit>EnrolledUnits 
    {
        get {return _enrolledUnits;} //fix
    }

    public Student (string id, string firstName, string lastName, string email, Degree degree) : base(id, firstName, lastName, email)
    {
        _degree = degree;
        _enrolledUnits = new List<Unit>();

    }
    public override void MainMenu()
    {
        throw new NotImplementedException();
    }
}