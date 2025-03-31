using DamageNumbersPro;
using UnityEngine;

public class AutoPick : MonoBehaviour
{
    public float speed = 20.0f;
    public DamageNumber number;
    Transform target;
    bool flag = false;
    PlayerController playerController;
    Loot loot;

    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        target = GameObject.FindWithTag("Player").transform;
        loot = GetComponent<Loot>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (flag == true)
        {
            if (distance < 0.1f)
            {
                playerController.AddLoot(loot);
                number.Spawn(target.position, loot.value);
                Destroy(gameObject);
            }
            Vector3 _direction = target.position - transform.position;
            
            transform.position += _direction.normalized * speed * Time.deltaTime;
        }
        else if(distance < target.GetComponent<Player>().pickRange)
        {
            Pick();
        }
    }

    public void Pick()
    {
        flag = true;
    }
}
