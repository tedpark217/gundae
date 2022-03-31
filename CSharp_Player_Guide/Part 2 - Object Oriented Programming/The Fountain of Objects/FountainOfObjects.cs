using System;

class GamePlay{
	public static void Main(string[] args){
		GameManager newGame = new GameManager();
		newGame.Run();
	}
}

class GameManager{
	public World GameWorld {get;}
	public Player GamePlayer {get;}
	public bool FountainOnOff {get; set;}
	private ISense[] _senses;
	
	public GameManager(World newWorld, Player newPlayer){
		GameWorld = newWorld;
		GamePlayer = newPlayer;
		
		_senses = new ISense[]{
			
		};
	}
	
	public void Run(){
		
	}
	
	
}

class World{
	private RoomType[][] _grid;
	public int Rows {get;}
	public int Cols {get;}
	
	public World(int rows, int cols){
		Rows = rows;
		Cols = cols;
		_grid = new RoomType[][]{};
	}
	
	public RoomType GetCurrentRoom(){
		
	}
	
	public bool canMove(){
		
	}
}

//player within the game
class Player{
	// current position
	public Position CurrPosition {get; set;}
	
	public Player(Position startPos){
		CurrPosition = startPos;
	}
}

//interface for commands in the game
public interface ICommand{
	void Execute(GameManager game);
}

//command to move the player
public class MoveCommand : ICommand{
	//get direction to move
	public Direction DirToMove {get;}
	
	//constructor to move command
	public MoveCommand(Direction newDirection){
		DirToMove = newDirection;
	}
	
	void Execute(GameManager game){
		Position current = game.GamePlayer.Position;
		Position newPosition = new Position();
		
		switch (DirToMove){
			case Direction.North:
				newPosition = new Position(current.Row - 1, current.Col);
				break;
			case Direction.South:
				newPosition = new Position(current.Row + 1, current.Col);
				break;
			case Direction.West:
				newPosition = new Position(current.Row, current.Col - 1);
				break;
			case Direction.East:
				newPosition = new Position(current.Row, current.Col + 1);
				break;	
		}
		
		if(game.World.IsOnMap(newPosition)){
			game.Player.CurrPosition = newPosition;
		}
		else{
			Console.WriteLine("can't move there");
		}
	}
}

//command to enable the fountain
public class EnableFountainCommand : ICommand{
	void Execute(GameManager game){
		
	}
}

//to keep track of positions
public struct Position{
	public int Row {get; set;}
	public int Col {get; set;}
	
	public Position(){
		Row = 0;
		Col = 0;
	}
	
	public Position(int newRow, int newCol){
		Row = newRow;
		Col = newCol;
	}
}

//direction of movement
enum Direction {North, South, East, West}
enum RoomType {Empty, Fountain, Entrance}