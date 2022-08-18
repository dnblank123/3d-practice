using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManagerDisableScript2 : MonoBehaviour
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
        if(ScoreTextScript.textAmount == 20)
        {
            DefaultCanvas.SetActive(false);
            WordManagerDisable.SetActive(false);
        }
    }

}
