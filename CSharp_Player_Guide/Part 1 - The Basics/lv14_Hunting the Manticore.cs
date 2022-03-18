using System;

class Manticore{
    static void Main(string[] args){
	
		//asks for distance between Manticore and the city
		int dist;
		
		do{
			Console.Write("Player 1, how far away from the city do you want to station the Manticore [0-100]? ");
			dist = Convert.ToInt32(Console.ReadLine());
		}
		while(dist < 0 || dist > 100);
		
		Console.Clear();	

		//player 2 plays
		
		int turnNum = 1;
		int cannonRange;
		
		int mcfullHP = 15;
		int cityfullHP = 15;
		
		int mcleftHP = mcfullHP;
		int cityleftHP = cityfullHP;
		
		Console.WriteLine("Player2, it is your turn.");
		
		while(cityleftHP > 0 && mcleftHP > 0){
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("-------------------------------------------------------------------");
			
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"STATUS: Round: {turnNum}  City: {cityleftHP}/{cityfullHP}  Manticore: {mcleftHP}/{mcfullHP}");
			
			int dmg;
			if(turnNum % 3 == 0 && turnNum % 5 == 0){
				dmg = 10;
			}
			else if(turnNum % 3 == 0 || turnNum % 5 == 0){
				dmg = 3;
			}
			else{
				dmg = 1;
			}
			
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"The cannon is expected to deal {dmg} damage this round.");
			
			Console.Write("Enter desired cannon range: ");
			cannonRange = Convert.ToInt32(Console.ReadLine());
			
			if(cannonRange == dist){
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("That round was a DIRECT HIT!");
				mcleftHP -= dmg;
			}
			else if(cannonRange > dist){
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("That round OVERSHOT the target.");
				
			}
			else{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("That round FELL SHORT of the target.");
				
			}
			Console.ForegroundColor = ConsoleColor.White;
			cityleftHP -= 1;
		
			turnNum++;
			
			if(mcleftHP <= 0){
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
				break;
			}
			if(cityleftHP <= 0){
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("The city of Consolas has been destroyed...");
				break;
			}
		}
    }
}