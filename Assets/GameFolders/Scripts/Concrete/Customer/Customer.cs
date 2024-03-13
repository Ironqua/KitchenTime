using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class Customer : MonoBehaviour
{
string[] customerWords =
{
"Bad delivery !!",
"Bad taste!!",
"Good taste!!",
"Order delayed!!",
"Fast delivery!!"
};
    [SerializeField] GameObject _hamburger;
    public TMP_Text customerText;
    string mixedText;

    void Start()
    {
      int rastgeleIndex = Random.Range(0, customerWords.Length);
         mixedText = customerWords[rastgeleIndex];
    }
  public void ExitFromArea(Vector3 pos)
  {
         Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f); 
        transform.DOMove(pos,3).OnComplete(()=>{Destroy(this.gameObject);});

    transform.DORotateQuaternion(targetRotation, 3);
_hamburger.SetActive(true);
CustomerText();
customerText.gameObject.SetActive(true);
  }

  public void MoveNext(Vector3 pos)
  {
    transform.DOMove(pos,2);
  }


  void CustomerText()
  {
    customerText.text=mixedText;
  }




}
