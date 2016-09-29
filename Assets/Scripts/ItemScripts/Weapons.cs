using UnityEngine;
using System.Collections;

public class Weapons 
{
	public class ShortSword : MeleeWeapon
	{
		public ShortSword() : base ("Short Sword",5,5,40,90,1,500,Color.black)
		{
			
		}
	}

	public class LongSword : MeleeWeapon
    {
		public LongSword() : base ("Long Sword",10,5,40,90,2,300, Color.blue)
		{

		}
	}
}
