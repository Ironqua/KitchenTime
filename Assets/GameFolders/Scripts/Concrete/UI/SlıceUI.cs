using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlıceUI:MonoBehaviour
{
   
[SerializeField] public Image slider;




public void UpdateClock(float amount,float maxtime)
{
    slider.fillAmount=amount/maxtime;
}


}
