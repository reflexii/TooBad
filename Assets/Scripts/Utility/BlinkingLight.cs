using UnityEngine;
using System.Collections;

public class BlinkingLight: MonoBehaviour {

    public float flickerSpeed = 0.07f;
    private int randomizer = 0;
    private Light _light;
    private bool _isOff = false;
    private float _timer;

    void Start ()
    {
        _light = GetComponent<Light>();
    }
	
	void Update ()
    {
        Blink();
	}

    void Blink()
    {
        if (!_isOff)
        {
            if (randomizer != 0)
                _light.intensity = 5;
            else
            {
                _light.intensity = 0;
                _isOff = true;
            }
            randomizer = Random.Range(0, 20);
        }
        else
        {
            if (_timer >= flickerSpeed)
            {
                _isOff = !_isOff;
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }
    }
}
