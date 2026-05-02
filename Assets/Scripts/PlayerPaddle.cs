using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour
{
    public float speed;
    private Vector2 directionInput;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * directionInput * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        directionInput = value.Get<Vector2>();
    }
}
