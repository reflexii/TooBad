using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    private Animator animator;
    private Transform _transform;
    private float originalScale;

    void Start ()
    {
        _transform = transform;
        originalScale = _transform.localScale.x;
	}

    void OnEnable()
    {
        if(originalScale != 0)
            _transform.localScale = new Vector3(originalScale, originalScale, originalScale);
    }
	
	void Update ()
    {
        if (_transform.localScale.x == 0)
        {
            GameManager.Instance.objectPool.AddBackToPool(this);
        }
	}
}
