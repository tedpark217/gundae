using System;

class Card{
	public CardColor _color;
	public CardRank _rank;
	
	public Card(CardColor newColor, CardRank newRank){
		_color = newColor;
		_rank = newRank;
	}
	

	public string getCard(){
		if(_rank == CardRank.DollarSign || _rank == CardRank.Percent || _rank == CardRank.Carot || _rank == CardRank.Ampersand){
			return "Symbol Card";
		}
		else{
			return "Number Card";
		}
	}
	
	public string printCard(){
		return $"The {_color} {_rank} ";
	}
}

enum CardColor {Red, Green, Blue, Yellow}
enum CardRank {One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,DollarSign,Percent,Carot,Ampersand}

class CardTest{
	static void Main(string[] args){
		Card myCard = new Card(CardColor.Red, CardRank.DollarSign);
		Console.WriteLine(myCard.getCard());
		//Console.WriteLine(myCard.printCard());
		
		int numOfColor = Enum.GetNames(typeof(CardColor)).Length;
		int numOfRank = Enum.GetNames(typeof(CardRank)).Length;
		
		Console.WriteLine($"{numOfColor} {numOfRank}");
		
		Card[] cardDeck = new Card[numOfRank * numOfColor];
		
		int count = 0;
		
		for(int i = 0; i < numOfColor; i++){
			for(int j = 0; j < numOfRank; j++){
				cardDeck[count] = new Card((CardColor)i, (CardRank)j);
				count++;
			}
		}
				
		for(int i = 0; i < cardDeck.Length; i++){
			Console.WriteLine(cardDeck[i].printCard());
		}
	}
}