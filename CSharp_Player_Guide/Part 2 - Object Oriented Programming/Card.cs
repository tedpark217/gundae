using System;

class Card{
	public CardColor color;
	public CardRank rank;
	
	public Card(CardColor newColor, CardRank newRank){
		color = newColor;
		rank = newRank;
	}
	
	/*
	public string getCard(){
		if(rank == CardRank.$ || rank == CardRank.% || rank == CardRank.^ || rank == CardRank.&){
			return "Symbol Card";
		}
		else{
			return "Number Card";
		}
	}*/
}

enum CardColor {red, green, blue, yellow}
enum CardRank {one,two,three,four,five,six,seven,eight,nine,ten,@"$",@"%",@"^",@"&"}

class CardTest{
	Card myCard = new Card(CardColor.Red, CardRank.$);
	//Console.WriteLine(myCard.getCard());
}