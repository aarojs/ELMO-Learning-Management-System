namespace ELearning;
public class Program
{
    public static void Main(string[] args)
    {
        //Creating instances of Managers to pass to the DataSeeder
        //These instaces will be shared to Admin, and Teacher
        //Using dependency injection due to issues that stemmed from having multiple instances of managers between Main, and in Admin/Teacher classes
        UserManager userManager = new UserManager();
        UnitManager unitManager = new UnitManager();
        DegreeManager degreeManager = new DegreeManager(unitManager);
        TaskManager taskManager = new TaskManager();

        //Call DataSeeder to populate Users, Degrees, Units and Tasks
        DataSeeder.Seed(userManager, degreeManager, unitManager, taskManager);

        //Creating login Manager 

        //For demonstration and testing..

        //Admin account can be reached via login: admin admin
        //Teacher acccount can be reached via login: teacher teacher
        //Student account can be reached via login: student student.

        //Or any of the accounts created in the DataSeeder can be used to login with their assigned ID and passwords.
        //Users created at runtime can also be used.
        LoginManager loginManager = new LoginManager(userManager);

        //Program Main loop.
        while (true)
        {
            User user = loginManager.Login();

            //Inject Manager dependencies
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
                break;
            }
            //Loop user's main menu until logout
            Console.WriteLine("You have been successfully logged out");
        }
    }
}
