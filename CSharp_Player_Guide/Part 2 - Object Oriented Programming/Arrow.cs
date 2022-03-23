using System;

class Arrow{
	//can't use init; cuz ubuntu 14..
	public ArrowHead _arrowhead {get; set; } = ArrowHead.Steel;
	public Fletching _fletching {get; set; } = Fletching.Plastic;
	public int _shaft {get; set;} = 0;
	
	public float GetCost(){
		float cost = 0;
		
		if(_arrowhead == ArrowHead.Steel){
			cost += 10; 
		}
		else if(_arrowhead == ArrowHead.Wood){
			cost += 3; 
		}
		else{
			cost += 5; 
		};
		
		if(_fletching == Fletching.Plastic){ 
			cost += 10; 
		}
		else if(_fletching == Fletching.TurkeyFeather){ 
			cost += 5; 
		}
		else{ 
			cost += 3;
		};
		
		cost += (float) (_shaft * 0.05);		
		
		return cost;
	}
}
	
enum ArrowHead {Steel, Wood, Obsidian}
enum Fletching {Plastic, TurkeyFeather, GooseFeather}

class Program{
	static void Main(string[] args){
		
		//Ask for arrowhead
		Console.WriteLine("Types of Arrowhead: ");
		Console.WriteLine("Steel: 10 gold");
		Console.WriteLine("Wood: 3 gold");
		Console.WriteLine("Obsidian: 5 gold");
		Console.Write("Which arrowhead do you want?: ");
		
		string input = Console.ReadLine();
		ArrowHead chosenHead;
		Console.WriteLine();
		
		if(input == "steel"){
			chosenHead = ArrowHead.Steel;
		}
		else if(input == "wood"){
			chosenHead = ArrowHead.Wood;
		}
		else{
			chosenHead = ArrowHead.Obsidian;
		};
		
		//Ask for shaft
		int chosenShaft;
		do{
			Console.WriteLine("Length of Shaft Possible (60 to 100cm):");
			Console.Write("How long do you want your shaft?: ");
		
			input = Console.ReadLine();
			chosenShaft = Convert.ToInt32(input);
		}
		while(chosenShaft < 60 || chosenShaft > 100);
		Console.WriteLine();
		
		//Ask for fletching
		Console.WriteLine("Types of Fletching: ");
		Console.WriteLine("Plastic: 10 gold");
		Console.WriteLine("Turkey feathers: 5 gold");
		Console.WriteLine("Goose feathers: 3 gold");
		Console.Write("Which type of fletching do you want? (plastic, turkeyfeather, goosefeather): ");
		
		input = Console.ReadLine();
		Fletching chosenFletching;
		Console.WriteLine();
		
		if(input == "plastic"){
			chosenFletching = Fletching.Plastic;
		}
		else if(input == "turkeyfeather"){
			chosenFletching = Fletching.TurkeyFeather;
		}
		else{
			chosenFletching = Fletching.GooseFeather;
		
		};
		
		Arrow newArrow = new Arrow() {_arrowhead = chosenHead, _shaft = chosenShaft, _fletching = chosenFletching};
		float totalcost = newArrow.GetCost();
		Console.WriteLine($"The cost of your arrow is {totalcost}.");
	}
}