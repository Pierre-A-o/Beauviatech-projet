using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerMenuMovement : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject hiddenPosition;
    public GameObject revealedPosition;

    
    public bool isRevealed;
    public float speed = 2f;
    private Transform cible;

    public float tempMenuPosition;

    // Start is called before the first frame update
    void Start()
    {
        isRevealed = false;
        cible = revealedPosition.transform;
        menuPanel.transform.position = hiddenPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRevealed){
            this.hideOrRevealMenu(revealedPosition, hiddenPosition);
        }else{
            this.hideOrRevealMenu(hiddenPosition, revealedPosition);
        }
    }

     private void hideOrRevealMenu(GameObject targetPositionObject, GameObject currentPositionObject)
     {

        menuPanel.transform.position = Vector3.Lerp(menuPanel.transform.position, targetPositionObject.transform.position, Time.deltaTime * speed);

       if (menuPanel.transform.localPosition.x == tempMenuPosition)
        {
            isRevealed = false;
            menuPanel.transform.position = targetPositionObject.transform.position;
            tempMenuPosition = -99999999999999999.99f;
        }

        if(isRevealed)
            tempMenuPosition = menuPanel.transform.position.x;
            
     }


     
     public void clickOnHamburgerButton()
     {
        isRevealed = !isRevealed;
     }
}
