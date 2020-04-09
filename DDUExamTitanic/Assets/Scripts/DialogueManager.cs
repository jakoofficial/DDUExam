using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text name;
    public Text dialogueText;
    public Animator anim;

    public bool convoOngoing = false;

    private Queue<string> sentences;
    private GameObject player;

    void Start()
    {
        sentences = new Queue<string>();
        player = GameObject.FindWithTag("Player");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        convoOngoing = true;
        anim.SetBool("IsOpen", true);
        name.text = dialogue.name;
        player.GetComponent<PlayerMovement>().moveable = false;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void Update()
    {
        if (convoOngoing && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
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
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }

    public void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
        player.GetComponent<PlayerMovement>().moveable = true;

    }

}
