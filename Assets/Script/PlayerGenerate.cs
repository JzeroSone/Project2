using UnityEngine;

public class PlayerGenerate : MonoBehaviour
{
    public GameObject player;
    void Awake()
    {
        Instantiate(player, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
}
