string[] names = new string[] { "Craig", "Rebekah", "Elliott", "Ethan", "Bob", "Sue" };
string[] hometowns = new string[] { "Winter Haven", "Oklahoma City", "Orlando", "Boston", "Chicago", "Memphis" };
string[] favoriteFoods = new string[] { "steak", "fried shrimp", "cheese sticks", "sea bass", "cheesburgers", "tacos" };

Console.WriteLine("Welcome!");

int numElements = names.Length;
bool getAnotherStudent = true;

while (getAnotherStudent)
{
    int menuOption = GetMenuOption(),
        studentNumber;

    switch (menuOption)
    {
        case 1:
            ShowAllNames();
            break;
        
        case 2:
            studentNumber = GetStudentName();
            if (studentNumber > 0)
                GetStudentCategory(studentNumber);
            getAnotherStudent = learnAboutAnotherStudent();
            break;
        
        case 3:
            studentNumber = GetStudentNumber();
            if (studentNumber > 0)
                GetStudentCategory(studentNumber);
            getAnotherStudent = learnAboutAnotherStudent();
            break;

        default:
            getAnotherStudent = false;
            break;
    };
}

Console.WriteLine("\nThanks, have a great day!");
Console.ReadKey();

int GetMenuOption()
{
    Console.WriteLine("\n1. Show list of all students (student number and name).");
    Console.WriteLine("2. Search by student name.");
    Console.WriteLine("3. Search by student number.");
    Console.WriteLine("4. Exit");
    Console.Write("\nWhat would you like to do? ");

    while (true)
    {
        int menuOption;
        bool isValid = int.TryParse(Console.ReadLine(), out menuOption) && menuOption > 0 && menuOption < 5;

        if (!isValid)
            Console.Write("Invalid choice.  Enter a number, 1 - 4: ");
        else
            return menuOption;
    }
}

void ShowAllNames()
{
    int i = 1;

    Console.WriteLine();
    foreach (string name in names)
        Console.WriteLine($"Student {i++} is {name}.");
}

int GetStudentName()
{
    int studentNumber = -1;
    Array namesLowerCase = Array.ConvertAll(names, x => x.ToLower());

    while (studentNumber < 0)
    {
        Console.Write($"\nWhich student would you like to know more about?  Leave blank to skip: ");
        string studentName = Console.ReadLine();

        if (studentName == "")
            return 0;
        
        studentNumber = Array.IndexOf(namesLowerCase, studentName.ToLower());
        if (studentNumber == -1)
            Console.WriteLine("That name was not found.  Try again."); 
     }

    return studentNumber + 1;
}

int GetStudentNumber()
{
    while (true)
    {
        Console.Write($"\nWhich student would you like to know more about?  Enter a number 1 - {numElements}: ");

        int studentNumber;
        bool isValid = int.TryParse(Console.ReadLine(), out studentNumber) && studentNumber > 0 && studentNumber <= numElements;

        if (!isValid)
            Console.WriteLine($"A number 1 - {numElements} is required.\n");
        else
            return studentNumber;
    }
}

void GetStudentCategory(int studentNumber)
{
    Console.WriteLine($"\nStudent {studentNumber} is {names[studentNumber - 1]}.");

    string studentCategory;
    Console.Write("What would you like to know?  Enter \"hometown\" or \"favorite food\" or leave blank to skip: ");
    
    while (true)
    {
        studentCategory = Console.ReadLine();
        if (studentCategory.ToLower().Contains("home")
            || studentCategory.ToLower().Contains("town")
            || studentCategory.ToLower().Contains("food")
            || studentCategory.ToLower().Contains("favorite")
            || studentCategory == "")
            break;
        else    
            Console.Write("Please enter a valid category (\"hometown\" or \"favorite food\") or leave blank to skip: ");
    }

    if (studentCategory == "")
        return;

    if (studentCategory.ToLower().Contains("home")
        || studentCategory.ToLower().Contains("town"))
        Console.WriteLine($"{names[studentNumber - 1]} is from {hometowns[studentNumber - 1]}.");
    else
        Console.WriteLine($"{names[studentNumber - 1]}'s favorite food is {favoriteFoods[studentNumber - 1]}.");
}

bool learnAboutAnotherStudent()
{
    string keepGoing;
 
    while (true)
    {
        Console.Write("\nWould you like to learn about another student?  [y/N]: ");
        
        keepGoing = Console.ReadLine();

        if (keepGoing.ToLower() != "y" && keepGoing.ToLower() != "n" && keepGoing != "")
        {
            Console.WriteLine("That is not a valid response.");
            continue;
        }

        return keepGoing == "y";
    }
}