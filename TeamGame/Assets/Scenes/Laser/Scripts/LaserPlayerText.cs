using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LaserPlayerText : MonoBehaviour
{

    [SerializeField] private LaserPlayer _player;

    private Text _text;

	// Use this for initialization
	void Start ()
	{
	    _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _text.text = _player.Score.ToString();
	}
}
