using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SkyscraperPlayerScore : MonoBehaviour
{
    [SerializeField] private SkyscraperController _controller;
    [SerializeField] private SkyscraperPlayer _player;
    [SerializeField] private Color _color;
    [SerializeField] private string _playerName;

    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }
    
    void Update()
    {
        _text.color = _color;
        if (!_player.isDead) _player.score += _controller.pointsPerSecond * Time.deltaTime;
        _text.text = _playerName + ": " + Mathf.Floor(_player.score);
    }
}
