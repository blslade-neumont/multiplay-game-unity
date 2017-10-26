using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Image Fill")]
[RequireComponent(typeof(Image))]
public class ImageFill : MonoBehaviour
{
    [SerializeField] public Image.FillMethod FillMethod;
    [Range(0, 1)] [SerializeField] private float _fillAmount = 1.0f;
    [SerializeField] public bool FillClockwise = true;
    [SerializeField] public int FillOrigin;
    [SerializeField] public bool FillCenter = true;

    public float FillAmount
    {
        get { return _fillAmount; }
        set
        {
            _fillAmount = Mathf.Clamp01(value);
        }
    }

    private Image _image;

    // Use this for initialization
	void Start ()
	{
	    _image = GetComponent<Image>();
	}

    private void OnValidate()
    {
        if (!_image)
            _image = GetComponent<Image>();
        Update();
    }

    // Update is called once per frame
	void Update ()
	{
	    _image.fillMethod = FillMethod;
	    _image.fillAmount = _fillAmount;
	    _image.fillClockwise = FillClockwise;
	    _image.fillOrigin = FillOrigin;
	    _image.fillCenter = FillCenter;
	}
}
