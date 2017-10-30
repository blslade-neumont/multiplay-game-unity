using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlappyBirdsPlayer : MonoBehaviour
{
    [SerializeField] string _jumpButton = "Fire1";
    [SerializeField] [Range(0, 1)] int _playerNumber = 0;

    [SerializeField] Vector2 gravityDirection;
    
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float fallForce = 1;

    [SerializeField] public float score;

    private new Rigidbody2D rigidbody2D;

    public bool isDead;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton(_jumpButton) && !isDead)
        {
            rigidbody2D.velocity = -gravityDirection * jumpSpeed;
        }
        var pos = new Vector2(transform.position.x, transform.position.y);
        var hit = Physics2D.Raycast(pos + (.1f * gravityDirection), gravityDirection, .1f);
        if (hit && hit.distance < .1 && hit.distance >= 0 && !isDead)
        {
            rigidbody2D.velocity *= .9f;
        }

        rigidbody2D.AddForce(gravityDirection * fallForce);

        var bottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        isDead = transform.position.y < bottom.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FlappyPipe"))
        {
            isDead = true;
        }
    }
}
