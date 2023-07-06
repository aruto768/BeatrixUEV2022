using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINavigationMenu : MonoBehaviour
{
    private GameObject _currentPanel;

    [SerializeField]
    private List<GameObject> _content;

    [SerializeField]
    private GameObject _menuContainer;

    private List<Toggle> _menuButtons;

    public void Awake()
    {
        _menuButtons = new List<Toggle>(GetComponentsInChildren<Toggle>());
    }

    public void Start()
    {
        foreach (GameObject content in _content)
        {
            content.SetActive(false);
        }

        foreach (Toggle button in _menuButtons)
        {
            button.GetComponent<Toggle>().isOn = false;
        }

        _content[0].SetActive(true);
        _menuButtons[0].GetComponent<Toggle>().isOn = true;
    }

    public void ShowPanel(GameObject panel)
    {
        if (_currentPanel != null)
        {
            _currentPanel.SetActive(false);
        }
        else
        {
            _content[0].SetActive(false);
        }

        _currentPanel = panel;
        _currentPanel.SetActive(true);
    }

    public void ShowPanel(Toggle toggle)
    {
        toggle.isOn = true;
    }
}