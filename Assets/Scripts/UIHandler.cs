using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    [SerializeField] private GameObject _newHighScoreUI;
    [SerializeField] private GameObject _gameoverUI;
    [SerializeField] private GameObject _pauseUI;

    //Function yang terpanggil bila game dimulai
    private void Awake()
    {
        Time.timeScale = 1;
    }

    //Function yang terpanggil untuk menonaktifkan semua UI canvas (gameover,pause,victory)
    private void DisableAllUI()
    {
        _victoryUI.SetActive(false);
        if(_newHighScoreUI != null) _newHighScoreUI.SetActive(false);
        _gameoverUI.SetActive(false);
        _pauseUI.SetActive(false);
    }

    //Function yang terpanggil untuk menampilkan victory UI
    public void OnVictoryUI()
    {
        DisableAllUI();
        if (ScoreManager.GetInstance().TotalScore > PlayerPrefs.GetInt("Highscore", 0) && _newHighScoreUI != null) _newHighScoreUI.SetActive(true);
        else _victoryUI.SetActive(true);
        Time.timeScale = 0;
    }

    //Function yang terpanggil untuk menampilkan game over UI
    public void OnGameOverUI()
    {
        DisableAllUI();
        _gameoverUI.SetActive(true);
        Time.timeScale = 0;
    }

    //Function yang terpanggil untuk menampilkan pause UI
    public void OnPauseUI()
    {
        DisableAllUI();
        _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    //Function yang terpanggil untuk melanjutkan permainan setelah kembali dari pause
    public void OnResume()
    {
        DisableAllUI();
        Time.timeScale = 1;

    }

}
