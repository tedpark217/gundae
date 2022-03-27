using System;

class Puzzle{
	public string[][] _puzzle;
	private static string[][] finishedPuzzle = new string[][]{
		new string[] {" 1"," 2"," 3"," 4"},
		new string[] {" 5"," 6"," 7"," 8"}, 
		new string[] {" 9","10","11","12"},
		new string[] {"13","14","15","  "}
	};
	
	public Puzzle(){
		_puzzle = new string[][]{
			new string[4],
			new string[4],
			new string[4],
			new string[4]
		};
	}
	
	public Puzzle(string[][] newPuzzle){
		_puzzle = newPuzzle;
	}
	
	public void Display(){
		Console.WriteLine($"{_puzzle[0][0]} | {_puzzle[0][1]} | {_puzzle[0][2]} | {_puzzle[0][3]}");
		Console.WriteLine("-----------------");
		Console.WriteLine($"{_puzzle[1][0]} | {_puzzle[1][1]} | {_puzzle[1][2]} | {_puzzle[1][3]}");
		Console.WriteLine("-----------------");
		Console.WriteLine($"{_puzzle[2][0]} | {_puzzle[2][1]} | {_puzzle[2][2]} | {_puzzle[2][3]}");
		Console.WriteLine("-----------------");
		Console.WriteLine($"{_puzzle[3][0]} | {_puzzle[3][1]} | {_puzzle[3][2]} | {_puzzle[3][3]}");
		Console.WriteLine("-----------------");
	}
	
	public int[] canMove(){
		int[] check = new int[2];
		
		for(int i = 0; i < _puzzle.Length; i++){
			for(int j = 0; j < _puzzle[i].Length; j++){
				if(_puzzle[i][j] == "  "){
					check[0] = i;
					check[1] = j;
				}
			}
		}
		return check;
	}
	
	
	//parameter: string (right r or left l)
	public void moveRow(string RL){
		//get row index with empty tile
		int[] empty = canMove();
		int emptyRow = empty[0];
		
		//move the given row to right
		if(RL == "r"){
			int emptyIdx = Array.IndexOf(_puzzle[emptyRow],"  ");
			for(int i = emptyIdx; i > 0; i--){
				_puzzle[emptyRow][i] = _puzzle[emptyRow][i-1];
			}
			_puzzle[emptyRow][0] = "  ";
		}
		//move the given row to left
		if(RL == "l"){
			int emptyIdx = Array.IndexOf(_puzzle[emptyRow],"  ");
			for(int i = emptyIdx; i < _puzzle[emptyRow].Length-1; i++){
				_puzzle[emptyRow][i] = _puzzle[emptyRow][i+1];
			}
			_puzzle[emptyRow][3] = "  ";
		}
	}
	
	
	//parameter: string (up u or down d)
	public void moveCol(string UD){
		//get col index with empty tile
		int[] empty = canMove();
		int emptyRow = empty[0];
		int emptyCol = empty[1];
		
		//move the given col up
		if(UD == "u"){
			for(int i = emptyRow; i < _puzzle.Length-1; i++){
				_puzzle[i][emptyCol] = _puzzle[i+1][emptyCol];
			}
			_puzzle[3][emptyCol] = "  ";
		}
		//move the given col down
		if(UD == "d"){
			for(int i = emptyRow; i > 0; i--){
				_puzzle[i][emptyCol] = _puzzle[i-1][emptyCol];
			}
			_puzzle[0][emptyCol] = "  ";
		}
	}
	
	//check for win condition
	public bool checkWin(){
		bool check = true;
		
		for(int i = 0; i < _puzzle.Length; i++){
			for(int j = 0; j < _puzzle[0].Length; j++){
				if(_puzzle[i][j] != finishedPuzzle[i][j]){
					check = false;
				}
			}
		}
		
		return check;
	}
}


class PuzzleGame{
	public Puzzle _newPuzzle;
	
	public PuzzleGame(Puzzle newPuzzle){
		_newPuzzle = newPuzzle;
	}
	
	public void AskMovement(){
		_newPuzzle.Display();
		Console.WriteLine("Where to move?");
		Console.Write("Type first letter in lowercase (Up, Down, Left, Right): ");
		
		bool correct = false;
		
		do{
			string input = Console.ReadLine();
			if(input == "u" || input == "d"){
				_newPuzzle.moveCol(input);
				correct = true;
			}
			else if(input == "r" || input == "l"){
				_newPuzzle.moveRow(input);
				correct = true;
			}
			else{
				Console.WriteLine("Invalid Input. Type Again: ");
			}
		}
		while(!correct);
	}
	
	public void Update(){
		while(!_newPuzzle.checkWin()){
			AskMovement();
		}
		Console.WriteLine("Congratulations. You've beat the game.");
	}
}

class PuzzleTest{
	static void Main(string[] args){
		
		//create new puzzle
		string[][] newGame = new string[][]{
			new string[] {" 1"," 3","10","13"}, 
			new string[] {" 4"," 2","  "," 6"}, 
			new string[] {"11"," 8"," 7","12"}, 
			new string[] {" 9","14"," 5","15"}
		};
		
		//input to puzzle class
		Puzzle puz15 = new Puzzle(newGame);
		
		//create game with the puzzle
		PuzzleGame game = new PuzzleGame(puz15);
		game.Update();
	}
}