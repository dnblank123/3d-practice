using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image background1;
    public Image background2;

    public Image background3;
    public Animator animator;

    public void SwitchImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            background1.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
        }
        if(!isSwitched) 
        {
            background2.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
        }
        
        if(!isSwitched) 
        {
            
            background3.sprite = sprite;
            animator.SetTrigger("SwitchThird");

            
        }
        //isSwitched = !isSwitched;
        
    }
    public void SetImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            background1.sprite = sprite;
            
        }
        if(!isSwitched) 
        {
            background2.sprite = sprite;
        }
        if(!isSwitched) 
        {
            background3.sprite = sprite;
        }
    }

}
