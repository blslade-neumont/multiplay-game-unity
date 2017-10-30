using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game End/Ui")]
public class GameEndUi : MonoBehaviour
{

    [SerializeField] private GameEndText _p1Text;
    [SerializeField] private GameEndText _p2Text;

	// Use this for initialization
	void Start () {
		_p1Text.SetScore(GameController.p1score);
		_p2Text.SetScore(GameController.p2score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
