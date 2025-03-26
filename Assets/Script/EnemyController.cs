using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;
    public Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(enemy.healthPoint <= 0)
        {
            GameObject.FindObjectOfType<EnemyGenerate>().RemoveEnemy(transform);
            GetComponent<LootGenerate>().Generate();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 _direction = playerTransform.position - transform.position;
        transform.Translate(_direction.normalized * enemy.movementSpeed * Time.fixedDeltaTime);
    }
    
}
