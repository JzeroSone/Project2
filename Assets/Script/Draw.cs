using UnityEngine;

public class Draw : MonoBehaviour
{
    public Material material;
    LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        line.material = material;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.loop = true;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.positionCount = 360;
    }

    public void DrawCircle(Vector3 center, float radius)
    {
        float angle = 360f / line.positionCount;
        Vector3[] circlePoints = new Vector3[line.positionCount];
        Vector3 vecStart = new Vector3(0, radius, 0);

        for(int i = 0; i < line.positionCount; i++)
        {
            circlePoints[i] = Quaternion.Euler(0, 0, angle * i) * vecStart + center;
        }

        line.SetPositions(circlePoints);
    }
}
