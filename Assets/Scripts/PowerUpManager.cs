using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _supportUnitReference;
    [SerializeField] private int _numberOfActivatedSupport;
    [SerializeField] private PlayerDataScriptableObject _playerData;

    #region Properties
    public int NumberOfActivatedSupport
    {
        get => _numberOfActivatedSupport;
        set
        {
            _numberOfActivatedSupport = value;
            if (_numberOfActivatedSupport <= 0)
            {
                _numberOfActivatedSupport = 0;
            }

            if (_numberOfActivatedSupport > 2)
            {
                _numberOfActivatedSupport = 2;
            }
            SetTotalOfSupport(value);
        }
    }
    #endregion

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        NumberOfActivatedSupport = _playerData.SupportCount;
    }

    //Function yang terpanggil untuk set total support pesawat pada saat game dimulai
    private void SetTotalOfSupport(int value)
    {
        for (int i = 0; i < _supportUnitReference.Length; i++)
        {
            if(i < value)
            {
                _supportUnitReference[i].SetActive(true);
            }
            else
            {
                _supportUnitReference[i].SetActive(false);
            }
            
        }
    }
    //Function yang terpanggil untuk save support data
    public void SaveSupportData()
    {
        _playerData.SupportCount = NumberOfActivatedSupport;
    }
}
