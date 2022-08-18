using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratulationEnableScript1 : MonoBehaviour
{
    public GameObject congratulationCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        EnableIfWin();
    }

    public void EnableIfWin()
    {
        if(ScoreTextScript.textAmount == 15)
        {
            congratulationCanvas.SetActive(true);
        }
        
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
