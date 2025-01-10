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
        ShowNoTodoMessage();
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
    string description;
    do
    {
        Console.WriteLine("Enter TODO description:");
        description = Console.ReadLine();
    } while (!IsDescriptionValid(description));
    
    todos.Add(description);
    Console.WriteLine($"TODO successfully added: {description}");
}

bool IsDescriptionValid(string description)
{
    if (string.IsNullOrEmpty(description))
    {
        Console.WriteLine("Description is required");
        return false;
    }
    
    if (todos.Contains(description))
    {
        Console.WriteLine("Description is already in list");
        return false;
    }
    
    return true;
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    ShowAllTodos();
    
    int index;
    do
    {
        Console.WriteLine("Enter the item number to remove:");
    } while (!TryReadIndex(out index));
    
    RemoveTodoAtIndex(index - 1);
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
    {
        index = -1;
        Console.WriteLine("Index is required");
        return false;
    }

    if (int.TryParse(userInput, out index) && index > 0 && index <= todos.Count)
    {
        return true;
    }

    Console.WriteLine("Invalid index number: ");
    return false;
}

void RemoveTodoAtIndex(int index)
{
    var todoToRemove = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine($"Removed TODO: {todoToRemove}");
}

void ShowNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added to list.");
}
