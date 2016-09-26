using UnityEngine;
using System.Collections;

public class Weapons 
{
	public class ShortSword : Weapon
	{
		public ShortSword() : base ("Short Sword",5,5, Color.black)
		{
			
		}
	}

	public class LongSword : Weapon
	{
		public LongSword() : base ("Long Sword",10,5, Color.blue)
		{

		}
	}
}
