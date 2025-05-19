namespace ELearning;
public class Unit 
{
    private string _unitCode;
    private string _unitTitle;
    private Convenor _unitConvenor;
    private List<Lecturer> _lecturers;
    private List<Tutor> _tutors;
    private List <Student> _enrolledStudents;
    private List <Assignment> _assignments; 

    public string UnitCode 
    {
        get {return _unitCode;}
        set {_unitCode = value;}
    }
    public string UnitTitle 
    {
        get {return _unitTitle;}
        set {_unitCode = value;}
    }
    public Convenor UnitConvenor
    {
        get {return _unitConvenor;}
        set {_unitConvenor = value;}
    }
    public List<Lecturer> Lecturers
    {
        get {return _lecturers;}
    }
    public List<Tutor> Tutors
    {
        get {return _tutors;}
    }
    public List<Student> EnrolledStudents
    {
        get {return _enrolledStudents;}
    }
    public List<Assignment> Assignments
    {
        get {return _assignments;}
    }

    //Different constructors for different kinds of new Units?
    //Sometimes they might be added with a convenor, sometimes not? 
    //This first one will expect a unitCode and unitName and Convenor, and make the lists.
    public Unit(string unitCode, string UnitTitle, Convenor unitConvenor)
    {
        _unitCode = unitCode;
        _unitTitle = UnitTitle;
        _unitConvenor = unitConvenor;
        _lecturers = new List<Lecturer>();
        _tutors = new List<Tutor>();
        _enrolledStudents = new List<Student>();
        _assignments = new List<Assignment>();
    }

    public void AddStudent(Student s)
    {

    }
}