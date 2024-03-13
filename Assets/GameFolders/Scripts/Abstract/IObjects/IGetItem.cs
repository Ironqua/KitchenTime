using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
   TOMATO,LETTUCE,ONION,CHEESE,MEATBALL,BREAD,NONE,SLICEDTOM,SLICEDLET,SLICEDON,COOKEDMEAT,SLICEDBREAD,SLICEDCHEESE,PLATE,SLICEDBREAD2,HAMBURGER,SALAD
}
public interface IGetItem 
{
   public ItemType GetItem();
}
