using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SkyscraperController : MonoBehaviour
{
    [SerializeField] private SkyscraperPlayer _player1;
    [SerializeField] private SkyscraperPlayer _player2;

    [SerializeField] private GameObject[] _skyscraperPrefabs;

    [SerializeField] private float _variation = 1;
    [SerializeField] private float _variationGrowth = .2f;

    [SerializeField] private float _timeBetweenSkyscrapers = .2f;

    [SerializeField] public float pointsPerSecond = 10;

    private float timeUntilNextSkyscraper = 0;
    private Random rnd = new Random();

    void Start()
    {
        _player1.score = GameController.p1score;
        _player2.score = GameController.p2score;
    }

    void Update()
    {
        timeUntilNextSkyscraper -= Time.deltaTime;
        if (timeUntilNextSkyscraper <= 0)
        {
            timeUntilNextSkyscraper = _timeBetweenSkyscrapers;
            var prefabIdx = rnd.Next(_skyscraperPrefabs.Length);
            var prefab = _skyscraperPrefabs[prefabIdx];
            var skyscraper = Instantiate(prefab);
            skyscraper.transform.position = this.transform.position;
            skyscraper.transform.position = new Vector3(this.transform.position[0], this.transform.position[1] + (float)(rnd.NextDouble() - .5) * _variation, this.transform.position[2]);
            _variation += _variationGrowth;
        }

        if (_player1.isDead && _player2.isDead)
        {
            GameController.EndMinigame(Mathf.FloorToInt(_player1.score), Mathf.FloorToInt(_player2.score));
        }
    }
}
