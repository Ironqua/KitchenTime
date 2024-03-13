
using System.Collections.Generic;

using UnityEngine;


public class SliceBoard :Functionality,IPutItemFull
{

  [SerializeField] List<ObjectnType> itemsToHold=new List<ObjectnType>();

  ItemType currentType;
   SlıceUI slice;

  
  



  void Start()
  {
    currentType=ItemType.NONE;
    slice=GetComponent<SlıceUI>();
  }

    public override ItemType Process()
    {

        if(currentType==ItemType.NONE) return ItemType.NONE;
        //base.Process();

        currentTime+=Time.deltaTime;



        slice.UpdateClock(currentTime,maxTime);

        
        if(currentTime>=maxTime)
        {

          currentTime=0f;
                  slice.UpdateClock(currentTime,maxTime);


            switch(currentType)
            {
                case ItemType.TOMATO:
                
                return ItemType.SLICEDTOM;
                
                case ItemType.LETTUCE:
               
                return ItemType.SLICEDLET;
                
                case ItemType.ONION:
                
                return ItemType.SLICEDON;
                
                case ItemType.CHEESE:
                
                return ItemType.SLICEDCHEESE;
                
                case ItemType.MEATBALL:
                
                return ItemType.COOKEDMEAT;
                
                case ItemType.BREAD:
                
                return ItemType.SLICEDBREAD;
                
              
            
               


            }
       
        }
            
            return ItemType.NONE;

    }

public override void ClearObject()
{
    base.ClearObject();
        currentType=ItemType.NONE;
                itemsToHold.ForEach(obj=>obj.item.SetActive(false));


}
    public bool PutItem(ItemType item)
    {
        if(FilterItem(item)==false) return false;
        
       if(currentType!=ItemType.NONE) return false;
    currentType=item;


        foreach(ObjectnType itemhold in itemsToHold)
        {
            if(itemhold.type!=currentType)
            {
                itemhold.item.SetActive(false);
            }
            else{
                itemhold.item.SetActive(true);
            }
        }
        return true;
    }




    private bool FilterItem(ItemType item)
    {
         switch(item)
            {
                case ItemType.TOMATO:
                case ItemType.LETTUCE:
        
                case ItemType.ONION:
                case ItemType.CHEESE:
            
                case ItemType.MEATBALL:
                case ItemType.BREAD: 
                return true;
                
            default:
            return false;
                
              
            
               


            }




    }
}
