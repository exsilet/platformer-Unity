using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _point;
    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    public void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _point = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _point[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _point[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            _spriteRenderer.flipX = true;

            if (_currentPoint >= _point.Length)
            {
                _currentPoint = 0;
                _spriteRenderer.flipX = false;
            }
        }
    }
}
