using System;

class Door{
	public DoorState _state;
	public int _pw;
	
	public Door(int newPw){
		_state = DoorState.Closed;
		_pw = newPw;
	}
	
	public void changePw(int currPw, int newPw){
		if(_pw == currPw){
			_pw = newPw;
		}
		else{
			Console.WriteLine("Incorrect Password");
		}
	}
	
	public void Open(){
		if(_state == DoorState.Closed){
			_state = DoorState.Opened;
			Console.WriteLine("Door is Opened.");
		}
	}
	
	public void Close(){
		if(_state == DoorState.Opened){
			_state = DoorState.Closed;
			Console.WriteLine("Door is Closed.");
		}
	}
	
	public void Lock(){
		if(_state == DoorState.Closed){
			_state = DoorState.Locked;
			Console.WriteLine("Door is Locked.");
		}
	}
	
	public void Unlock(int currPw){
		if(_state == DoorState.Locked && _pw == currPw){
			_state = DoorState.Closed;
			Console.WriteLine("Door is Unlocked (closed).");
		}
		else if(_state == DoorState.Locked && _pw != currPw){
			Console.WriteLine("Incorrect Password.");
		}
	}
}

enum DoorState {Closed, Opened, Locked}

class DoorTest{
	static void Main(string[] args){
		Door newDoor = new Door(217);
		newDoor.Open();
		newDoor.Open();
		newDoor.Close();
		newDoor.Close();
		newDoor.Lock();
		
		newDoor.Unlock(999);
		newDoor.Unlock(217);
		
		newDoor.changePw(217, 999);
		newDoor.Lock();
		newDoor.Unlock(999);
	}
}
