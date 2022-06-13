using UnityEngine;

[RequireComponent(typeof(Light))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Color _defaultColor;

    private float _runningTime;
    private Color _startColor;
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _startColor = _defaultColor;
    }

    public void ChangeColor() 
    {
        if (_light.color != _targetColor)
        {
            _runningTime += Time.deltaTime;
            float _normalizeRunningTime = _runningTime / _duration;

            _light.color = Color.Lerp(_startColor, _targetColor, _normalizeRunningTime);
        }
        else
        {
            _targetColor = _startColor;
            _startColor = _light.color;
            _runningTime = 0;
        }
    }
}
