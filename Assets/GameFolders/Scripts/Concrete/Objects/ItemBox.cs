using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, IGetItem
{
[SerializeField] ItemType item;
    public virtual ItemType GetItem()
    {
     return item;
    }

  
    public void SetType(ItemType type)
    {
item=type;
    }
     public ItemType GetCurrentType()
     {
        return item;
      }

  
}