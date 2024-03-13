
using UnityEngine;
using UnityEngine.UI;

public class WorldTİme : MonoBehaviour
{
 [SerializeField] float value=60f;
[SerializeField] Text timeText;
[SerializeField] float day_cycle=20;
Vector3 rot=Vector3.zero;
public static float currentTime=10f;
float tempsecond;
int minute;
public int hour;
int days;


void Start()
 {
    hour=10;
   
}

void Update()
{
    TimeClock();
    LightRot();
   


   
}
public void TimeClock()
{
 tempsecond+=Time.deltaTime;
 if(tempsecond>=value)
 {
     minute++;
    tempsecond=0;
    if(minute==60)
        {
          hour++;
           minute=0;

           if(hour==24)
                {
                    days++;
                    hour=0;
                }
         }
  }

 timeText.text = string.Format("{0} DAY {1}:{2}", days, hour.ToString("00"), minute.ToString("00"));

  currentTime=hour;

 }


void LightRot()
{  
     rot.x=day_cycle*Time.deltaTime;
        transform.Rotate(rot,Space.World);

}



}
