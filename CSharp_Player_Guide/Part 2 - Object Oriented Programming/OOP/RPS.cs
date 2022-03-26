using System;

class Player{
	public string _name;
	public int _score;
	
	public Player(string newName){
		_name = newName;
		_score = 0;
	}
	
	public string GetName(){
		return _name;
	}
	
	public int GetScore(){
		return _score;
	}
	
	public void Win(){
		_score++;
	}
}

class RPSGame{
	public Player _p1;
	public Player _p2;
	public int _round;
	
	public RPSGame(Player newP1, Player newP2){
		_p1 = newP1;
		_p2 = newP2;
		_round = 1;
	}
	
	public void AskRPS(){
		Console.WriteLine($"Round {_round}.");
		RPS p1Choice = RPS.None;
		RPS p2Choice = RPS.None;
		
		do{
			Console.Write($"What will {_p1._name} choose? (rock, paper, scissors): ");
			string p1Input = Console.ReadLine();
			
			if(p1Input == "rock"){
				p1Choice = RPS.Rock;
			}
			else if(p1Input == "paper"){
				p1Choice = RPS.Paper;
			}
			else if(p1Input == "scissors"){
				p1Choice = RPS.Scissors;
			}
			else{
				Console.WriteLine("Choose Again.");
			}
		}
		while(p1Choice == RPS.None);
		
		do{
			Console.Write($"What will {_p2._name} choose? (rock, paper, scissors): ");
			string p2Input = Console.ReadLine();
			
			if(p2Input == "rock"){
				p2Choice = RPS.Rock;
			}
			else if(p2Input == "paper"){
				p2Choice = RPS.Paper;
			}
			else if(p2Input == "scissors"){
				p2Choice = RPS.Scissors;
			}
			else{
				Console.WriteLine("Choose Again.");
			}
		}
		while(p2Choice == RPS.None);
		
		RPSwin(p1Choice, p2Choice);
		_round++;
		
		Console.WriteLine($"{_p1._name} {_p1._score} : {_p2._name} {_p2._score}");
	}
	
	public void RPSwin(RPS p1RPS, RPS p2RPS){
		if(p1RPS == p2RPS){
			Console.WriteLine("It's a draw.");
		}
		else if(p1RPS == RPS.Rock && p2RPS == RPS. Scissors || p1RPS == RPS.Paper && p2RPS == RPS. Rock || p1RPS == RPS.Scissors && p2RPS == RPS. Paper){
			_p1.Win();
			Console.WriteLine($"{_p1._name} has won.");
		}
		else{
			_p2.Win();
			Console.WriteLine($"{_p2._name} has won.");
		}
	}
}

enum RPS {Rock, Paper, Scissors, None}

class GameTest{
	static void Main(string[] args){
		Console.Write("What is Player1's name?: ");
		string p1Name = Console.ReadLine();
		
		Player p1 = new Player(p1Name);
		
		Console.Write("What is Player2's name?: ");
		string p2Name = Console.ReadLine();
		
		Player p2 = new Player(p2Name);
	
		Console.Write("How many rounds do you want to play?: ");
		int roundNum = Convert.ToInt32(Console.ReadLine());
		
		RPSGame game = new RPSGame(p1, p2);
		
		while(game._round < roundNum){
			game.AskRPS();
		}
	}
}