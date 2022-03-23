using System;

class lv19_Arrows{
	
	enum ArrowHead {Steel, Wood, Obsidian}
	enum Fletching {Plastic, TurkeyFeather, GooseFeather}
	
	public ArrowHead GetArrowHead(){
	Console.WriteLine("Arrowhead Shop: ");
	Console.WriteLine("Steel: 10 gold");
	Console.WriteLine("Wood: 3 gold");
	Console.WriteLine("Obsidian: 5 gold");
	Console.Write("Which arrowhead do you want? ");
	string input = Console.ReadLine();
	
	return input switch{
        "steel" => ArrowHead.Steel,
        "wood" => ArrowHead.Wood,
        "obsidian" => ArrowHead.Obsidian
    };
	}

	
    static void Main(string[] args){
		Console.WriteLine("Hello");
	}
}

class Arrow{
	private ArrowHead _head;
	private Fletching _fletching;
	private int _shaft;
	
	public Arrow(){
		_head = ArrowHead.Steel;
		_fletching = Fletching.Plastic;
		_shaft = 60;
	}
}


//Arrow personalArrow = new Arrow();


