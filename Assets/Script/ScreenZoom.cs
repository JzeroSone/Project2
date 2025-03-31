using UnityEngine;

public class ScreenZoom : MonoBehaviour
{
    private void Update()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scrollWheelInput, 5, 8);
    }
}
