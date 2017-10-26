using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Transform/Shake")]
public class ShakeObject : MonoBehaviour
{
    private Transform _transform;

    public float ShakeAmount = 0.5f;
    public float ShakeDuration = 1.0f;

    [SerializeField] private bool _activateOnAwake = false;

	// Use this for initialization
	void Start ()
	{
	    _transform = GetComponent<Transform>();
	}

    private void Awake()
    {
        if (_activateOnAwake)
        {
            if (!_transform)
                Start();
            Shake();
        }
    }

    public void Shake()
    {
        
        StartCoroutine(ScreenShake(ShakeAmount, ShakeDuration));
    }

    public void Shake(float shakeAmount, float shakeDuration)
    {
        ShakeAmount = shakeAmount;
        ShakeDuration = shakeDuration;
        Shake();
    }

    private IEnumerator ScreenShake(float shakeAmount, float duration)
    {
        float currentTime = 0;
        Vector3 originPos = _transform.position;
        while (currentTime < duration)
        {
            _transform.position = originPos + (Vector3) Random.insideUnitCircle * shakeAmount;

            currentTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = originPos;
    }
}
