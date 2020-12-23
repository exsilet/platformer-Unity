using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] public float _speed;
    [SerializeField] public float _jump;
    [SerializeField] public float _stepSize;

    private MoveState _moveState = MoveState.Move;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
    }

    public void recoveryHealth(int _heal)
    {
        if (_health < 3)
        {
            _health += _heal;

        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
        _rigidbody.velocity = Vector2.up * _jump * Time.deltaTime;
        _moveState = MoveState.Jump;
        _animator.Play("jumpLis");
    }

    public void MoveRight()
    {
        _sprite.flipX = false;
        SetNextPosition(_stepSize);
    }

    public void MoveLeft()
    {
        _sprite.flipX = true;
        SetNextPosition(-_stepSize);
    }

    private void SetNextPosition (float stepSize)
    {
        _moveState = MoveState.Move;
        transform.Translate(_speed * Time.deltaTime * stepSize, 0, 0);
        _animator.Play("walking");
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("я умер");
        Time.timeScale = 0;
    }

    enum MoveState
    {
        Move,
        Jump
    }
}
