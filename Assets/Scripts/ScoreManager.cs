using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _totalScore = 0;
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private GameEvent _onChangeScore;
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private void Start()
    {
        _totalScore = _playerData.TotalScore;
        _onChangeScore.Raise(this, _totalScore);
    }

    public void IncreaseScore()
    {
        _totalScore += _scoreToAdd;
        _onChangeScore.Raise(this, _totalScore);
    }

    public void SaveScoreData()
    {
        _playerData.TotalScore = _totalScore;
    }
}
