using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PlayOnAwake = true;
    public float Delay;
    [SerializeField] Text introTextObject;
    [SerializeField] State startingState;

    State state;
    string story;




    //Update text and start typewriter effect
    public void ChangeText(string _text, float _delay = 0f)
    {
        introTextObject.text = ""; //clean text
        StopCoroutine(PlayText(true)); //stop Coroutime if exist
        story = _text;

        Invoke("Start_PlayText", _delay); //Invoke effect
    }
    IEnumerator PlayText(bool delayedStart)
    {
        // introTextObject.text = introTextObject.text.Remove(introTextObject.text.Length - 3);
        // if (delayedStart)
        // {
        //     yield return new WaitForSeconds(3);
        // }
        introTextObject.text = "";
        foreach (char c in story)
        {
            // Debug.Log(c);
            introTextObject.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText(false));
    }

    void Update_Text(string _newText)
    {
        story = _newText;
        introTextObject.text = "";
        StartCoroutine(PlayText(true));
    }

    void Start()
    {
        story = "_ You start your journey in a small Spaceship within the endless Universe. Are you prepared for saving the world?";
        state = startingState;
        Start_PlayText();
        ChangeText(state.GetStateStory(), 20);
        // Update_Text("Testing new state");
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();

    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
            introTextObject.text = state.GetStateStory();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
            introTextObject.text = state.GetStateStory();
        }


    }
}
