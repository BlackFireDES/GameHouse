using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private const float _minSpeed = 0;
    private float _maxSpeed;
    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _maxSpeed = _speed;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Point>())
        {
            if (_currentPoint == 0)
                transform.rotation = new Quaternion(0, 0, 0, 0);
            else transform.rotation = new Quaternion(0, 180, 0, 0);

            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            if (collision.GetComponent<DoorActivation>())
                StartCoroutine(Sleep().GetEnumerator());
        }
    }

    private void Stay()
    {
        _speed = _minSpeed;
    }

    private void Go()
    {
        _speed = _maxSpeed;
    }

    private IEnumerable Sleep()
    {
        Stay();
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(3);
        Go();
        _spriteRenderer.enabled = true;
    }
}
