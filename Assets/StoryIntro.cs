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
    [SerializeField] Text OutroTextObject;

    [SerializeField] State startingState;

    State state;
    string story;

    private bool difficultyIsSelectable = false;
    private int runnedStatesCounter = 0;




    //Update text and start typewriter effect
    public void ChangeText(string _text, float _delay = 0f)
    {
        introTextObject.text = ""; //clean text
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = _text;

        Invoke("Start_PlayText", _delay); //Invoke effect 
    }
    IEnumerator PlayText()
    {
        introTextObject.text = "";
        foreach (char c in story)
        {
            // Debug.Log(c);
            introTextObject.text += c;
            yield return new WaitForSeconds(0.125f);
        }
        runnedStatesCounter++;
        Debug.Log(runnedStatesCounter);
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    void Start()
    {
        story = "_ You start your journey in a small Spaceship within the endless Universe. Are you prepared for saving the world?";
        state = startingState;
        Start_PlayText();
        ChangeText(state.GetStateStory(), 20);
    }

    // Update is called once per frame
    void Update()
    {


        if (runnedStatesCounter == 2)
        {
            ManageState();
        }
        
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if (nextStates.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = nextStates[0];
                introTextObject.text = state.GetStateStory();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = nextStates[1];
                introTextObject.text = state.GetStateStory();
                OutroTextObject.text = "Press Space to Continue!";
            }
        }
    }
}
