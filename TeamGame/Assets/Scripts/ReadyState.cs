using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReadyState : MonoBehaviour
{

    [SerializeField] private string _ready;
    [SerializeField] private string _notReady;

    [SerializeField] private Color _readyColor = new Color(0f, 0.8f, 0f);
    [SerializeField] private Color _notReadyColor = new Color(0.8f, 0.0f, 0f);

    [SerializeField] private string _readyButton;

    private Text _text;

	// Use this for initialization
	void Start()
	{
	    _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update()
	{
	    bool ready = Input.GetButton(_readyButton);

        _text.text = ready ? _ready : _notReady;
	    _text.color = ready ? _readyColor : _notReadyColor;

	}
}
