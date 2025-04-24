using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy enemy;
    FloatingBar healthBar;
    ShowText enemyNumber;
    Player player;
    Vector3 _direction;
    Animator animator;
    SpriteRenderer spriteRenderer;
    float flashDuration = 0.05f;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<FloatingBar>();
        enemyNumber = GameObject.Find("EnemyNumber").GetComponentInChildren<ShowText>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        _direction = player.transform.position - transform.position;
        if (Vector3.Angle(Vector3.up, _direction) <= 45f && animator.GetInteger("Direction") != 1)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (Vector3.Angle(Vector3.down, _direction) <= 45f && animator.GetInteger("Direction") != 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (Vector3.Angle(Vector3.left, _direction) <= 45f && animator.GetInteger("Direction") != 2)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (Vector3.Angle(Vector3.right, _direction) <= 45f && animator.GetInteger("Direction") != 3)
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
        Flash();
        transform.position -= _direction.normalized * 0.1f;
        enemy.healthPoint -= damageAmout;
        healthBar.UpdateBar(enemy.healthPoint, enemy.maxHealthPoint);
        if (enemy.healthPoint <= 0)
        {
            Die();
        }
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = new Color(255, 255, 255, 1);
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
