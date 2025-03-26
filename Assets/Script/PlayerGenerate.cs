using UnityEngine;

public class PlayerGenerate : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Instantiate(player, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
}
