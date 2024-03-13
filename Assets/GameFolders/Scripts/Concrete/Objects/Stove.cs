
using UnityEngine;

public class Stove : MonoBehaviour, IPutItemFull
{
bool isFull;
[SerializeField] float cookedTime;
[SerializeField] GameObject cookedItem;
[SerializeField] float currentTime;
[SerializeField] StoveBox itemBox;
SlıceUI sliceUI;
void Start()
{
    sliceUI=GetComponent<SlıceUI>();
    cookedItem.SetActive(false);
}

void Update()
{
 if(isFull)
 {
    sliceUI.UpdateClock(currentTime,cookedTime);
    currentTime+=Time.deltaTime;
    if(currentTime>=cookedTime)
    {
    sliceUI.UpdateClock(currentTime,cookedTime);
        currentTime=0f; 
        cookedItem.SetActive(true);
        itemBox.SetType(ItemType.COOKEDMEAT); 
        itemBox.canTake=true;
        isFull=false;
    }
 }
 
}


public void CloseCookedMeat()
{
cookedItem.SetActive(false);
}



    public bool PutItem(ItemType item)

    {

        if(item!=ItemType.MEATBALL) return false;
         if(isFull!) return false;
    isFull=true;
              return true;
        
    }
}
