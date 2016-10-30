using UnityEngine;
using System.Collections;

public class Consumables {
	
	public class SmallPotion : Potion 
	{
		public SmallPotion() : base("Small Potion", 10, ItemClass.Potion)
		{
			
		}
	}

    public class NormalRageDrug : RageDrug
    {
        public NormalRageDrug() : base("Rage Drug",10, ItemClass.RageDrug)
        {

        }
    }
}
