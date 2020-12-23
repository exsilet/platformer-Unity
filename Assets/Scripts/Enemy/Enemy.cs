using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
           
        }

        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
