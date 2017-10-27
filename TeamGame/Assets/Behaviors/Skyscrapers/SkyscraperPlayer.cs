using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SkyscraperPlayer : MonoBehaviour
{
    [SerializeField] string _jumpButton = "Fire1";
    [SerializeField] [Range(0, 1)] int _playerNumber = 0;

    [SerializeField] float lastHitDistance;

    private new Rigidbody2D rigidbody2D;

    public bool isDead;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton(_jumpButton))
        {
            var pos = transform.position;
            var hit = Physics2D.Raycast(new Vector2(pos.x, pos.y - .1f), Vector3.down, .1f);
            if (hit && hit.distance < .1 && hit.distance >= 0)
            {
                lastHitDistance = hit.distance;
                rigidbody2D.velocity = new Vector2(0, 10);
            }
        }

        var bottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        isDead = transform.position.y < bottom.y;
    }
}
