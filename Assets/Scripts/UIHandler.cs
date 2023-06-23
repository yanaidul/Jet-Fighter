using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _victoryUI;
    [SerializeField] private GameObject _gameoverUI;
    [SerializeField] private GameObject _pauseUI;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void DisableAllUI()
    {
        _victoryUI.SetActive(false);
        _gameoverUI.SetActive(false);
        _pauseUI.SetActive(false);
    }

    public void OnVictoryUI()
    {
        DisableAllUI();
        _victoryUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameOverUI()
    {
        DisableAllUI();
        _gameoverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnPauseUI()
    {
        DisableAllUI();
        _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void OnResume()
    {
        DisableAllUI();
        Time.timeScale = 1;

    }

}
