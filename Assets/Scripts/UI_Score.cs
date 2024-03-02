using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private const string SCORE_FORMAT = "{0:0000000000}";

    private string _formattedScore;

    //Function yang terpanggil untuk mengubah tampilan UI score player dengan format "0000000000"
    public void OnChangeScoreText(Component sender, object data)
    {
        if (data is int)
        {
            _formattedScore = string.Format(SCORE_FORMAT, data);
            _scoreText.text = _formattedScore;
        }
    }

    //Function yang terpanggil untuk mengubah tampilan UI score player tanpa format
    public void OnChangeScoreTextWithoutFormat(Component sender, object data)
    {
        if (data is int)
        {
            _scoreText.text = data.ToString();
        }
    }
}
