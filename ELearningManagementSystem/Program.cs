namespace ELearning;
public class Program
{
    public static void Main(string[] args)
    {
        //Creating instances of Managers to pass to the DataSeeder
        //These instaces will be shared to Admin, and Teacher
        //Using dependency injection due to issues that stemmed from having multiple instances of managers between Main, and in Admin/Teacher classes
        UserManager userManager = new UserManager();
        DegreeManager degreeManager = new DegreeManager();
        UnitManager unitManager = new UnitManager();
        TaskManager taskManager = new TaskManager();

        //Call DataSeeder to populate Users, Degrees, Units and Tasks
        DataSeeder.Seed(userManager, degreeManager, unitManager, taskManager);

        //Creating login Manager 
        LoginManager loginManager = new LoginManager(userManager);
        User user = loginManager.Login();

        //Inject Manager dependencies
        //This is a type pattern match which checks type, and declares a new variable
        //PolyMorphism here???
        if (user is Admin admin)
        {
            admin.SetManagers(userManager, degreeManager, unitManager, taskManager);
        }
        else if (user is Teacher teacher)
        {
            teacher.SetManagers(taskManager, unitManager, userManager);
        }
        else if (user is Student student)
        {
            student.SetManagers(taskManager, unitManager);
        }

        if (user != null)
            {
                //Will use the correct menu depending on what kind of user
                user.MainMenu();
            }
            else
            {
                Console.WriteLine("Exiting system");
            }

    }
}
