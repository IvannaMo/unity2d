using UnityEngine;

public class YellowBirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;

    private Rigidbody2D rb2d;
    private ForceScript forceScript;
    private bool isDashAllowed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float forceFactor = 1000.0f;

            if (!isDashAllowed)
            {
                forceFactor = 1000.0f;
            }
            else
            {
                forceFactor *= 3.0f;
                isDashAllowed = false;
            }

            if (forceScript != null)
            {
                forceFactor *= Time.timeScale * (forceScript.forceFactor + 0.5f);
            }
            else
            {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
        }
    }
}