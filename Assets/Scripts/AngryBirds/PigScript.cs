using System;
using UnityEngine;

public class PigScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PigDestroy"))
        {
            //ModalScript.ShowModal("ЗНИЩЕНО", "-1 супротивник");
            GameObject.Destroy(this.gameObject);
            GameState.needRecalculatePigs = true;
        }
    }
}
