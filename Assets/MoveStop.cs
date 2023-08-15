using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStop : MonoBehaviour
{
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;

    private void Update()
    {
        if(transform.position.x > _maxPositionX || transform.position.x <= _minPositionX)
        {
            transform.parent = null;
        }
    }
}
