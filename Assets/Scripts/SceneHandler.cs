using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] GameEventNoParam _onNextLevelEvent;
    [SerializeField] GameEventNoParam _onOnReturnToLevel1Event;

    //Function yang terpanggil untuk load next level scene
    public void OnNextLevel()
    {
        _onNextLevelEvent.Raise();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //Function yang terpanggil untuk restart scene
    public void OnRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Function yang terpanggil untuk masuk ke scene game
    public void OnPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    //Function yang terpanggil untuk kembali ke main menu
    public void OnMainMenuScene()
    {
        Time.timeScale = 1;
        if(BGM.instance != null) BGM.instance.DestroyBGMGameObject();
        _playerData.ResetData();
        SceneManager.LoadScene(0);
    }

    //Function yang terpanggil untuk keluar dari permainan
    public void OnQuit()
    {
        Application.Quit();
    }
}
