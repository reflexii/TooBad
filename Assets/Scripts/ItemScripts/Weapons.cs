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

    public class ShortBow : RangedWeapon
    {
        public ShortBow() : base("Short Bow",5,5,1,10,7,ProjectileType.Arrow, Color.yellow)
        {

        }
    }

    public class FireWand : RangedWeapon
    {
        public FireWand() : base("Fire Wand", 5, 5, 1, 7, 12, ProjectileType.FireBall, Color.green)
        {

        }
    }

    public class Boomerang : RangedWeapon
    {
        public Boomerang() : base("Boomerang", 5, 5, 1, 1, 12, ProjectileType.Boomerang, Color.green)
        {

        }
    }
}
