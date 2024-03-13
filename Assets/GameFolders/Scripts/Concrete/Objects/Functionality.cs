using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Functionality : MonoBehaviour
{
   public float maxTime;
   public float currentTime;
    public bool processStarted;

   public virtual ItemType Process()
   {
    return ItemType.NONE;
   }
   public virtual void ClearObject()
   
   {

   }

   public void ResetTime()
   {
      currentTime=0f;
   }
}
  