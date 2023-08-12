using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class KinematicManager : MonoBehaviour
{
    [SerializeField] private GameObject objectsGame;
    [SerializeField] private GameObject kinematicObjects;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject fanatic;
    [SerializeField, TextArea(2,4)] private string[] dialogueLines;
    [SerializeField, TextArea(2, 4)] private string[] dialogueFinal;

    private GameObject crazyBoy;

    private bool isKinematic = true;
    private int lineIndex;
    private bool didDialogueStart = false;
    private Coroutine showLine;


    public static KinematicManager Instance;
    private void Awake()
    {
        if (KinematicManager.Instance == null)
        {
            KinematicManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lineIndex = 0;
        StartDialogue();
    }

    private void Update()
    {
        if (isKinematic)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopCoroutine(showLine);
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
        }
    }

    private void StartDialogue()
    {
        objectsGame = GameObject.Find("ObjetosJuego");
        didDialogueStart = true;
        objectsGame.SetActive(false);
        kinematicObjects.SetActive(true);
        fanatic.SetActive(true);

        if (lineIndex == 6)
        {
            StartCoroutine(BlackScreen(false));
            return;
        }
        showLine = StartCoroutine(ShowLine());
    }

    public void StartFinalDialogue()
    {
        isKinematic = true;
        textObject.transform.position += new Vector3(1f, 0f, 0f);
        string[] temporalDialogue = new string[dialogueLines.Length + dialogueFinal.Length];
        Array.Copy(dialogueLines, temporalDialogue, dialogueLines.Length);
        Array.Copy(dialogueFinal, 0, temporalDialogue, dialogueLines.Length, dialogueFinal.Length);
        dialogueLines = temporalDialogue;

        crazyBoy = GameObject.Find("Crazyboy");
        crazyBoy.transform.position = new Vector3(-1.5f, -4.5f, 0);
        StartDialogue();
    }

    private void EndDialogue()
    {
        isKinematic = false;
        objectsGame.SetActive(true);
        kinematicObjects.SetActive(false);
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex == 3)
        {
            StartCoroutine(BlackScreen(false));
            textObject.transform.position += new Vector3(-1f, 0f, 0f);
            return;
        }
        if(lineIndex < dialogueLines.Length)
        {
            showLine = StartCoroutine(ShowLine());
        }
        else
        {
            StartCoroutine(BlackScreen(true));
        }
    }

    private IEnumerator BlackScreen(bool end)
    {
        blackScreen.SetActive(true);
        fanatic.SetActive(false);
        yield return new WaitForSeconds(1f);
        blackScreen.SetActive(false);
        if (lineIndex == 6)
        {
            fanatic.SetActive(true);
        }

        if (lineIndex < dialogueLines.Length)
        {
            showLine = StartCoroutine(ShowLine());
        }
        else if (lineIndex == 9)
        {
            blackScreen.SetActive(true);
            end = false;
        }

        if (end) { EndDialogue(); }
    }

}
