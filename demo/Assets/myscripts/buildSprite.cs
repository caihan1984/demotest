using UnityEngine;
using System.Collections;

public class buildSprite : MonoBehaviour {
	//gameObject区别用法
	public GameObject goBuildIF;
	GameObject goCancel;
	GameObject goConfirm;
	public GameObject goCampBuild;

	public GameObject goRecruitFrame;

//	bool bClickFlag = false;
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

	//建筑修建确认回调
	void ConfirmClickEvent(GameObject goButton)
	{
		//Debug.Log (mbgPanel.Instance ().goTownHall.);
	//	var go = mbgPanel.Instance ().goTownHall;
	//	go.SetActive (false);

		GameObject.Find ("buildings").SetActive (false);

		goCampBuild.SetActive (true);
		var upt = goCampBuild.GetComponent<UIPlayTween> ();
		upt.Play (true);

		GameObject goFrame = GameObject.Find ("campBuild");
		UIEventListener.Get (goFrame).onClick = RecruitFrameClickEvent;

		//修建建筑?????????????????????????????? 同名sprite 这里回调找不到go 回调参数
		//mbgPanel.Instance ().BuildCamp ();  继承MonoBehaviour new
//		var go = mbgPanel.Instance ().goCampBuild;
//		go.SetActive (true);
	}

	void RecruitFrameClickEvent(GameObject go)
	{
		goRecruitFrame.SetActive (true);

		GameObject goCamp = GameObject.Find ("ceruitFrame/confirmSprite");
		UIEventListener.Get (goCamp).onClick = mbgPanel.Instance().RecruitClickEvent;
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
		if (goCancel == null)
		{
			goCancel = GameObject.Find ("cancelSprite");
			UIEventListener.Get (goCancel).onClick = CancelClickEvent;
		}

		var goConfirm = GameObject.Find("confirmSprite");
		//var goConfirm = goBuildIF.transform.Find("confirmSprite");
		UISprite uspConfirm = goConfirm.GetComponent<UISprite> ();

		if (goButton.name == "griffinSprite")
		{
			uspConfirm.spriteName = "confirmbuild_un";
		}
		else if (goButton.name == "campSprite")
		{	
			uspConfirm.spriteName = "confirmbuild";
		}

		if (uspConfirm.spriteName == "confirmbuild")
		{
			UIEventListener.Get(goConfirm).onClick = ConfirmClickEvent;
		}
	}
}
