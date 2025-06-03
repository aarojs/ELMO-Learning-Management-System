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

    //Will prompt for degree later, should a student need a degree to be created?
    public Student(string id, string password, string firstName, string lastName, string email) : base(id, password, firstName, lastName, email)
    {
        _enrolledUnits = new List<Unit>();
    }
    public override void MainMenu()
    {
        bool finished = false;

        while (!finished)
        {
            Console.WriteLine("Student Menu:");
            Console.WriteLine("1. View Units");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Change password");
            Console.WriteLine("4. Logout");

            String input = Console.ReadLine();  
        }
    }
}