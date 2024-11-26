using UnityEngine;

public class ClockScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI clock;
    private float gameTime;

    void Start()
    {
        clock = GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0.0f;
    }

    void Update()
    {
        gameTime += Time.deltaTime; 

        int hours = Mathf.FloorToInt(gameTime / 3600);
        int minutes = Mathf.FloorToInt((gameTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        float milliseconds = (gameTime * 1000f) % 1000f;

        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D1}", hours, minutes, seconds, Mathf.FloorToInt(milliseconds / 100));

        if (gameTime >= 15.0f)
        {
            GameState.isLevelFailed = true;
            ModalScript.ShowModal("ПРОГРАШ", "Час вичерпано, спробуйте ще раз");
        }
    }
}
