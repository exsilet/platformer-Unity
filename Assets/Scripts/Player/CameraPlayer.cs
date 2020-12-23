using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _x0ffset;
    [SerializeField] private float _y0ffset;

    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _x0ffset, _player.transform.position.y - _y0ffset, -10);
    }
}
