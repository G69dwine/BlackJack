namespace Cards
{
    class Card
    {
        public string nominal;
        public char suit;
        public bool open = true;

        public Card(string nominal, char suit)
        {
            this.nominal = nominal;
            this.suit = suit;
        }
        public string[] cardPic()
        {
            string[] pic =
        {
        "* * * * *",
        "* ..+   *",
        "* +   + *",
        "*   +   *",
        "* +   + *",
        "*   +.. *",
        "* * * * *"
    };
            for (int i = 0; i < pic.Length; i++)
            {
                char marker = '.';
                if (open) marker = '+';
                pic[i] = pic[i].Replace(marker, ' ');
                while (pic[i].IndexOf('.') != -1)
                {
                    int tempInd = pic[i].IndexOf('.');
                    pic[i] = pic[i].Remove(tempInd, (nominal.Length + 1));
                    pic[i] = pic[i].Insert(tempInd, $"{nominal}{suit}");
                }
            }
            return pic;
        }
    }
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public Deck() // при создании колоды по-умолчению, сразу заполняем и замешиваем
        {
            FullDeck();
            ShuffleDeck();
        }
        public Deck(int n)
        {
            this.cards = new List<Card>(n);
        }
        public int countedPoints() // посчет очков в указазанной стопке карт.
        {
            int points = 0;
            int aces = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                switch (cards[i].nominal)
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
                        aces++;
                        break;
                }
                while (aces > 0)
                {
                    if (points + (aces * 11) > 21)
                    {
                        points += 1;
                        aces--;
                    }
                    points += (11 * aces);
                    aces--;
                    break;
                }
            }
            return points;
        }
        void FullDeck() // метод заполнения колоды карт (по порядку).
        {
            char[] suits = { '♠', '♣', '♦', '♥' };
            string[] nominnals = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            foreach (var s in suits)
            {
                foreach (var n in nominnals)
                {
                    cards.Add(new Card(n, s));
                }
            }
        }
        public void ShuffleDeck() //метод перемешивания колоды
        {
            Random shuffle = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = shuffle.Next(n + 1);
                Card randomCard = cards[k];
                cards[k] = cards[n];
                cards[n] = randomCard;
            }
        }
        public void PrintDeck() // метод отображения ряда карт на столе.
        {
            string[] picDeck = new string[cards[0].cardPic().Length];
            for (int i = 0; i < picDeck.Length; i++)
            {
                foreach (var card in cards)
                {
                    picDeck[i] += card.cardPic()[i] + "\t";
                }
                Console.WriteLine(picDeck[i]);
            }
        }
    }
}