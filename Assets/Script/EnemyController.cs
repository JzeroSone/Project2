using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform playerTransform;
    Enemy enemy;
    FloatingHealthBar healthBar;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 _direction = playerTransform.position - transform.position;
        transform.Translate(_direction.normalized * enemy.movementSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damageAmout)
    {
        enemy.healthPoint -= damageAmout;
        healthBar.UpdateHealthBar(enemy.healthPoint, enemy.maxHealthPoint);
        if(enemy.healthPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<LootGenerate>().Generate();
        GameObject.FindObjectOfType<EnemyGenerate>().RemoveEnemy(transform);
        Destroy(gameObject);
    }
    
}
