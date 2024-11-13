using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int value = 300;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2d.AddForce(Vector2.up * value);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * value);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * value);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2d.AddTorque(value);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.angularVelocity = 0f;
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}


