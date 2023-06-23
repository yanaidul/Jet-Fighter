using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "ScriptableObject/PlayerDataScriptableObject")]
[Serializable]
public class PlayerDataScriptableObject : ScriptableObject
{
    [SerializeField] private int _totalHealth;
    public int TotalHealth
    {
        get
        {
            return _totalHealth;
        }

        set
        {
            _totalHealth = value;
            if (_totalHealth <= 0) _totalHealth = 0;
            if (_totalHealth > 10) _totalHealth = 10;
        }
    }

    [SerializeField] private int _totalScore;
    public int TotalScore
    {
        get
        {
            return _totalScore;
        }

        set
        {
            _totalScore = value;
            if (_totalScore <= 0) _totalScore = 0;
        }
    }
    [SerializeField] private int _supportCount;
    public int SupportCount
    {
        get
        {
            return _supportCount;
        }

        set
        {
            _supportCount = value;
            if (_supportCount <= 0) _supportCount = 0;
            if (_supportCount > 2) _supportCount = 2;
        }
    }

    private int _defaultLifePointTotal;
    private int _defaultTotalScore;
    private int _defaultSupportCount;

    private void OnEnable()
    {
        _defaultLifePointTotal = TotalHealth;
        _defaultTotalScore = TotalScore;
        _defaultSupportCount = SupportCount;
    }


    public void ResetData()
    {
        TotalHealth = 3;
        TotalScore = 0;
        SupportCount = 0;
    }

}
