char[] suits = {'♠', '♣', '♦','♥'};
string[] nominnals = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
List<Card> pack = new List<Card>(52);
Player dealer = new Player("Dealer");
Player player = new Player("You");

FullDeck();
ShuffleDeck();
Game();

void Game()
{
    player.hand.Add(pack[0]);
    pack.RemoveAt(0);
    dealer.hand.Add(pack[0]);
    pack.RemoveAt(0);
    player.hand.Add(pack[0]);
    pack.RemoveAt(0);
    dealer.hand.Add(pack[0]);
    pack.RemoveAt(0);
    dealer.CountPoins();
    player.CountPoins();
    ShowCards();
    while (player.points < 21)
    {
        Console.WriteLine("Карту? (y/n)");
        string? answer = Console.ReadLine();
        if (answer?.ToLower() == "y")
        {
            player.hand.Add(pack[0]);
            pack.RemoveAt(0);
            player.CountPoins();
            ShowCards();
        }
        else
        {
            player.CountPoins();
            ShowCards();
            break;
        }
    }
    if (dealer.points < 16)
    {
        dealer.hand.Add(pack[0]);
        pack.RemoveAt(0);
        dealer.CountPoins();
        ShowCards();
    }
    GameResult();
}

void GameResult()
{
    if (player.points > dealer.points && player.points <= 21 || dealer.points > 21)
        Console.WriteLine("Вы победили!");
    else if (player.points == dealer.points && player.points <= 21)
        Console.WriteLine("Ничья");
    else
        Console.WriteLine("Победа диллера");
}

void ShowCards()
{
    Console.Clear();
    dealer.PrintHand();
    dealer.CountPoins();
    Console.WriteLine("\n");
    player.PrintHand();
    Console.WriteLine("\n");
}

void FullDeck()
{
    int indexCard = 0;
    for (int i=0; i<nominnals.Length; i++)
    {
        for (int j=0; j < suits.Length; j++)
        {
            pack.Add(new Card(nominnals[i], suits[j]));
            indexCard++;
        }
    }
} 

void ShuffleDeck()
{
    Random shuffle = new Random();
    int n = pack.Count;
    while (n > 1)
    {
        n--;
        int k = shuffle.Next(n+1);
        Card randomCard = pack[k];
        pack[k] = pack[n];
        pack[n] = randomCard;
    }
}

// class Card
// {
//     private char[] suits = {'♠', '♣', '♦','♥'};
//     private string[] nominnals = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
//     public string nominal;
//     public char suit;
//     public Card(string nominal, char suit)
//     {
//         this.nominal = nominal;
//         this.suit = suit;
//     }
//     public void Print()
//     {
//         Console.Write($"{nominal}{suit} ");
//     }
// }

// class Deck
// {
//     public List<Card> cards = new List<Card>(52);
// }

class Player
{
    public string name;
    public List<Card> hand = new List<Card>(5);
    public int points;
    public Player(string name)
    {
        this.name = name;
    }
    public void PrintHand()
    {
        Console.WriteLine(name);
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].Print();
        }
    }
    public void CountPoins()
    {
        points = 0;
        for (int i = 0; i < hand.Count; i++)
        {
            switch(hand[i].nominal)
            {
                case "1":
                    points += 1;
                    break;
                case "2":
                    points += 2;
                    break;
                case "3":
                    points += 3;
                    break;
                case "4":
                    points += 4;
                    break;
                case "5":
                    points += 5;
                    break;
                case "6":
                    points += 6;
                    break;
                case "7":
                    points += 7;
                    break;
                case "8":
                    points += 8;
                    break;
                case "9":
                    points += 9;
                    break;
                case "10":
                    points += 10;
                    break;
                case "J":
                    points += 10;
                    break;
                case "Q":
                    points += 10;
                    break;
                case "K":
                    points += 10;
                    break;
                case "A":
                    points += 11;
                    break;
            }
        }
        
    }
}