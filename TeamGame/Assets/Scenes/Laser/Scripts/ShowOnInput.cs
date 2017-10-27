using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnInput : MonoBehaviour
{

    [SerializeField] private string _inputKey;
    [SerializeField] private bool _invert = false;
    [SerializeField] private GameObject _toShow;
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (_toShow)
	    {
	        _toShow.SetActive(Input.GetButton(_inputKey) != _invert);
	    }
	}
}
