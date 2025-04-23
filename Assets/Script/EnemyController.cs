using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy enemy;
    FloatingBar healthBar;
    ShowText enemyNumber;
    Player player;
    Vector3 _direction;
    Animator animator;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<FloatingBar>();
        enemyNumber = GameObject.Find("EnemyNumber").GetComponentInChildren<ShowText>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        _direction = player.transform.position - transform.position;
        if (Vector3.Angle(Vector3.up, _direction) <= 45f)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (Vector3.Angle(Vector3.down, _direction) <= 45f)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (Vector3.Angle(Vector3.left, _direction) <= 45f)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (Vector3.Angle(Vector3.right, _direction) <= 45f)
        {
            animator.SetInteger("Direction", 3);
        }
    }

    void FixedUpdate()
    {
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
