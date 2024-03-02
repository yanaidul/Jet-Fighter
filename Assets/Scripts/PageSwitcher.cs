using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton; 

    private int _currentPageIndex = 0;

    //Function yang terpanggil pada saat gameobject aktif
    private void OnEnable()
    {
        _currentPageIndex = 0;
        ShowPage(_currentPageIndex); 
        UpdateButtonStates(); 
    }

    //Function untuk pindah ke UI halaman selanjutnya
    public void ShowNextPage()
    {
        int nextPageIndex = _currentPageIndex + 1;

        if (nextPageIndex < _pages.Length)
        {
            ShowPage(nextPageIndex);
            UpdateButtonStates(); 
        }
    }

    //Function untuk pindah ke UI halaman sebelumnya
    public void ShowPreviousPage()
    {
        int previousPageIndex = _currentPageIndex - 1;

        if (previousPageIndex >= 0)
        {
            ShowPage(previousPageIndex);
            UpdateButtonStates(); 
        }
    }

    //Function untuk menampilkan halaman UI yang spesifik beserta indexnya
    private void ShowPage(int pageIndex)
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            _pages[i].SetActive(false);
        }

        _pages[pageIndex].SetActive(true);

        _currentPageIndex = pageIndex;
    }

    //Function untuk update state button halaman selanjutnya dan halaman sebelumnya (contoh button hlmn sebelumnya mati bila page index 0, dan aktif ketika page index diatas 0. Hal yang serupa berlaku juga untuk button halaman selanjutnya)
    private void UpdateButtonStates()
    {
        if (_nextButton != null)
        {
            _nextButton.SetActive(_currentPageIndex < _pages.Length - 1);
        }

        if (_previousButton != null)
        {
            _previousButton.SetActive(_currentPageIndex > 0);
        }
    }
}