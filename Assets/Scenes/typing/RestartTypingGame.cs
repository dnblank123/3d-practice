using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTypingGame : MonoBehaviour
{
    public HealthSystem HP;
    public GameObject resetCanvas;
    public GameObject WordManagerDisable;
    public GameObject DefaultCanvas;

    private void Update() 
    {
        CheckHPFail();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CheckHPFail()
    {
        if(HP.currentHealth == 0)
        {
            resetCanvas.SetActive(true);
            DefaultCanvas.SetActive(false);
            WordManagerDisable.SetActive(false);
        }
    }
}
