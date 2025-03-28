using UnityEngine;

public class LootGenerate : MonoBehaviour
{
    public GameObject gold;
    public GameObject experiences;

    public void Generate()
    {
        Loot loot = new Loot();
        loot.type = Random.value < 0.5f ? Loot.Type.gold : Loot.Type.exp;
        GameObject gameObject = null;
        switch (loot.type)
        {
            case Loot.Type.gold:
                gameObject = gold;
                break;
            case Loot.Type.exp:
                gameObject = experiences;
                break;
        }
        if(gameObject != null)
        {
            Instantiate(gameObject, transform.position, Quaternion.Euler(Vector3.zero));
        }
        
    }
}
