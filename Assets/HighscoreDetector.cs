using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighscoreDetector : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;

    public void OnSaveDataToHighscore()
    {

        if(DataManager.GetInstance() != null)
        {
            DataManager.GetInstance().SavePlayerPrefs(ScoreManager.GetInstance().TotalScore, _nameInputField.text);
            Debug.Log("Save Data Success");
        }
    }


}
