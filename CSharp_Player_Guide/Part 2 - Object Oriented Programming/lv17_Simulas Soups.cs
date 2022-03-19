using System;

//(FoodType food, Ingredient ing, Seasoning ssing)[] menu = new (FoodType, Ingredient, Seasoning)[3];
(FoodType food, Ingredient ing, Seasoning ssing)[] menu = new (FoodType, Ingredient, Seasoning)[3];
for(int i = 0; i < menu.Length; i++){
	menu[i] = GetMenu();
}

foreach(var newmenu in menu){
	Console.WriteLine($"{newmenu.food} {newmenu.ing}, {newmenu.ssing}");
}

(FoodType, Ingredient, Seasoning) GetMenu(){
	Foodtype newFood = GetFood();
	Ingredient newIng = GetIngredient();
	Seasoning newSeasoning = GetSeasoning();
	
	return (newFood, newIng, newSeasoning);
}

FoodType GetFood(){
	Console.Write("Which type of food? (Soup, Stew, Gumbo)");
	string input = Console.ReadLine();
	
	return Food.Soup;
}

Ingredient GetIngredient(){
	return Ingredient.Mushroom;
}

Seasoning GetSeasoning(){
	return Seasoning.Spicy;
}

	
enum FoodType {Soup, Stew, Gumbo}
	
enum Ingredient {Mushroom, Chicken, Carrot, Potato}
	
enum Seasoning {Spicy, Salty, Sweet}
	