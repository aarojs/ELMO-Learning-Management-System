namespace ELearning; 
public class Degree
{
    private string _degreeId;
    private string _degreeName; 
    private List<Unit>_units; 

    public string DegreeId
    {
        get {return _degreeId;}
        set {_degreeId = value;}
    }
    public string DegreeName 
    {
        get {return _degreeName;}
        set {_degreeName = value;}
    }
    public List<Unit>Units
    {
        get
        {
            //fix, return actual string 
            return _units;
        }
    }

    //Will this take in a list of units?
    //Or do this after?
    //Use in factory?
    public Degree(string degreeId, string degreeName)
    {
        _degreeId = degreeId;
        _degreeName = degreeName;
        _units = new List<Unit>();

    }
}