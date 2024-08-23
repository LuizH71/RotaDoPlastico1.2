using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInteraction : MonoBehaviour
{
    [SerializeField]private TextInteraction _otherPerson; //get the same script as this but on the other person

    [Header("On UI elements")]
    [SerializeField] GameObject _interactionObj; //the obj that contains the text object and pannels
    [SerializeField] TextMeshProUGUI _interactionText;// the obj that contains the text component
    [SerializeField] TextMeshProUGUI npcNameText;


    [Header("The text")]
    [SerializeField] private string NpcName;
    [Space]
    [TextAreaAttribute] //give more space to write
    [SerializeField] private string[] NpcWords;// array of paragraph

    [Header("Typing")]
    [Space]
    [SerializeField] private float typingSpeed = 0.04f;// the typing speed
    private bool endText = true;
    public int textLocation = 0;// get whi  ch one of the paragraphs or enabled
    public bool StartTyping;

    private bool started = false;

    private bool nextFrase = false;//variable that checks if the player can go to the next paragraph
    [SerializeField]private bool start = false;

    public bool hadConversation = false;
    private void Start()
    {
        start = true;
    }
    private void Update()
    {
        if (start)
        {
            NextLineAndStop();
        }
    }

    private void NextLineAndStop()
    {

        if (!started)
        {
            npcNameText.text = NpcName;
            StartTyping = false;
            StopAllCoroutines();
            _interactionObj.SetActive(true);
            started = true;
            StartCoroutine(DisplayLine(NpcWords[textLocation]));

        }
        //if player press the interaction button and the paragraph was over, go to the next paragraph
        if (Input.GetKeyDown(KeyCode.F) && textLocation < NpcWords.Length && nextFrase == true)
        {
            _interactionObj.SetActive(true);
            StopAllCoroutines();
            StartTyping = false;
            textLocation += 1;

            StartCoroutine(DisplayLine(NpcWords[textLocation]));
        }
        else if (textLocation == NpcWords.Length|| textLocation==5)
        {
            hadConversation = true;
            textLocation += 1;
        }
        //if paragraph were over than disable the UI interaction obj
        if (Input.GetKeyDown(KeyCode.F)&& hadConversation)
        {
            _interactionObj.SetActive(false);
            ChagePerson();
        }
    }
    //method that run the courotine


    //separate the string into chars and write one by one
    private IEnumerator DisplayLine(string line)
    {
        nextFrase = false;
        //empty the dialogue text
        _interactionText.text = "";

        //display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            StartCoroutine(StartTypingDelay());
            _interactionText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            //if Player press the button it will display the entire paragraph and stop writing letter by letter
            if (Input.GetKeyDown(KeyCode.F) && StartTyping)
            {
                _interactionText.text = line;
                StartTyping = false;
                nextFrase = true;
                break;
            }
        }

        nextFrase = true;

    }
    private IEnumerator StartTypingDelay()
    {
        yield return new WaitForSeconds(0.1f);
        StartTyping = true;
    }

    private void ChagePerson()
    {
        if(_otherPerson.textLocation <= _otherPerson.NpcWords.Length)
        {
            start = false;
            _otherPerson.start = true;
            _otherPerson._interactionObj.SetActive(true);
        }

    }

}
