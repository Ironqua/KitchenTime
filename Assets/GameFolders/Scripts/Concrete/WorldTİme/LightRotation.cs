using UnityEngine;

public class Tutorial5 : MonoBehaviour
{

    Vector3 rot=Vector3.zero;
   [SerializeField] float day_cycle=20;
   
    void Update()
    {
        rot.x=day_cycle*Time.deltaTime;
        transform.Rotate(rot,Space.World);
        
    }
}


