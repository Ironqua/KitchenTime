
using UnityEngine;

public class TrashBin : MonoBehaviour, IPutItemFull
{
   

    public bool PutItem(ItemType item)
    {
       return true;
    }
}
