namespace ELearning;
public class Program
{
    public static void Main(string[] args)
    {
        //Testing things out
        List<Task> tasks = new List<Task>();

        // Assignment assignment = new Assignment()

        foreach (Task task in tasks)
        {
            task.DisplayTaskInfo();  // Polymorphic call
        }


        //Create a Command class????

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
        LoginManager loginManager = new LoginManager();
        User user = loginManager.Login();

        //Inject Manager dependencies
        //This is a type pattern match which checks type, and declares a new variable
        if (user is Admin admin)
        {
            admin.SetManagers(userManager, degreeManager, unitManager, taskManager);
        }
        else if (user is Teacher teacher)
        {
            teacher.SetTaskManager(taskManager);
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
