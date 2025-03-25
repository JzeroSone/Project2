using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Renderer boundaryRenderer;

    void Update()
    {
        Vector3 boundaryTopRight = boundaryRenderer.bounds.max;
        Vector3 boundaryBottomLeft = boundaryRenderer.bounds.min;
        Vector3 boundaryMax = boundaryTopRight - boundaryRenderer.transform.position;
        Vector3 boundaryMin = boundaryBottomLeft - boundaryRenderer.transform.position;

        Vector3 cameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 cameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 cameraMax = cameraTopRight - transform.position;
        Vector3 cameraMin = cameraBottomLeft - transform.position;

        Vector3 max = boundaryMax - cameraMax;
        Vector3 min = boundaryMin - cameraMin;


        Vector3 _position = target.position;
        _position.x = Mathf.Clamp(_position.x, min.x, max.x);
        _position.y = Mathf.Clamp(_position.y, min.y, max.y);
        _position.z = -10;
        this.transform.position = _position;
    }

}
