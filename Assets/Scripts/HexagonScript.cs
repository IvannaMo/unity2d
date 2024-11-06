using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D rb2b;

    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int value = 300;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2b.AddForce(Vector2.up * value);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2b.AddForce(Vector2.left * value);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2b.AddForce(Vector2.right * value);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2b.AddTorque(value);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2b.angularVelocity = 0f;
            rb2b.linearVelocity = Vector2.zero;
        }
    }
}


