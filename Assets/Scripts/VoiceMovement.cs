using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    void Start()
    {

    	actions.Add("left", left);
    	actions.Add("right", right);
        Debug.Log("started the voice");
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void left() {
        Debug.Log("left");
        GetComponent<PlayerMovement>().moveLeft();
    }

    private void right() {
        Debug.Log("right");
        GetComponent<PlayerMovement>().moveRight();
    }

  
}
