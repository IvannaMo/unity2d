using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;

    [SerializeField]
    private int triesCount;

    private Rigidbody2D rb2d;
    private ForceScript forceScript;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float shotTimeout = 10.0f;
    private float shotTime;
    private bool isShooting;

    void Start()
    {
        GameState.triesCount = triesCount;
        shotTime = 0.0f;
        isShooting = false;
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript =
            GameObject
            .Find("ForceCanvasIndicator")
            .GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            float forceFactor = 1000.0f;
            if (forceScript != null)
            {
                forceFactor *= Time.timeScale * (forceScript.forceFactor + 0.5f);
            }
            else
            {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);

            isShooting = true;
            shotTime = shotTimeout;
        }
        if (isShooting)
        {
            shotTime -= Time.deltaTime;
            if (shotTime <= 0.0f)
            {
                GameState.triesCount -= 1;
                if (GameState.triesCount <= 0)
                {
                    GameState.triesCount = 0;
                    GameState.isLevelFailed = true;
                    ModalScript.ShowModal("ÏÐÎÃÐÀØ", "Âè÷åðïàíî ê³ëüê³ñòü ñïðîá");
                }
                else
                {
                    isShooting = false;

                    this.transform.position = startPosition;
                    this.transform.rotation = startRotation;

                    rb2d.linearVelocity = Vector2.zero;
                    rb2d.angularVelocity = 0.0f;
                }
            }
        }
    }
}
