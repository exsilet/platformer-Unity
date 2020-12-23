using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.recoveryHealth(_health);
        }

        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
