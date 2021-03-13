using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroStory : MonoBehaviour
{
    [SerializeField] Text introTextObject;

    System.String intropart2 = " Are you prepared for saving the world?";
    string story = "You start your journey in a small Spaceship within the endless Universe. Are you prepared for saving the world?";
    public bool PlayOnAwake = true;
    public float Delay;
    // Start is called before the first frame update

    IEnumerator PlayText()
    {
        // introTextObject.text = introTextObject.text.Remove(introTextObject.text.Length - 3);
        foreach (char c in story)
        {
            introTextObject.text += c;
            yield return new WaitForSeconds(0.125f);
        }


    }

    //Update text and start typewriter effect
    public void ChangeText(string _text, float _delay = 0f)
    {
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = _text;
        // txt.text = ""; //clean text
        Invoke("Start_PlayText", _delay); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }


    void Start()
    {
        Start_PlayText();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
