using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
public class SaveLoadDo : MonoBehaviour
{

    public void SaveGame()
    {
        SaveGameManager.Save();
    }
    public void LoadGame()
    {
        SaveGameManager.Load();
    }
}
}

