using DamageNumbersPro;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet bullet;
    public DamageNumber numberPrefab;
    public Player player;
    private Vector3 _direction;

    void Start()
    {
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
            float damageReduction = enemy.defence > 0 ? enemy.defence / (16.6f + enemy.defence) : Mathf.Pow(0.94f, Mathf.Abs(enemy.defence)) - 1;
            bool isCritical = Random.value < player.criticalHitRate;
            float damage = bullet.attackPower * (1 - damageReduction) * (isCritical ? 1 + player.criticalDamage : 1);
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
            enemy.healthPoint -= damage;
            Destroy(gameObject);
        }
    }
}
