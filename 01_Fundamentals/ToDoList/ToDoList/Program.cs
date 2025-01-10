Console.WriteLine("Welcome to Todo List App");
var todos = new List<string>();
var shallExit = false;
while (!shallExit)
{
    ShowMenu();
    var userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "E":
        case "e":
            Console.WriteLine("Exiting...\n");
            shallExit = true;
            break;
        case "S":
        case "s":
            ShowAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        default:
            Console.WriteLine("Please enter a valid choice\n");
            break;
    }
}

void ShowMenu()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");
}

void ShowAllTodos()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added to list.\n");
        return;
    }

    Console.WriteLine("Your TODO List:");
    for (var i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

void AddTodo()
{
    var isDescriptionValid = false;
    Console.WriteLine("Enter TODO description:");
    while (!isDescriptionValid)
    {
        var description = Console.ReadLine();
        if (string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Description is required");
        }
        else if (todos.Contains(description))
        {
            Console.WriteLine("Description is already in list");
        }
        else
        {
            isDescriptionValid = true;
            todos.Add(description);
            Console.WriteLine($"TODO successfully added: {description}");
        }
    }
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added to list.\n");
        return;
    }
    
    ShowAllTodos();
    Console.WriteLine("Enter the item number to remove:");
    var isIndexValid = false;
    while (!isIndexValid)
    {
        var userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int index) && index > 0 && index <= todos.Count)
        {
            var indexToRemove = index - 1;
            var todoToRemove = todos[indexToRemove];
            todos.RemoveAt(indexToRemove);
            Console.WriteLine($"Removed TODO: {todoToRemove}");
            isIndexValid = true;
        }
        else
        {
            Console.WriteLine("Please enter a valid number:");
        }    
    }
}
