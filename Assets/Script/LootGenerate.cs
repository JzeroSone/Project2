using UnityEngine;

public class LootGenerate : MonoBehaviour
{
    public GameObject gold;
    public GameObject experiences;

    public void Generate()
    {
        if(Random.value < 0.5f)
        {
            Instantiate(gold, transform.position, Quaternion.Euler(Vector3.zero));
        }
        else
        {
            Instantiate(experiences, transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
