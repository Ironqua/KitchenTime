using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerObjectPool : MonoBehaviour
{
    [SerializeField] public List<GameObject> customerPrefab= new List<GameObject>();
    [SerializeField] Transform customerSpawnPos;

    GameObject notListedGameObjects;



     void Start()
    {
        CustomerSpawn();    
    }


    void CustomerSpawn()
    {
        customerPrefab[0].SetActive(true);

        notListedGameObjects=customerPrefab[0];


    customerPrefab.RemoveAt(0);

        Invoke("GetToPool",25f);


    }


    void GetToPool(){
        customerPrefab.Add(notListedGameObjects);
        notListedGameObjects.transform.position=customerSpawnPos.position;
        notListedGameObjects.SetActive(false);
        CustomerSpawn();
    }
}
