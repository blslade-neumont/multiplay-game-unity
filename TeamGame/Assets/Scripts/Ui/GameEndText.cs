using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextSmoothDamp))]
[RequireComponent(typeof(TextScale))]
public class GameEndText : MonoBehaviour
{
    private TextSmoothDamp _damp;
    private TextScale _scale;

	// Use this for initialization
	void Start ()
	{
        
	    _damp = GetComponent<TextSmoothDamp>();
	    _scale = GetComponent<TextScale>();
	}

    void Update()
    {
        _scale.CurrentValue = _damp.CurrentValue;
    }

    public void SetScore(float val)
    {
        if (!_damp)
            Start();

        _damp.TargetValue = val;
        
    }
}
