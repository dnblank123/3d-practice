using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBGController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomController bottomBar;
    public BackgroundController backgroundController;
    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(bottomBar.isCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                }
                bottomBar.PlayNextSentence();
            }
        }
    }
}
