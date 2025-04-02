using TMPro;
using UnityEngine;

public class AttributeController : MonoBehaviour
{
    public ShowText healthPoint;
    public ShowText attack;
    public ShowText defence;
    public ShowText attackSpeed;
    public ShowText movementSpeed;
    public ShowText attackRange;
    public ShowText criticalHitRate;
    public ShowText criticalDamage;

    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        healthPoint.UpdateText(string.Format("{0:0}/{1:0}", player.healthPoint, player.maxHealthPoint));
        attack.UpdateText(string.Format("{0:0}", Mathf.Round(player.attack * (1 + player.attackBonus))));
        defence.UpdateText(string.Format("{0:0}", Mathf.Round(player.defence * (1 + player.defenceBonus))));
        attackSpeed.UpdateText(string.Format("{0:0}", player.attackSpeedBonus * 100));
        movementSpeed.UpdateText(string.Format("{0:0}", player.movementSpeedBonus * 100));
        attackRange.UpdateText(string.Format("{0:0}", player.attackRange));
        criticalHitRate.UpdateText(string.Format("{0:F1}", player.criticalHitRate * 100));
        criticalDamage.UpdateText(string.Format("{0:F1}", player.criticalDamage * 100));
    }
}
