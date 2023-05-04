using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriter : MonoBehaviour
{
    public float delay;

    public string yazi;
    TextMeshProUGUI thisText;

    private void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();

        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite()
    {
        foreach(char i in yazi)
        {
            thisText.text += i.ToString();

            if(i.ToString() == ".")
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
