using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Controller/Laser")]
public class LaserGameManager : MonoBehaviour
{

    [SerializeField] private LaserPlayer _player1;
    [SerializeField] private LaserPlayer _player2;
    [SerializeField] private float _timeToFinishGame = 2.0f;

    private Coroutine _routine = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (_routine == null && (_player1.Health <= 0 || _player2.Health <= 0))
	    {
            _routine = StartCoroutine(Timer(_timeToFinishGame));
	    }
        
	}

    private IEnumerator Timer(float time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        FinishGame();
    }

    public void FinishGame()
    {
        GameController.EndMinigame(_player1.Score, _player2.Score);
    }
}
