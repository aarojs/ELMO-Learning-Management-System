namespace ELearning;
//Used to add degrees, students and teachers into the ELearning system at runtime. 
//Previously I had all of this code in Main, and through research about best practises I discovered that a 'DataSeeder' is often created 


public class DataSeeder
{
    //Can call without instance of DataSeeder 
    public static void Seed(UserManager userManager, DegreeManager degreeManager, UnitManager unitManager, TaskManager taskManager)
    {
        //Test Student and Teacher
        Student testStudent = new Student("student", "student", "A", "Student", "student@learning.com");
        Teacher testTeacher = new Teacher("teacher", "teacher", "A", "Teacher", "teacher@email.com");
        userManager.AddUser(testStudent);
        userManager.AddUser(testTeacher);


        //Creating users
        Student student1 = new Student("STU_AS9981", "pass", "Aaron", "Sutton", "STU_AS_00aa@learning.com");
        Student student2 = new Student("STU_MB8125", "pass", "Michael", "Barry", "STU_MB_01ab@learning.com");
        userManager.AddUser(student1);
        userManager.AddUser(student2);

        Teacher teacher1 = new Teacher("TEA_KJ0001", "pass", "Karen", "Johnson", "TEA_KJ_00aj@learning.com");
        Teacher teacher2 = new Teacher("TEA_SN8871", "pass", "Simon", "Nightly", "TEA_SN_08gj@learning.com");
        userManager.AddUser(teacher1);
        userManager.AddUser(teacher2);

        //Creating Degrees
        Degree cs = new Degree("BA-CS", "Bachelor of Computer Science");
        Degree it = new Degree("BA-IT", "Bachelor of Information Technology");
        degreeManager.AddDegree(cs);
        degreeManager.AddDegree(it);

        //Creating Units
        Unit itp = new Unit("CS001", "Intro to Programming");
        Unit oop = new Unit("CS004", "Object Oriented Programming");
        unitManager.AddUnit(itp);
        unitManager.AddUnit(oop);
        

        AssignmentParams ap = new AssignmentParams { Description = "Oop Assignment 1", MinWords = 10, MaxWords = 200 };
        Task oopTask = TaskFactory.CreateAssignment("Quiz", "OOP Quiz", DateTime.Parse("2025-09-10"), 10, oop, ap);
        taskManager.AddTasksToUnit(oop, oopTask);

        unitManager.AssignTeacher(oop, testTeacher);
        unitManager.EnrolStudent(oop, testStudent);
        //Creating tasks 
    }

}