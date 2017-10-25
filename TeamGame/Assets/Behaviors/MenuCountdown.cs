using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MenuCountdown : MonoBehaviour
{
    [SerializeField] private string[] _readyKeys;
    [SerializeField] private int _countdown = 3;

    private Text _countdownText;
    private float _currentCountdown = 3;

    void Start()
    {
        _countdownText = GetComponent<Text>();
        if (_readyKeys == null || _readyKeys.Length == 0)
        {
            _readyKeys = new[] { "Fire1", "Fire2" };
        }
    }
    
    void Update()
    {
        var allReadyKeysDown = true;
        foreach (var key in _readyKeys)
        {
            if (!Input.GetButton(key))
            {
                allReadyKeysDown = false;
                _currentCountdown = _countdown;
                break;
            }
        }

        _countdownText.text = "" + Mathf.Ceil(_currentCountdown);
        _countdownText.enabled = allReadyKeysDown;

        _currentCountdown -= Time.deltaTime;
        if (_currentCountdown <= 0)
        {
            startGame();
        }
    }

    private void startGame()
    {
        var controller = new GameController();
        controller.StartGame();
    }
}
