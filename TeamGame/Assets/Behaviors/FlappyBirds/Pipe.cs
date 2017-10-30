using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pipe : MonoBehaviour
{
    [SerializeField] public float speed = -4;
    [SerializeField] private float _timeUntilDelete = 16;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector2(0, speed);
        _timeUntilDelete -= Time.deltaTime;
        if (_timeUntilDelete <= 0) Destroy(gameObject);
    }
}
