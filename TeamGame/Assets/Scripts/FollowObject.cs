using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Transform/Follow Object")]
public class FollowObject : MonoBehaviour
{

    [Tooltip("The transform of the object to follow")]
    [SerializeField] private Transform _objectToFollow;

    [Tooltip("The offset position from the followed object")]
    [SerializeField] private Vector3 _offset;

    [Header("Lock Settings")]
    [SerializeField] private bool _lockX = false;
    [SerializeField] private bool _lockY = false;
    [SerializeField] private bool _lockZ = true;

    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _transform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 currentPos = _transform.position;
	    Vector3 followPos = _objectToFollow.position;

	    currentPos.x = _lockX ? currentPos.x : followPos.x + _offset.x;
	    currentPos.y = _lockY ? currentPos.y : followPos.y + _offset.y;
	    currentPos.z = _lockZ ? currentPos.z : followPos.z + _offset.z;

	    _transform.position = currentPos;
	}
}
