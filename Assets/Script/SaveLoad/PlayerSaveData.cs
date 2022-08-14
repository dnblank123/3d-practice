using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad  {
public class PlayerSaveData : MonoBehaviour
{
    public HealthSystem HealthSys;
    private PlayerData MyData = new PlayerData();

    void LateUpdate()
    {
        var transform1 = transform;
        MyData.PlayerPosition = transform1.position;
        MyData.PlayerRotation = transform1.rotation;
        MyData.CurrentHealth = HealthSys.currentHealth;

    }
    public void SaveButton()
    {
        SaveGameManager.CurrentSaveData.PlayerData = MyData;
        SaveGameManager.Save();
    }
        public void LoadButton()
    {
        Time.timeScale = 1f;
        SaveGameManager.Load();
        MyData = SaveGameManager.CurrentSaveData.PlayerData;
        transform.position = MyData.PlayerPosition;
        transform.rotation = MyData.PlayerRotation;
        HealthSys.currentHealth = MyData.CurrentHealth;
        Invoke(nameof(PauseAgain), 0.01f);

    }
    public void PauseAgain()
    {
        Time.timeScale = 0f;
    }



}
    [System.Serializable]
    public struct PlayerData
    {
        public Vector3 PlayerPosition;
        public Quaternion PlayerRotation;
        public float CurrentHealth;
    }
}

