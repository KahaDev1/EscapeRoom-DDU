using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;

public class Dialouge : MonoBehaviour
{

    public bool dialougeActive;

    public TextMeshProUGUI textComponent;
    //public GameObject dialougeUI;
    public string[] currentLines;
    public float textSpeed = 0.03f;

    int index;

    public float dialougeOffTime;
    public float waitBeforeStartDialouge = 0.3f;

    void Start()
    {
        textComponent.text = string.Empty;
        dialougeActive = false;
    }


    void Update()
    {
        if (!dialougeActive)
        {
            dialougeOffTime += Time.deltaTime;
            return;
        }
        else
        {
            dialougeOffTime = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == currentLines[index])
            {
                NextLine();
            }
            else
            {
                // StopAllCoroutines();
                // textComponent.text = currentLines[index];
            }
        }
    }

    public void StartDialouge(string[] lines)
    {
        if (dialougeOffTime < waitBeforeStartDialouge)
        {
            return;
        }
        //dialougeUI.SetActive(true);
        textComponent.text = string.Empty;
        currentLines = lines;
        dialougeActive = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialougeActive = false;
            textComponent.text = string.Empty;
        }
    }
}
