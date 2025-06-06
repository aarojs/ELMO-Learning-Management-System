namespace ELearning;

//Used to add degrees, students and teachers into the ELearning system at runtime. 
//Previously I had all of this code in Main, and through research about best practises I discovered that a 'DataSeeder' is often created 
public class DataSeeder
{
    //Can call without instance of DataSeeder 
    public static void Seed(UserManager userManager, DegreeManager degreeManager, UnitManager unitManager, TaskManager taskManager)
    {
        //Demonstration Student and Teacher
        Student testStudent = new Student("student", "student", "A", "Student", "student@learning.com");
        Teacher testTeacher = new Teacher("teacher", "teacher", "A", "Teacher", "teacher@email.com", TeacherRole.UnitConvenor);
        userManager.AddUser(testStudent);
        userManager.AddUser(testTeacher);

        //Creating users
        Student student1 = new Student("STU_SS9981", "pass", "Simon", "Sutton", "STU_SS9981@learning.com");
        Student student2 = new Student("STU_MB8125", "pass", "Michael", "Barry", "STU_MB8125@learning.com");
        Student student3 = new Student("STU_HJ8815", "pass", "Harry", "Johnson", "STU_HJ8815@learning.com");
        Student student4 = new Student("STU_JS1118", "pass", "Jenny", "Smith", "STU_JS1118@learning.com");
        Student student5 = new Student("STU_AB3300", "pass", "Anna", "Burton", "STU_AB3300@learning.com");
        Student student6 = new Student("STU_IC0012", "pass", "Isaac", "Clarke", "STU_IC0012@learning.com");
        userManager.AddUser(student1);
        userManager.AddUser(student2);
        userManager.AddUser(student3);
        userManager.AddUser(student4);
        userManager.AddUser(student5);
        userManager.AddUser(student6);

        Teacher teacher1 = new Teacher("TEA_KJ0001", "pass", "Karen", "Johnson", "TEA_KJ0001@learning.com", TeacherRole.Lecturer);
        Teacher teacher2 = new Teacher("TEA_SN8871", "pass", "Simon", "Nightly", "TEA_SN8871@learning.com", TeacherRole.Tutor);
        Teacher teacher3 = new Teacher("TEA_CJ0009", "pass", "Cameron", "James", "TEA_CJ0009@learning.com", TeacherRole.UnitConvenor);
        userManager.AddUser(teacher1);
        userManager.AddUser(teacher2);
        userManager.AddUser(teacher3);

        //Creating Degrees
        Degree cs = new Degree("BA-CS", "Bachelor of Computer Science");
        Degree it = new Degree("BA-IT", "Bachelor of Information Technology");
        degreeManager.AddDegree(cs);
        degreeManager.AddDegree(it);

        //Creating Units
        Unit itp = new Unit("CS001", "Intro to Programming");
        Unit oop = new Unit("CS004", "Object Oriented Programming");
        Unit itb = new Unit("IT001", "IT for Business");
        Unit dcs = new Unit("DS002", "Data Science Principles");
        unitManager.AddUnit(itp);
        unitManager.AddUnit(oop);
        unitManager.AddUnit(itb);
        unitManager.AddUnit(dcs);

        //Assign units to degrees. 
        degreeManager.AddUnitsToDegree(cs, itp);
        degreeManager.AddUnitsToDegree(cs, oop);
        degreeManager.AddUnitsToDegree(it, itb);
        degreeManager.AddUnitsToDegree(it, dcs);

        //Enrol students to degrees 
        degreeManager.EnrolStudent(cs, testStudent);
        degreeManager.EnrolStudent(cs, student1);
        degreeManager.EnrolStudent(cs, student2);
        degreeManager.EnrolStudent(cs, student3);
        degreeManager.EnrolStudent(it, student4);
        degreeManager.EnrolStudent(it, student5);
        degreeManager.EnrolStudent(it, student6);

        //Assign teachers to units
        unitManager.AssignTeacher(oop, testTeacher);
        unitManager.AssignTeacher(oop, teacher1);
        unitManager.AssignTeacher(itp, teacher2);
        unitManager.AssignTeacher(itp, teacher3);

        //Create tasks for OOP unit
        AssignmentParams oopap1 = new AssignmentParams { Description = "Oop Assignment 1", MinWords = 100, MaxWords = 500 };
        Task oopAssignment1 = TaskFactory.CreateAssignment("AS1", "OOP Lab 1", DateTime.Parse("2025-09-10"), 15, oop, oopap1);
        QuizParams oopqp1 = new QuizParams { NumberOfQuestions = 10, IsOnline = true };
        Task oopQuiz1 = TaskFactory.CreateQuiz("QZ1", "OOP Quiz 1", DateTime.Parse("2025-09-15"), 10, oop, oopqp1);
        ExamParams oopep1 = new ExamParams { ExamDurationMins = 90, ExamLocation = "Exam Hall", IsOpenBook = false };
        Task oopExam = TaskFactory.CreateExam("EX1", "OOP Exam", DateTime.Parse("2025-10-10"), 40, oop, oopep1);

        //Add tasks to unit 
        taskManager.AddTasksToUnit(oop, oopAssignment1);
        taskManager.AddTasksToUnit(oop, oopQuiz1);
        taskManager.AddTasksToUnit(oop, oopExam);

        Console.WriteLine("\nData has finished seeding.\n\n");
    }
}