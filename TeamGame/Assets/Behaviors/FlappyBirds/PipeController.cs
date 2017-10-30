using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PipeController : MonoBehaviour
{
    [SerializeField] private FlappyBirdsPlayer _player1;
    [SerializeField] private FlappyBirdsPlayer _player2;

    [SerializeField] private GameObject[] _pipePrefabs;

    [SerializeField] private float _variation = 1;
    [SerializeField] private float _variationGrowth = .2f;

    [SerializeField] private float _timeBetweenPipes = .2f;
    [SerializeField] private float _pipeSpeedIncrease = -.25f;

    [SerializeField] public float pointsPerSecond = 10;

    private float timeUntilNextPipe = 0;
    private int pipeIdx = 0;
    private Random rnd = new Random();

    void Start()
    {
        _player1.score = GameController.p1score;
        _player2.score = GameController.p2score;
    }

    void Update()
    {
        timeUntilNextPipe -= Time.deltaTime;
        if (timeUntilNextPipe <= 0)
        {
            timeUntilNextPipe = _timeBetweenPipes;
            var prefabIdx = rnd.Next(_pipePrefabs.Length);
            var prefab = _pipePrefabs[prefabIdx];
            var pipe = Instantiate(prefab);
            pipe.transform.position = this.transform.position;
            pipe.transform.position = new Vector3(this.transform.position[0] + (float)(rnd.NextDouble() - .5) * _variation, this.transform.position[1], this.transform.position[2]);
            pipe.GetComponent<Pipe>().speed += _pipeSpeedIncrease * pipeIdx++;
            _variation += _variationGrowth;
        }

        if (_player1.isDead && _player2.isDead)
        {
            GameController.EndMinigame(Mathf.FloorToInt(_player1.score), Mathf.FloorToInt(_player2.score));
        }
    }
}
