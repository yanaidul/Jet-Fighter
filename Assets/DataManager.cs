using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private int _highscore;
    private string _playerName;

    public int HighScore => _highscore;
    public string PlayerName => _playerName;

    public void SavePlayerPrefs(int highScore, string playerName)
    {
        PlayerPrefs.SetInt("Highscore", highScore);
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs()
    {
        _highscore = PlayerPrefs.GetInt("Highscore", 0);
        _playerName = PlayerPrefs.GetString("PlayerName", "Player1");
    }
}
