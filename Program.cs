using System;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}

class Room
{
    public bool HasItem { get; set; }
    public Room North { get; set; }
    public Room South { get; set; }
    public Room East { get; set; }
    public Room West { get; set; }
}

class Game
{
    private Room currentRoom;
    private bool hasItem;
    private int tries;
    private bool gameWon;
    private bool gameLost;

    public void Start()
    {
        Console.WriteLine("Welcome to the game! You are in a room. There is an item you need to find. At a certain place in the game, there is an NPC that asks you a riddle. You have 2 chances to answer the riddle. If you can't answer correctly in 2 tries, the NPC kills you and you lose the game. If you give the correct answer based on the clues and the item you found to the NPC, you win the game.");

        // Initialize the starting room
        currentRoom = new Room { HasItem = false, North = null, South = null, East = null, West = null };
        hasItem = false;
        tries = 0;
        gameWon = false;
        gameLost = false;

        while (!gameWon && !gameLost)
        {
            Console.WriteLine("\nChoose an action: 1) Walk around, 2) Check for item, 3) Talk to NPC, 4) Quit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WalkAround();
                    break;
                case 2:
                    CheckForItem();
                    break;
                case 3:
                    TalkToNPC();
                    break;
                case 4:
                    Quit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void WalkAround()
    {
        Console.WriteLine("\nChoose a direction: 1) North, 2) South, 3) East, 4) West");
        int direction = int.Parse(Console.ReadLine());

        switch (direction)
        {
            case 1:
                currentRoom.North = new Room { HasItem = false, North = null, South = null, East = null, West = null };
                currentRoom = currentRoom.North;
                break;
            case 2:
                currentRoom.South = new Room { HasItem = false, North = null, South = null, East = null, West = null };
                currentRoom = currentRoom.South;
                break;
            case 3:
                currentRoom.East = new Room { HasItem = false, North = null, South = null, East = null, West = null };
                currentRoom = currentRoom.East;
                break;
            case 4:
                currentRoom.West = new Room { HasItem = true, North = null, South = null, East = null, West = null };
                currentRoom = currentRoom.West;
                break;
            default:
                Console.WriteLine("Invalid direction. Please try again.");
                break;
        }
    }

    private void CheckForItem()
    {
        if (hasItem)
        {
            Console.WriteLine("\nYou already have the item.");
        }
        else
        {
            if (currentRoom.HasItem)
            {
                Console.WriteLine("\nYou found the item!");
                hasItem = true;
            }
            else
            {
                Console.WriteLine("\nThere is no item in this room.");
            }
        }
    }

    private void TalkToNPC()
    {
        if (!hasItem)
        {
            Console.WriteLine("\nYou don't have the item. Please find it first.");
        }
        else
        {
            Console.WriteLine("\nYou are talking to the NPC. Here is the riddle: What has keys but can't open locks?");
            Console.WriteLine("Choose an answer: 1) A piano, 2) A book, 3) A door, 4) A person, 5) A computer");
            int answer = int.Parse(Console.ReadLine());

            if (answer == 1)
            {
                Console.WriteLine("\nCorrect! You win the game!");
                gameWon = true;
            }
            else
            {
                tries++;
                if (tries == 2)
                {
                    Console.WriteLine("\nIncorrect answer. You have used all your tries. You lose the game.");
                    gameLost = true;
                }
                else
                {
                    Console.WriteLine($"\nIncorrect answer. You have {2 - tries} tries left.");
                }
            }
        }
    }

    private void Quit()
    {
        Console.WriteLine("\nThanks for playing! Goodbye.");
        Environment.Exit(0);
    }
}
