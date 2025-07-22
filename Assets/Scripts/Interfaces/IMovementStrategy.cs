using UnityEngine;

public interface IMovementStrategy
{
    void Move(Rigidbody2D rb, Vector2 input, float speed);
}
