
using UnityEngine;

public class StoveBox :ItemBox
{
   public  bool canTake;
[SerializeField] Stove stove;
    public override ItemType GetItem()
    {
        if(!canTake) return ItemType.NONE;
        stove.CloseCookedMeat();
        canTake=false;
        return base.GetItem(); 
    }



    




    
}
 