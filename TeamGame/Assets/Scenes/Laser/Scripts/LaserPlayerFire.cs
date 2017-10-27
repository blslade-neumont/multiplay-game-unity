using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Laser Player Fire")]
[RequireComponent(typeof(Animator))]
public class LaserPlayerFire : MonoBehaviour
{

    [SerializeField] private string _fireTrigger;
    [SerializeField] private string _fireButton;
    [SerializeField] private ShakeObject _cameraShakey;

    private Animator _animator;

	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    bool isFiring = Input.GetButton(_fireButton);
        _animator.SetBool(_fireTrigger, isFiring);
        if (isFiring)
            _cameraShakey.Shake();


    }
}
