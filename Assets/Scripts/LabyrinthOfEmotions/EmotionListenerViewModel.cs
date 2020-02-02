using UnityEngine;
using Affdex;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class EmotionListenerViewModel : ImageResultsListener {

	public Text strongestEmo;
	public Text NorthEmoText;
	public Text EastEmoText;
	public Text SouthEmoText;
	public Text WestEmoText;

	public Image NorthEmoImg;
	public Image EastEmoImg;
	public Image SouthEmoImg;
	public Image WestEmoImg;

	public string lastColor; //to keep track to reset. 



	public FeaturePoint[] featurePointsList;
	public int[] nextNavArray = new int[2];
	public int[] currNavArray = new int[2];

	public EmoNav strongestEmoNav;
	private int emoChangeCount = 0;
	private int emoChangeInterval = 15;

	private enum emotionEnum {Joy, Suprise};
	Dictionary<int, EmoNav> emotionDict = new Dictionary<int, EmoNav>();

	public EmotionListenerViewModel() {
		//EventController.Instance.Subscribe ();
		//subscribe to events in constructor or in awake functions
	}

	public void Start() {
		Debug.Log("Starting");
		

		emotionDict.Add((int)emotionEnum.Joy, new EmoNav ("Joy", 0, "Resources/joy", Color.green));
		//emotionDict.Add((int)emotionEnum.Sadness, new EmoNav ("Sadness", 0, "Sprites/sadIcon", Color.blue));
		//emotionDict.Add((int)emotionEnum.Disgust, new EmoNav ("Disgust", 0,  "Sprites/DisgustIcon", Color.red));
		emotionDict.Add((int)emotionEnum.Suprise, new EmoNav ("Surprise", 0,  "Resources/surprised", Color.black));
		InvokeRepeating ("UpdateEmoNav", 0f, 15f);
		//InvokeRepeating ("UpdateEmoChangeCount", 0f, 1f);
		//UpdateEmoNav();
	}

	public override void onFaceFound(float timestamp, int faceId) {
		Debug.Log("Found the face");
	}

	public override void onFaceLost(float timestamp, int faceId) {
		Debug.Log("Lost the face");
	}

	public override void onImageResults(Dictionary<int, Face> faces) {
		//Debug.Log("Got face results, faces: "+ faces.Count);

		if(faces.Count > 0) {
			strongestEmoNav = new EmoNav ("Nothing", 0, "Sprites/angryIcon", Color.gray); //gray stuff

			faces[0].Emotions.TryGetValue (Emotions.Joy, out emotionDict [(int)emotionEnum.Joy].valence);
			// faces[0].Emotions.TryGetValue (Emotions.Sadness, out emotionDict [(int)emotionEnum.Sadness].valence);
			// faces[0].Emotions.TryGetValue (Emotions.Disgust, out emotionDict [(int)emotionEnum.Disgust].valence);
			faces[0].Emotions.TryGetValue (Emotions.Surprise, out emotionDict [(int)emotionEnum.Suprise].valence);

			if (emotionDict [(int)emotionEnum.Joy].valence > strongestEmoNav.valence) {
				strongestEmoNav = emotionDict [(int)emotionEnum.Joy];
			}
			if (emotionDict [(int)emotionEnum.Suprise].valence > strongestEmoNav.valence) {
				strongestEmoNav = emotionDict [(int)emotionEnum.Suprise];
			}

			this.strongestEmo.text = "Custom Strongest Emotion: " + strongestEmoNav.name + "/" + strongestEmoNav.valence;

			HighlightAndEvent (strongestEmoNav.name, strongestEmoNav.emoColor);
		}
	}

	public void HighlightAndEvent(string emotion, Color emoColor) {
        if (lastColor == "")
        {
			lastColor = emotion;
        }
        else if (lastColor == "Joy")
        {
			NorthEmoImg.color = Color.yellow;
        }
        else if (lastColor == "Sadness")
        {
			SouthEmoImg.color = Color.yellow;
        }
        else if (lastColor == "Surprise")
        {
			WestEmoImg.color = Color.yellow;
        }
        else if (lastColor == "Disgust")
        {
			EastEmoImg.color = Color.yellow;
        } //bad solution but it works. 
		switch(emotion) {
		case "Joy":
			NorthEmoImg.color = Color.green; //ye
	        lastColor = emotion;
			Debug.Log("Happiness!");
			OnNorthEmo(emotion);
			break;
		case "Surprise":
			SouthEmoImg.color = Color.green; //colorgreen
			lastColor = emotion;
			Debug.Log("Surprise!");
			OnWestEmo(emotion);
			break;
	
		default:
			break;
		}
	}

	// private void UpdateEmoChangeCount() {
	// 	if (emoChangeCount > 0) {
	// 		ChangeEmoCountText.text = "Emotions Change: " + emoChangeCount;
	// 		emoChangeCount--;
	// 	} else {
	// 		ChangeEmoCountText.text = "Emotions Change: " + emoChangeCount;
	// 		UpdateEmoNav ();
	// 		emoChangeCount = 20;
	// 	}
	// }

	private void UpdateEmoNav() {
		
		nextNavArray [0] = 0;
		nextNavArray [1] = 1;
		// nextNavArray [2] = 2;
		// nextNavArray [3] = 3;

		emotionDict [nextNavArray [0]].name = "Joy";
		NorthEmoImg.color = Color.grey;
		EastEmoText.text = emotionDict [nextNavArray [0]].name;
		SouthEmoImg.sprite = Resources.Load<Sprite> (emotionDict [nextNavArray [0]].sprite); //<- changed the sprite. 
	

		emotionDict [nextNavArray [1]].name = "Surprise";
		NorthEmoImg.color = Color.grey;
		EastEmoText.text  = emotionDict [nextNavArray [1]].name;
		EastEmoImg.sprite = Resources.Load<Sprite> (emotionDict [nextNavArray [1]].sprite);


		// emotionDict [nextNavArray [2]].name  = "Disgust";
		// NorthEmoImg.color = Color.grey;
		// SouthEmoText.text  = emotionDict [nextNavArray [2]].name;
		// SouthEmoImg.sprite = Resources.Load<Sprite> (emotionDict [nextNavArray [2]].sprite);


		// emotionDict [nextNavArray [3]].name  = "Surprise";
		// NorthEmoImg.color = Color.grey;
		// WestEmoText.text  = emotionDict [nextNavArray [3]].name;
		// WestEmoImg.sprite = Resources.Load<Sprite> (emotionDict [nextNavArray [3]].sprite);
		
	}

	


	public void OnNorthEmo(string emotion) {
		Debug.Log("HAPPINESS");
		EventController.Instance.Publish (new GoNorthEvent(emotion));

		///^^^^^^^^^^^^^^uncomment these
		//SO BASICALLY THE EVENTCONTROLLER GIVES THE GONORTHEVENT WHICH IM NOT
		//GONNA RENAME BC I DONT FEEL LIKE IT
		//BUT ESSENTIALLY this gets passed onto playercontroller.cs
		//and there, in playercontroller.cs, you'll add the shoot() method
		//which should shoot a special bullet that will only destroy
		//special objects of that emotion
		// also we need to fix the color to change on the emotion and then go back
		//also make the color change accordingly idk what the fuck
	}


	public void OnWestEmo(string emotion) {
		Debug.Log("SURPRISE");
		//EventController.Instance.Publish (new GoSouthEvent(emotion));
	}

	public class EmoNav {
		public string name;
		public float valence;
		public string sprite;
		public Color emoColor;

		public EmoNav(string name, float valence, string sprite, Color emoColor){
			this.name = name;
			this.valence = valence;
			this.sprite = sprite;
			this.emoColor = emoColor;
		}
	}

}
