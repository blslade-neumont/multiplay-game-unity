using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReadyState : MonoBehaviour
{

    [SerializeField] private string _ready;
    [SerializeField] private string _notReady;

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
	    _text.text = Input.GetButton(_readyButton) ? _ready : _notReady;
	}
}
