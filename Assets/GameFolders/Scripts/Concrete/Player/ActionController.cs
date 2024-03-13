
using UnityEngine;

public class ActionController : MonoBehaviour
{
 Animator anim;
 Inventory _inventory;
 

private Functionality currentFunc;
  private bool canPut = true;

 bool isWorking=false;
bool isProc=false;


 void Awake()
 {
    anim=GetComponent<Animator>();
    _inventory=GetComponent<Inventory>();
  
    

 }

void Update()
{
   if(Input.GetMouseButtonDown(0))
   {
        DoTakeAction();
    
    
       
   }
   else if(Input.GetMouseButton(0))
   {
    isWorking=true;
            if(isProc==false)
            {
                    StartProcAction();
            }
            else{
                DoProcAction();
            }
   }
   else if(Input.GetMouseButtonUp(0))
   {
    isWorking=false;
            if(isProc)
            {
                currentFunc.ResetTime();
                isProc=false;
            }
   }
   else if(Input.GetKeyDown(KeyCode.E))
   {
    //GameManager.instance.Unlock();
    BuyObject();
   }
}

private void StartProcAction()
{
     Ray ray = new Ray(transform.position + Vector3.up / 2, transform.forward);
    if(Physics.Raycast(ray,out RaycastHit  hit ,1f))
    {

        if(hit.collider.TryGetComponent<Functionality>(out Functionality  itemProc))
        {
            isProc=true;
     
           currentFunc=itemProc;
        }       
    }

}


void DoProcAction()
{
    if(!isProc) return;
    if (!isWorking) return;
        
        ItemType item = currentFunc.Process();
        if (item != ItemType.NONE)
        {
           currentFunc.ClearObject();
            _inventory.TakeItem(item);
            isWorking = false;
}
}


    public void DoTakeAction()
    {
anim.SetTrigger("Take");
        Ray ray = new Ray(transform.position + Vector3.up / 2, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1))
        {
            if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
            {
                if (canPut)
                {
                    bool status = itemPutBox.PutItem(_inventory.GetItem());
                    if (status == true)
                    {
                        _inventory.PutItem();
                        _inventory.ClearHand();
                    }
                }
            }
            if (hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
            {
                _inventory.TakeItem(itemBox.GetItem());
                
               
            }
            
        }
}

private void BuyObject()
{   
    
     Ray ray = new Ray(transform.position + Vector3.up / 2, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1))
        {
            if(hit.collider.TryGetComponent<UnlockObject>(out UnlockObject unlockObject))
            {

Debug.Log(hit.collider.gameObject.name);
                HandleUnlockObject(hit.collider.gameObject);


           }
        }
}
private void HandleUnlockObject(GameObject obj)
{
    if (obj.CompareTag("slıceboard"))
    {
        GameManager.instance.UnlockSlıceBoard();
    }
    else if (obj.CompareTag("Table"))
    {
        GameManager.instance.UnlockTable();
    }
    else if(obj.CompareTag("stove"))
    {
        GameManager.instance.UnlockStove();
    }

    obj.SetActive(false);
}

private void OnTriggerStay(Collider other)
{
    
    if(_inventory.currentType != ItemType.HAMBURGER) 
    {
        return;
    }

    if(other.gameObject.CompareTag("SellArea"))
    {
       
        if(Input.GetKey(KeyCode.Space))
        {
            GameManager.instance.EarnCoin();
            Debug.Log(GameManager.instance._coin);
            CustomerManager.Instance.SellToCustomer();
            _inventory.ClearHand();
        }
    }
}






}


 





