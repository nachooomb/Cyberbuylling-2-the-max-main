using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    GameObject dialogueBox;
    

    GameObject Arturo;
    control_arturo _controlArturo;

    // Start is called before the first frame update
    void Start()
    {
        
        dialogueBox = GameObject.Find("DialogueBox");
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();

        Arturo = GameObject.Find ("Arturo");
        _controlArturo = Arturo.GetComponent<control_arturo>();

        //_controlArturo.clickAndMove.enabled = false;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        _controlArturo.clickAndMove.enabled = false;
        _controlArturo.combate.enabled = false;
        _controlArturo.clickAndShoot.enabled = false;
        _controlArturo.item_Throw.enabled = false;

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    

   
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
       _controlArturo.clickAndMove.enabled = true;

    }
    
}
