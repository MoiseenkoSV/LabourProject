using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GameEventContorls : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Text _text;
    [SerializeField] string[] _endGameText;

    private void Start()
    {
        _panel.SetActive(false);
    }
    public void PlayerEndGame(bool GameState)
    {
        if (GameState && FindObjectOfType<GameManager>()._hasKey)
        {
            _panel.SetActive(GameState);
            _text.text = "Ну, чувак, это победа";
        }
        else
        {
            _panel.SetActive(!GameState);
        }
    }
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
