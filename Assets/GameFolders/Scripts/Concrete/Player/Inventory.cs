using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
    public class ObjectnType{
        public  GameObject item;
       public ItemType type;

    }

public class Inventory : MonoBehaviour
{

    [SerializeField] List<ObjectnType> itemsToHold=new List<ObjectnType>();

public   ItemType currentType;


void Start()
{

currentType=ItemType.NONE;

 
}





public void TakeItem(ItemType type)
{
    if(currentType!=ItemType.NONE) return;
    currentType=type;
Debug.Log(currentType);

        foreach(ObjectnType itemhold in itemsToHold)
        {
            if(itemhold.type!=type)
            {
                itemhold.item.SetActive(false);
            }
            else{
                itemhold.item.SetActive(true);
            }
        }
}

public ItemType PutItem()
{
        if(currentType==ItemType.NONE) return ItemType.NONE;
        return currentType;
}



public void ClearHand()
{
    currentType=ItemType.NONE;
      itemsToHold.ForEach(obj=>obj.item.SetActive(false));
}
public ItemType GetItem(){
    return currentType;
}



}
