using UnityEngine;

public class ScreenZoom : MonoBehaviour
{
    public float minSize = 3;
    public float maxSize = 8;

    private void Update()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scrollWheelInput, minSize, maxSize);
    }
}
