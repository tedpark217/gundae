using System;

class Player{
	private string _name;
	private int _score;
	
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

class Board{
	private char[][] _board;
	private char _winner;
	
	public Board(){
		_winner = '\0';
		_board = new char[][]{
			new char[3],
			new char[3],
			new char[3]
		};
	}
	
	//check given row
	private bool checkRow(int rowNum){
		bool boolean = true;
		
		//first element
		char first = _board[rowNum][0];
		if(first == '\0'){
			return false;
		}
		
		for(int i = 1; i < _board[rowNum].Length; i++){
			if(_board[rowNum][i] != first){
				boolean = false;
			}
		}
		
		return boolean;
	}
	
	//check given col
	private bool checkCol(int colNum){
		bool boolean = true;
		
		//first element
		char first = _board[0][colNum];
		if(first == '\0'){
			return false;
		}
		
		for(int i = 1; i < _board.Length; i++){
			if(_board[i][colNum] != first){
				boolean = false;
			}
		}
		
		return boolean;
	}
	
	//return true if game finished, false if game didn't finish
	//finished when:	player made a row/col
	public bool checkFinished(){
		for(int i = 0; i < _board.Length; i++){
			bool rowTest = checkRow(i);
			
			if(rowTest){
				_winner = _board[i][0];
				return true;
			}
			bool colTest = checkCol(i);

			if(colTest){
				_winner = _board[0][i];
				return true;
			}
		}
		return false;
	}
	
	public char result(){
		return _winner;
	}
	
	public bool placeable(int position){
		switch (position){
			case 1:
				return _board[0][0] == '\0';
			case 2:
				return _board[0][1] == '\0';
			case 3:
				return _board[0][2] == '\0';
			case 4:
				return _board[1][0] == '\0';
			case 5:
				return _board[1][1] == '\0';
			case 6:
				return _board[1][2] == '\0';
			case 7:
				return _board[2][0] == '\0';
			case 8:
				return _board[2][1] == '\0';
			case 9:
				return _board[2][2] == '\0';
			default:
				Console.WriteLine("The given position is not valid.");
				return false;
		}
	}
	
	//place input (O or X) at position of the board 
	//positions:
	// 1 | 2 | 3
	// 4 | 5 | 6
	// 7 | 8 | 9
	public void play(int position, char input){
		switch (position){
		case 1:
			_board[0][0] = input;
			break; 
			case 2:
			_board[0][1] = input;
			break;
		case 3:
			_board[0][2] = input;
			break;
		case 4:
			_board[1][0] = input;
			break;
		case 5:
			_board[1][1] = input;
			break;
		case 6:
			_board[1][2] = input;
			break;
		case 7:
			_board[2][0] = input;
			break;
		case 8:
			_board[2][1] = input;
			break;
		case 9:
			_board[2][2] = input;
			break;
		}
	}
	
	public void Display(){
		Console.WriteLine($" {_board[0][0]} | {_board[0][1]} | {_board[0][2]}");
		Console.WriteLine("---------");
		Console.WriteLine($" {_board[1][0]} | {_board[1][1]} | {_board[1][2]}");
		Console.WriteLine("---------");
		Console.WriteLine($" {_board[2][0]} | {_board[2][1]} | {_board[2][2]}");
		Console.WriteLine("---------");
	}
}

class TTTGame{
	private Player _p1;
	private Player _p2;
	private Board _gameBoard;
	private int _round;
	
	public TTTGame(Player newP1, Player newP2, int roundNum){
		_p1 = newP1;
		_p2 = newP2;
		_gameBoard = new Board();
		_round = roundNum;
	}
	
	//print round # and score
	private void RoundStarter(int currRound){
		Console.WriteLine($"Round {currRound}.");
		Console.WriteLine($"{_p1.GetName()} {_p1.GetScore()} : {_p2.GetName()} {_p2.GetScore()}");
	}
	
	//check for how many rounds played
	private bool checkRound(int currRound){
		if(_round < currRound){
			return false;
		}
		return true;
	}
	
	private void StartRound(int currRound){
		_gameBoard = new Board();
		
		//check who starts	
		int turn = 0;
		if(currRound % 2 == 1){
			Console.WriteLine($"{_p1.GetName()} starts the round.");
		}
		else{
			Console.WriteLine($"{_p2.GetName()} starts the round.");
			turn = 1;
		}
		
		while(!_gameBoard.checkFinished()){
			
			//display board and ask for input
			int input;
			do{
				//check which player plays
				if(turn % 2 == 0){
					Console.WriteLine($"It is {_p1.GetName()}'s turn.");
				}
				else{
					Console.WriteLine($"It is {_p2.GetName()}'s turn.");
				}
				_gameBoard.Display();
				Console.Write("What square do you want to play in?: ");
				input = Convert.ToInt32(Console.ReadLine());
			}
			while(!_gameBoard.placeable(input));
			
			//place O or X
			if(turn % 2 == 0){
				_gameBoard.play(input, 'O');
			}
			else{
				_gameBoard.play(input, 'X');
			}
			turn++;
			
			if(turn >= 9){
				break;
			}
		}
		
		if(_gameBoard.result() == 'O'){
			Console.WriteLine($"Winner of round {currRound} is {_p1.GetName()}.");
		}
		else{
			Console.WriteLine($"Winner of round {currRound} is {_p2.GetName()}.");
		}
		
	}
	
	//play the game
	public void Play(){
		int round = 1;
		RoundStarter(round);
		
		while(checkRound(round)){
			StartRound(round);
			round++;
		}
		
		if(_p1.GetScore() > _p2.GetScore()){
			Console.WriteLine($"The final winner is {_p1.GetName()}.");
		}
		else if(_p1.GetScore() < _p2.GetScore()){
			Console.WriteLine($"The final winner is {_p2.GetName()}.");
		}
		else{
			Console.WriteLine("It's a draw.");
		}
	}
	
	
}

class TicTacToe{
	public static void Main(string[] args){
		Console.Write("Name of Player 1: ");
		string p1Name = Console.ReadLine();
		
		Console.Write("Name of Player 2: ");
		string p2Name = Console.ReadLine();
		
		Player p1 = new Player(p1Name);
		Player p2 = new Player(p2Name);
		
		Console.Write("How many rounds do you want to play?: ");
		int rounds = Convert.ToInt32(Console.ReadLine());
		
		TTTGame game = new TTTGame(p1, p2, rounds);
		game.Play();
	}
}