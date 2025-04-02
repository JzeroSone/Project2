using DamageNumbersPro;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public DamageNumber numberPrefab;
    Bullet bullet;
    Player player;
    Vector3 _direction;

    private void Awake()
    {
        bullet = GetComponent<Bullet>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _direction = GameObject.FindWithTag("Player").GetComponent<FindNearestObject>().nearestObject.transform.position - transform.position;
    }

    void Update()
    {
        if (bullet.lifetime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += _direction.normalized * bullet.speed * Time.deltaTime;
        bullet.lifetime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            EnemyController enemyController = other.GetComponent<EnemyController>();
            float damageReduction = enemy.defence > 0 ? enemy.defence / (16.6f + enemy.defence) : Mathf.Pow(0.94f, Mathf.Abs(enemy.defence)) - 1;
            bool isCritical = player.IsCriticalHit();
            float attack = player.attack * (player.attackBonus + 1);
            float damage = attack * bullet.attackMultiplier * (1 - damageReduction) * (isCritical ? 1 + player.criticalDamage : 1);
            if (isCritical)
            {
                numberPrefab.SetColor(Color.red);
                numberPrefab.GetTextMesh().fontStyle = TMPro.FontStyles.Bold;
            }
            else
            {
                numberPrefab.SetColor(Color.white);
                numberPrefab.GetTextMesh().fontStyle = TMPro.FontStyles.Normal;
            }
            numberPrefab.Spawn(transform.position, damage);
            enemyController.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
