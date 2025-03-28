using UnityEngine;

public class Loot : MonoBehaviour
{
    public enum Type
    {
        gold,
        exp
    };
    public Type type;
    public int value;
}
