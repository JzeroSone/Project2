using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy enemy;
    FloatingBar healthBar;
    ShowText enemyNumber;
    Player player;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<FloatingBar>();
        enemyNumber = GameObject.Find("EnemyNumber").GetComponentInChildren<ShowText>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
        Vector3 _direction = player.transform.position - transform.position;
        transform.Translate(_direction.normalized * enemy.movementSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damageAmout)
    {
        enemy.healthPoint -= damageAmout;
        healthBar.UpdateBar(enemy.healthPoint, enemy.maxHealthPoint);
        if (enemy.healthPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<LootGenerate>().Generate();
        GameObject.FindObjectOfType<EnemyGenerate>().RemoveEnemy(transform);
        player.kills++;
        enemyNumber.UpdateText(player.kills.ToString());
        Destroy(gameObject);
    }
    
}
