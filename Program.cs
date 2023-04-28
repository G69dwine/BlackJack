using Cards;

Player dealer = new Player("Dealer");
Player player = new Player("You");

Deck newDeck = new Deck(); // Общая колода кард
Deck playersHand = new Deck(5); // карты игрока
Deck dealersHand = new Deck(5); // карты диллера

for (int i = 1; i <= 2; i++)        // стартовая раздача
{
    playersHand.cards.Add(newDeck.cards[0]);
    newDeck.cards.RemoveAt(0);
    dealersHand.cards.Add(newDeck.cards[0]);
    newDeck.cards.RemoveAt(0);
    player.points = playersHand.countedPoints();
    dealer.points = dealersHand.countedPoints();
}
dealersHand.cards[0].open = false;
Table();

while (player.points < 21 && playersHand.cards.Count < 5) // ход игрока
{
    Console.WriteLine("Карту? (y/n)");
    string? answer = Console.ReadLine();
    if (answer?.ToLower() == "y")
    {
        playersHand.cards.Add(newDeck.cards[0]);
        newDeck.cards.RemoveAt(0);
        player.points = playersHand.countedPoints();
        Table();
    }
    else
    {
        Table();
        break;
    }
}

dealersHand.cards[0].open = true;   // ход диллера
Table();
if (dealer.points < 16 && player.points <= 21)
{
    dealersHand.cards.Add(newDeck.cards[0]);
    newDeck.cards.RemoveAt(0);
    dealer.points = dealersHand.countedPoints();
    Table();
}

GameResult();   

void Table() // метод отображения карт на столе
{
    Console.Clear();
    Console.WriteLine(dealer.name);
    dealersHand.PrintDeck();
    Console.WriteLine("\n");
    Console.WriteLine(player.name);
    playersHand.PrintDeck();
}

void GameResult()   // метод вывода результатов игры. 
{
    Table();
    if (player.points > dealer.points && player.points <= 21 || dealer.points > 21)
        Console.WriteLine("Вы победили!");
    else if (player.points == dealer.points && player.points <= 21)
        Console.WriteLine("Ничья");
    else
        Console.WriteLine("Победа диллера");
}