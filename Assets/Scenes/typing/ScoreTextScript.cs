using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{

    Text text;
    private int zeroholder = 0;
    public static int textAmount;
 
    void Start()
    {
        textAmount = zeroholder;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: "+ textAmount.ToString();
    }
}
