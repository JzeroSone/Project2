using System.Collections;
using TMPro;
using UnityEngine;

public class LevelUpAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void LevelUp()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        textMeshPro.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        textMeshPro.gameObject.SetActive(false);
    }
}
