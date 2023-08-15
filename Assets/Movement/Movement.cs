using UnityEngine;

public abstract class Movement : MonoBehaviour, IMovement
{
    public void Move(float positionX, float speed)
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);
    }
}
