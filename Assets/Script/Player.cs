using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public float healthPoint, maxHealthPoint = 100f;
    public float defence = 0f;
    public int experience = 0;
    public float movementSpeed = 5f;
    public float attackInterval = 0.5f;
    public float attackSpeed = 0f;
    public float attackRange = 5f;
    public int gold = 0;
    public float criticalHitRate = 0.05f;
    public float criticalDamage = 0.5f;

    float c = 0f;
    float tempRate = 0f;

    void Update()
    {
        if(tempRate != criticalHitRate)
        {
            tempRate = criticalHitRate;
            c = PRD.CFromP(tempRate);
        }
    }

    //当前攻击的次数
    float attackCount = 1;

    //返回是否暴击，如果没暴击则攻击次数加1，如果暴击了，则攻击次数重置为1。
    public bool IsCriticalHit()
    {
        if (Random.value <= c * attackCount)
        {
            attackCount = 1;
            return true;
        }
        else
        {
            attackCount++;
            return false;
        }
    }
}
