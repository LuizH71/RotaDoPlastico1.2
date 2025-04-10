using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum npcs { MainCharacter, OldScientist }
public enum Animation { Falando, BocaAberta, BocaFechada, Feliz}
public class TextInteraction : MonoBehaviour
{
    [System.Serializable]
    public class Interaction
    {
        public npcs NPC;
        public Sprite FacialExpression;
        public Image IMG;

        [TextArea] //give more space to write
        public string NpcDialogue;
    }

    [Header("On UI elements")]
    [SerializeField] GameObject _interactionObj; //the obj that contains the text object and pannels
    [SerializeField] TextMeshProUGUI _interactionText;// the obj that contains the text component
 
    [Header("Old scientist")]
    [SerializeField] private GameObject _oldScientistObj;

    [Header("Main character")]
    [SerializeField] private GameObject _mainCharacterObj;



    [SerializeField] private Interaction[] NpcInteraction;// array of paragraph

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
    private bool _input = false;
    private void Start()
    {
        start = true;
    }
    private void Update()
    {
        TouchInput();
        if (start)
        {
            NextLineAndStop();
        }
    }

    private void NextLineAndStop()
    {

        if (!started)
        {
            StartTheConversation();
        }
        else
        {
            GoToNextParagraphOrisble();
        }

    }

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
            if (_input && StartTyping)
            {
                _input = false;
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


    //Gets the input on the screen
    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                _input = true;
            }

        }
    }
    //method that run the courotine
    private void GoToNextParagraphOrisble()
    {
        //if player press the interaction button and the paragraph was over, go to the next paragraph
        if (_input && textLocation < NpcInteraction.Length && nextFrase == true)
        {
            _interactionObj.SetActive(true);
            StopAllCoroutines();
            StartTyping = false;
            textLocation += 1;
            updateUI(NpcInteraction[textLocation].NPC);//Updatede ui/ Switches characters

            _input = false;
            StartCoroutine(DisplayLine(NpcInteraction[textLocation].NpcDialogue));
        }
        else if (textLocation == NpcInteraction.Length) //if paragraph were over than disable the UI interaction obj
        {
            hadConversation = true;
            textLocation += 1;
            _input = false;
            _interactionObj.SetActive(false);
        }
    }
    private void StartTheConversation()
    {
        StartTyping = false;
        StopAllCoroutines();
        _interactionObj.SetActive(true);
        started = true;
        StartCoroutine(DisplayLine(NpcInteraction[textLocation].NpcDialogue));
        updateUI(NpcInteraction[textLocation].NPC);//Updatede ui/ Switches characters
    }

    private void updateUI(npcs NPC)
    {
        NpcInteraction[textLocation].IMG.sprite = NpcInteraction[textLocation].FacialExpression;
        switch (NPC)
        {
            case npcs.OldScientist:
                _mainCharacterObj.SetActive(false);
                _oldScientistObj.SetActive(true);
                break;
            case npcs.MainCharacter:
                _mainCharacterObj.SetActive(true);
                _oldScientistObj.SetActive(false);
                break;
        }
            
    }
}
