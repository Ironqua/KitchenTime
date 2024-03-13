using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

[SerializeField] GameObject kitchenCounter;
[SerializeField] GameObject kitchenTable;

[SerializeField] GameObject kitchenStove;
    [SerializeField] Text _coinText;
     public float _coin;

     float stovePrice=2f;
     float tablePrice=1f;

     float slıcePrice=1f;
   
     




    void Awake()
    {
        if(instance==null)
        {
            instance=this;
            
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    


public void EarnCoin()
{
        _coin++;
        _coinText.text="GOLD:"+_coin.ToString();
}

public void TextCoin()
{
    _coinText.text="GOLD:"+_coin.ToString();
}

public void UnlockSlıceBoard()
{
   
        if(_coin>=slıcePrice)
        {
              kitchenCounter.SetActive(true);
                _coin-=slıcePrice;
                 _coinText.text="GOLD:"+_coin.ToString();
                
                
        }
    
}

public void UnlockTable()
{
      if(_coin>=tablePrice)
        {
              kitchenTable.SetActive(true);
                _coin-=tablePrice;
                 _coinText.text="GOLD:"+_coin.ToString();
                
                
        }
}


public void UnlockStove()
{
    if(_coin>=stovePrice)
        {
              kitchenStove.SetActive(true);
                _coin-=stovePrice;
                 _coinText.text="GOLD:"+_coin.ToString();
                
                
        }
}




}
