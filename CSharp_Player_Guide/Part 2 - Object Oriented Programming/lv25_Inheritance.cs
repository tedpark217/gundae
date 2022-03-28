using System;

//superclass
class InventoryItem{
	public double Weight {get; set;}
	public double Volume {get; set;}

	public InventoryItem(double newWeight, double newVolume){
		Weight = newWeight;
		Volume = newVolume;
	}
}

//subclasses
class Arrow : InventoryItem{
	public Arrow() : base(0.1, 0.05){}	
	
	public override string ToString(){
		return "Arrow";
	}
}

class Bow : InventoryItem{
	public Bow() : base(1.0, 4){}	
	
	public override string ToString(){
		return "Bow";
	}
}

class Rope : InventoryItem{
	public Rope() : base(1.0, 1.5){}	
	
	public override string ToString(){
		return "Rope";
	}
}

class Water : InventoryItem{
	public Water() : base(2.0, 3.0){}	
	
	public override string ToString(){
		return "Water";
	}
}

class Food : InventoryItem{
	public Food() : base(1.0, 0.5){}	
	
	public override string ToString(){
		return "Food";
	}
}

class Sword : InventoryItem{
	public Sword() : base(5.0, 3.0){}	
	
	public override string ToString(){
		return "Sword";
	}
}


class Pack{
	private InventoryItem[] _items;
	public int ItemLimit {get;}	
	public double WeightLimit {get;}
	public double VolLimit {get;}
	
	private int _currItems;
	private double _currWeight;
	private double _currVol;
	
	public Pack(int numOfItems, double maxWeight, double maxVolume){
		_items = new InventoryItem[numOfItems];
		ItemLimit = numOfItems;
		WeightLimit = maxWeight;
		VolLimit = maxVolume;
		_currItems = 0;
		_currWeight = 0.0;
		_currVol = 0.0;
	}
	
	public override string ToString(){
		string output = "Pack containing";
		for(int i = 0; i < _currItems; i++){
			output += $" {_items[i]}";
		}
		output += ".";
		
		return output;
	}
	
	public void report(){
		Console.WriteLine("Current Pack Info. ");
		Console.WriteLine($"Item Limit: {ItemLimit}, Weight Limit: {WeightLimit}, Volume Limit: {VolLimit}.");
		Console.WriteLine($"Currently has {_currItems} items with {_currWeight} weight and {_currVol} volume.");
	}
	
	public bool Add(InventoryItem item){
		//check if pack is full
		if(_currItems >= ItemLimit){
			return false;
		}
		
		//check if enough weight and volume is left
		if(_currWeight + item.Weight <= WeightLimit && _currVol + item.Volume <= VolLimit){
			_items[_currItems] = item;
			_currItems++;
			_currWeight += item.Weight;
			_currVol += item.Volume;
			return true;
		}
		
		return false;
	}
}

class PackTest{
	public static void Main(string[] args){
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("Let's create your custom Pack.");
		
		int itemNo = 5;
		double weightMax = 5.0;
		double volMax = 5.0;
		
		Pack customPack = new Pack(itemNo, weightMax, volMax);
		customPack.report();
		
		bool full = false;
		while(!full){
			Console.WriteLine("There are arrow, bow, rope, water, food, sword in the shop.");
			Console.Write("Which item do you want to add to your Pack?: ");
			
			string input = Console.ReadLine();
			InventoryItem newItem = new InventoryItem(0,0); 
			
			switch (input){
				case "arrow":
					newItem = new Arrow();
					break;
				case "bow":
					newItem = new Bow();
					break;
				case "rope":
					newItem = new Rope();
					break;
				case "water":
					newItem = new Water();
					break;
				case "food":
					newItem = new Food();
					break;
				case "sword":
					newItem = new Sword();
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("That item does not exist.");
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine();
					break;
			}
			
			if(newItem.Weight != 0 && newItem.Volume != 0){
				bool added = customPack.Add(newItem);
				if(added){
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Item added.");
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine();
					customPack.report();
				}
				else{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Pack is full.");
					full = true;
				}	
			}
		}
		
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine(customPack.ToString());
	}
}