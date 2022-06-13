using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _signalSound;

    private float _minVolumeValue = 0;
    private float _maxVolumeValue = 1;
    private float _stepValue = 0.05f;
    private float _step = 0;

    public void EnterToHouse() 
    {
        _step = 0;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_signalSound);
        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_minVolumeValue, _maxVolumeValue));
    }

    public void LeaveHouse() 
    {
        _step = 0;
        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_maxVolumeValue, _minVolumeValue));
    }

    private IEnumerator ChangeVolume(float currentValue, float targetValue)
    {
        while (_audioSource.volume != targetValue)
        {
            _step += _stepValue;
            _audioSource.volume = Mathf.MoveTowards(currentValue, targetValue, _step);
            yield return new WaitForSeconds(_stepValue);
        }
    }
}
