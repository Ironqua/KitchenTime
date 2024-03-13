
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed=10f;
    [SerializeField] float rotationalSpeed=0.1f;

   InputReader _inputReader;
    Rigidbody _playerRigidbody;

    Animator _playerAnimator;

 

   void Awake()
   {
    InitializeComponents();

    }


void Update()
{
    
    PlayerAnim(); 
   
    
}


void FixedUpdate()
{
    Movement(movespeed,rotationalSpeed);
    
}



public void Movement(float speed,float rotationalspeed)
{  
             Vector2 movePos=_inputReader.direction;
            _playerRigidbody.velocity=new Vector3(movePos.x,0f,movePos.y)*speed*Time.fixedDeltaTime;;

   


        if(movePos!=Vector2.zero)
        {
            Vector3 playerRot=new Vector3(movePos.x,0f,movePos.y);
            Quaternion rotation=Quaternion.LookRotation(playerRot,Vector3.up);
            transform.rotation=Quaternion.Lerp(transform.rotation,rotation,rotationalSpeed);
        }
}
    
public void PlayerAnim()
    {
            if(_inputReader.direction!=Vector2.zero){
                _playerAnimator.SetBool("isWalking",false);
            }
            else{
                _playerAnimator.SetBool("isWalking",true);
            }


    }
   


void InitializeComponents()
{
    _inputReader=GetComponent<InputReader>();
    _playerRigidbody=GetComponent<Rigidbody>();
    _playerAnimator=GetComponent<Animator>();

}




   
}
