using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Skyscraper : MonoBehaviour
{
    [SerializeField] private float _speed = -1;
    [SerializeField] private float _timeUntilDelete = 10;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector2(_speed, 0);
        _timeUntilDelete -= Time.deltaTime;
        if (_timeUntilDelete <= 0) Destroy(gameObject);
    }
}
