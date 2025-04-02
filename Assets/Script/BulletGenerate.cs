using System.Collections;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    public GameObject bulletPerfab;
    public Player player;
    Coroutine coroutine;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (GetComponent<FindNearestObject>().nearestObject != null && coroutine == null)
        {
            coroutine = StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        Instantiate(bulletPerfab, transform.position, Quaternion.Euler(0, 0, 0));
        float attackSpeed = 1 + player.attackSpeedBonus;
        if(attackSpeed < 0.1f)
        {
            attackSpeed = 0.1f;
        }
        float seconds = player.attackInterval / attackSpeed;
        yield return new WaitForSeconds(seconds);
        coroutine = null;
    }
}
