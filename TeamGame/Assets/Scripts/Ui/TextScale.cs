using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Text Scale")]
[RequireComponent(typeof(Text))]
public class TextScale : MonoBehaviour
{

    private Text _text;

    [SerializeField] private int _startSize;

    [SerializeField] public float Scale;
    [SerializeField] public float CurrentValue;
    [SerializeField] public float MaxValue;

	// Use this for initialization
	void Start ()
	{
	    _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _text.fontSize = (int) (Mathf.Min(CurrentValue, MaxValue) * Scale + _startSize);
	    // _text.fontSize = (int) (Mathf.Clamp01(CurrentValue / MaxValue) * Scale + _startSize);
	}
}
