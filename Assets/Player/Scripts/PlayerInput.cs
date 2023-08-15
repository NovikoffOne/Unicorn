using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;

    private Vector2 _mousePosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _player.CanMove)
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            _player.Shoot(_mousePosition);
        }
    }
}
