using UnityEngine;
using System.Collections;

public class buildSprite : MonoBehaviour {
	//gameObject区别用法
	public GameObject goBuildIF;
	GameObject goCancel;

	bool bClickFlag = false;
	// Use this for initialization
	void Start () {
		GameObject goGriffin = GameObject.Find ("griffinSprite");
		UIEventListener.Get (goGriffin).onClick = BuildIFClickEvent;

		GameObject goCamp = GameObject.Find ("campSprite");
		UIEventListener.Get (goCamp).onClick = BuildIFClickEvent;

//		GameObject goCancel = GameObject.Find ("cancelSprite");
//		UIEventListener.Get (goCancel).onClick = BuildIFClickEvent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CancelClickEvent(GameObject goButton)
	{
		goBuildIF.SetActive (false);
	}

	void BuildIFClickEvent(GameObject goButton)
	{
//		Debug.Log ("game name" + goButton.name);
//		if (bClickFlag == false)
//		{
//			goBuildIF.SetActive (true);
//			bClickFlag = true;
//		}
//		else 
//		{
//			GameObject goCancel = GameObject.Find ("cancelSprite");
//			goCancel.SetActive (false);
//		}

		goBuildIF.SetActive (true);
		goCancel = GameObject.Find ("cancelSprite");
		UIEventListener.Get (goCancel).onClick = CancelClickEvent;
	}
}
