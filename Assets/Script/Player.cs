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

    //��ǰ�����Ĵ���
    float attackCount = 1;

    //�����Ƿ񱩻������û�����򹥻�������1����������ˣ��򹥻���������Ϊ1��
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
