using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Text Smooth Damp")]
[RequireComponent(typeof(Text))]
public class TextSmoothDamp : MonoBehaviour
{
    public float TargetValue = 100;
    public float CurrentValue = 0;

    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private float _maxSpeed = 10.0f;

    private Text _text;
    private float _velocity = 0;

	// Use this for initialization
	void Start ()
	{
	    _text = GetComponent<Text>();
	}

	
	// Update is called once per frame
	void Update ()
	{
	    CurrentValue = Mathf.SmoothDamp(CurrentValue, TargetValue, ref _velocity, _smoothTime, _maxSpeed);

        _text.text = Mathf.RoundToInt(CurrentValue).ToString();
	}
}
