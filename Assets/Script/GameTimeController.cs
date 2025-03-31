using TMPro;
using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    ShowText text;
    int gameTime;
    private void Awake()
    {
        text = GetComponent<ShowText>();
    }

    private void Start()
    {
        gameTime = 0;
    }

    private void Update()
    {
        if(gameTime != (int)Time.time)
        {
            gameTime = (int)Time.time;
            int hour = gameTime / 60;
            int minute = gameTime % 60;
            text.UpdateText(string.Format("{0:D2}:{1:D2}", hour, minute));
        }
        
    }
}
