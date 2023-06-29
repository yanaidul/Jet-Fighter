using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton; 

    private int _currentPageIndex = 0; 

    private void OnEnable()
    {
        _currentPageIndex = 0;
        ShowPage(_currentPageIndex); 
        UpdateButtonStates(); 
    }

    public void ShowNextPage()
    {
        int nextPageIndex = _currentPageIndex + 1;

        if (nextPageIndex < _pages.Length)
        {
            ShowPage(nextPageIndex);
            UpdateButtonStates(); 
        }
    }

    public void ShowPreviousPage()
    {
        int previousPageIndex = _currentPageIndex - 1;

        if (previousPageIndex >= 0)
        {
            ShowPage(previousPageIndex);
            UpdateButtonStates(); 
        }
    }

    private void ShowPage(int pageIndex)
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            _pages[i].SetActive(false);
        }

        _pages[pageIndex].SetActive(true);

        _currentPageIndex = pageIndex;
    }

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