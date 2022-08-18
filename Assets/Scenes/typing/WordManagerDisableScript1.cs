using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManagerDisableScript1 : MonoBehaviour
{
    public GameObject WordManagerDisable;
    public GameObject DefaultCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        DisableIfDone();
    }

    public void DisableIfDone()
    {
        if(ScoreTextScript.textAmount == 15)
        {
            DefaultCanvas.SetActive(false);
            WordManagerDisable.SetActive(false);
        }
    }

}
