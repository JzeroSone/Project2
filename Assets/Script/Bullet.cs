using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    private Vector3 _direction;

    void Start()
    {
        _direction = GameObject.FindWithTag("Player").GetComponent<FindNearestObject>().nearestObject.transform.position - transform.position;
    }

    void Update()
    {
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += _direction.normalized * speed * Time.deltaTime;
        lifetime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameObject.FindObjectOfType<EnemyGenerate>().RemoveEnemy(other.transform);
            other.GetComponent<LootGenerate>().Generate();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
