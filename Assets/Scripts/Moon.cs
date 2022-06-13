using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private float _speedMoving = 0.2f;
    private Transform[] _points;
    private int _indexPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (transform.position != _points[_indexPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_indexPoint].position, _speedMoving * Time.deltaTime);
        }
        else
        {
            if (_indexPoint < _points.Length - 1)
            {
                _indexPoint += 1;
            }
            else 
            {
                _indexPoint = _points.Length - 1;
                gameObject.SetActive(false);
            }
        }        
    }
}
