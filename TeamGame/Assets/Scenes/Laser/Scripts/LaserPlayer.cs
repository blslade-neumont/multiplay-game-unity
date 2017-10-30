using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Laser Player")]
[RequireComponent(typeof(Animator))]                                                              
public class LaserPlayer : MonoBehaviour                                                          
{                                                                                       
    [Header("Player")]                                                            
    [SerializeField] public float Health = 50;                                        
    [SerializeField] public float MaxHealth = 50;                                     
    [SerializeField] private float _damage = 1;                                         
    [SerializeField] private bool _setHealthToMaxOnStart = true;
    [SerializeField] private float _scoreMultiplier = 200;

    [SerializeField] private Bounds _playerBounds;
    [SerializeField] private GameObject _disableOnDeath;
                                                                                        
    [Header("Controls")]                                                                
    [SerializeField] private string _fireTrigger;                                       
    [SerializeField] private string _fireButton;

    [SerializeField] private ShakeObject _cameraShakey;
    [SerializeField] private ImageFill _healthImg;                                      
                                                                                        
    [Header("Enemy")]                                                                   
    [SerializeField] private LaserPlayer _enemyPlayer;                                  
    private Transform _enemyTransform;                                                  
    [SerializeField] private float _laserHeight;

    [Header("OnDeath")]
    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] private Color _selfColor;

    private Animator _animator;
    private Transform _transform;

    public bool IsFiring { get; private set; }

    public int Score
    {
        get { return Mathf.RoundToInt((Health / MaxHealth) * _scoreMultiplier); }
    }

    // Use this for initialization
    void Start ()
	{
	    _transform = transform;
	    _animator = GetComponent<Animator>();

        if (_setHealthToMaxOnStart)
	    {
	        Health = MaxHealth;
	    }

	    _enemyTransform = _enemyPlayer.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    IsFiring = Input.GetButton(_fireButton);
        _animator.SetBool(_fireTrigger, IsFiring);
        if (IsFiring)
            _cameraShakey.Shake();

	    if (_enemyPlayer.IsFiring)
	    {
	        float enemyMin, enemyMax, playerMin, playerMax;
            _enemyPlayer.GetLaserRange(out enemyMin, out enemyMax);
            GetPlayerHitboxRange(out playerMin, out playerMax);

	        if ((playerMin >= enemyMin && playerMin <= enemyMax) || (playerMax >= enemyMin && playerMax <= enemyMax))
	        {
                // take damage oh no
                Health -= _enemyPlayer._damage;

	            if (Health <= 0)
	            {
	                // explosion!
	                ParticleSystem s = Instantiate(_deathParticle, _transform.position, Quaternion.identity);
	                var main = s.main;
	                main.startColor = _selfColor;

                    _disableOnDeath.SetActive(false);
	                
                    Destroy(gameObject);
                    // gameObject.SetActive(false);
                    
	            }
	        }
	    }
	    _healthImg.FillAmount = Health / MaxHealth;
    }

    public void GetLaserRange(out float min, out float max)
    {
        float h = _transform.position.y;
        min = h - _laserHeight;
        max = h + _laserHeight;
    }

    void GetPlayerHitboxRange(out float min, out float max)
    {
        float playerH = _transform.position.y;

        min = playerH - _playerBounds.min.y;
        max = playerH + _playerBounds.max.y;
    }

    private void OnValidate()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
    }

    private void OnDrawGizmosSelected()
    {
        Transform trans = transform;
        Vector3 pos = trans.position;
        Vector3 size = new Vector3(200, _laserHeight, 10);
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(pos, size);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_playerBounds.center + pos, _playerBounds.size);
    }
}
