class Card
{
    public string nominal;
    public char suit;
    public Card(string nominal, char suit)
    {
        this.nominal = nominal;
        this.suit = suit;
    }
    public void Print()
    {
        Console.Write($"{nominal}{suit} ");
    }
}

class Deck
{
    private char[] suits = {'♠', '♣', '♦','♥'};
    private string[] nominnals = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    public List<Card> cards = new List<Card>(52);
}
