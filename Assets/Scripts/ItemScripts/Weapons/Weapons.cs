using UnityEngine;
using System.Collections;

public class Weapons 
{
	public class ShortSword : MeleeWeapon
	{
		public ShortSword() : base ("Short Sword",5,0,5,40,90,1,500,ItemClass.Sword)
		{
			
		}
	}

	public class LongSword : MeleeWeapon
    {
		public LongSword() : base ("Long Sword",10,0,5,40,90,2,300, ItemClass.Sword)
		{

		}
	}

    public class Fist : MeleeWeapon
    {
        public Fist() : base("Fist", 5, 1, 5,40, 90, 1, 300, ItemClass.Sword)
        {

        }
    }

    public class CrossBow : RangedWeapon
    {
        public CrossBow() : base("CrossBow",5,5,1,10,7,ProjectileType.Arrow, ItemClass.Crossbow)
        {

        }
    }

    public class AutomaticCrossBow : RangedWeapon
    {
        public AutomaticCrossBow() : base("Automatic Crossbow", 5, 5,0.08f, 10,100, ProjectileType.Arrow, ItemClass.Crossbow)
        {

        }
    }

    public class FireWand : RangedWeapon
    {
        public FireWand() : base("Fire Wand", 5, 5, 1, 7, 12, ProjectileType.FireBall, ItemClass.Sword)
        {

        }
    }

    public class Boomerang : RangedWeapon
    {
        public Boomerang() : base("Boomerang", 5, 5, 1, 1, 12, ProjectileType.Boomerang, ItemClass.Sword)
        {

        }
    }
}
