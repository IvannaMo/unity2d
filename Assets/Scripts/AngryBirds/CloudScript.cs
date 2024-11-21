using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * 
            // 0.01f);
            Time.deltaTime);
        if (this.transform.position.x < -10f)
        {
            this.transform.position = new Vector3(10f, this.transform.position.y);
        }
    }
}
