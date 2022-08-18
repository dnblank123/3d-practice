using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationScript : MonoBehaviour
{
    public ScoreTextScript Score; 
    public GameObject WordManagerDisable;

    void Start()
    {
        
    }

    void Update()
    {
        DisableIfDone();
    }

    public void DisableIfDone()
    {
        if(ScoreTextScript.textAmount == 10)
        {
            WordManagerDisable.SetActive(false);
        }
    }

}
