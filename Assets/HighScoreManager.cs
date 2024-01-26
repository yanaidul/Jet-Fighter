using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject _highScoreContainer;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _playerNameText;

    private void Start()
    {
        OnLoad();

        UpdateUI();
    }

    private void OnLoad()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            _highScoreContainer.SetActive(false);
            return;
        }

        _highScoreContainer.SetActive(true);
        DataManager.GetInstance().LoadPlayerPrefs();
    }

    private void UpdateUI()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            return;
        }

        _highScoreText.SetText(DataManager.GetInstance().HighScore.ToString());
        _playerNameText.SetText(DataManager.GetInstance().PlayerName);
    }
}
