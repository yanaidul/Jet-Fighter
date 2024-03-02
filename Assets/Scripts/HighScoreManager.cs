using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject _highScoreContainer;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _playerNameText;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        OnLoad();

        UpdateUI();
    }


    //Function untuk load UI highscore di main menu bila sudah ada highscore yang masuk
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

    //Function untuk update UI highscore di main menu bila sudah ada highscore yang masuk
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
