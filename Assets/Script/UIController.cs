using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject attributePlane;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            attributePlane.SetActive(!attributePlane.activeSelf);
        }
    }
}
