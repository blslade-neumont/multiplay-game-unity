using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Lift Player")]
[RequireComponent(typeof(Rigidbody2D))]
public class LiftPlayer : MonoBehaviour
{

    [Tooltip("Force to lift the player")]
    [SerializeField] private float _force = 5;

    [Tooltip("The name of the button to lift the player")]
    [SerializeField] private string _button;

    private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton(_button))
	    {
	        _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Force);
	    }
	}
}
