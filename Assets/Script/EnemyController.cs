using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 2.0f;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 _direction = playerTransform.position - transform.position;
        transform.Translate(_direction.normalized * speed * Time.fixedDeltaTime);
    }
    
}
