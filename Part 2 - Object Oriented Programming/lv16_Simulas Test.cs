using System;

class lv16_Simulas_Test{
    static void Main(string[] args){
    	ChestState chest = ChestState.Locked;
		
		while(true){
			Console.Write($"The chest is {chest}. What do you want to do? ");
			string input = Console.ReadLine();
			
			if(chest == ChestState.Locked && input == "unlock"){
				chest = ChestState.Closed;
			}
			if(chest == ChestState.Closed && input == "open"){
				chest = ChestState.Open;
			}
			if(chest == ChestState.Open && input == "close"){
				chest = ChestState.Closed;
			}
			if(chest == ChestState.Closed && input == "lock"){
				chest = ChestState.Locked;
			}
		}
		
	}	
	enum ChestState {Open, Closed, Locked}
}