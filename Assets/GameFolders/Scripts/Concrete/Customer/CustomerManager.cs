using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerManager : MonoBehaviour
{   
public static CustomerManager Instance;

    [SerializeField] private Queue<Customer> customerList= new Queue<Customer>();
    [SerializeField] List<Customer> customerPrefab=new List<Customer>();
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform exitPos;

    [SerializeField] float spawnInterval = 5f;
    [SerializeField] int spawnsPerInterval = 1; 
      float initialDelay = 5f;
    bool spawnStarted = false;

    


    void Awake()
    {
        Instance=this;
        
    }

    void Update()
    {
          if (WorldTİme.currentTime == 11 && !spawnStarted&& WorldTİme.currentTime<=20)
        {
            StartCoroutine(SpawnObj());
            spawnStarted = true;
        }
    }

    public IEnumerator SpawnObj()
    {
            yield return new WaitForSeconds(initialDelay); 

        while (true)
        {
            for (int i = 0; i < spawnsPerInterval; i++)
            {
            
            Vector3 newSpawnPos=spawnPos.position+(spawnPos.forward*-1*customerList.Count);
            Customer temp=Instantiate(customerPrefab[Random.Range(0,customerPrefab.Count)],newSpawnPos,Quaternion.Euler(-90f,0f,0f));
            customerList.Enqueue(temp);
            }
            yield return new WaitForSeconds(spawnInterval); 
        }
           


    }

    public void SellToCustomer()
    {
        if(customerList.Count==0) return;
        Customer firstCustomer=customerList.Peek();
        firstCustomer.ExitFromArea(exitPos.position);
        customerList.Dequeue();
        
        
        for(int i=0;i<customerList.Count;i++)
        { 
            Vector3 newSpawnPos=spawnPos.position+(spawnPos.forward*-1*i);
            customerList.ToArray()[i].MoveNext(newSpawnPos);
            
        }
        
    }


 
}
