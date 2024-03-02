using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Health : MonoBehaviour
{
    [SerializeField] private GameObject[] _health;
    [SerializeField] private int _initHealth;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        for (int i = 0; i < _health.Length; i++)
        {
            if (i < _initHealth)
            {
                _health[i].SetActive(true);
            }
            else
            {
                _health[i].SetActive(false);
            }
        }
    }

    //Function yang terpanggil untuk mengubah tampilan UI total health player
    public void OnChangeHealthUI(Component sender, object data)
    {
        if (data is int)
        {
            for (int i = 0; i < _health.Length; i++)
            {
                if(i < (int)data)
                {
                    _health[i].SetActive(true);
                }
                else
                {
                    _health[i].SetActive(false);
                }
            }
        }

    }
}
