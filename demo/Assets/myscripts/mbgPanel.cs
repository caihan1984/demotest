using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public enum eBuildType
//{
//	WatchTower	=	0, //0表示未修建，1表示初级，数字代表等级
//	ShooterTower,
//	GriffinTower,
//	CampTower,
//	Temple,
//	TrainGround,
//	Heaven,
//
//	BuildingType = 7,
//}

//定义一些全局的数据变量
public class cGameDataDef
{
	public static int WatchTower = 1;
	public static int ShooterTower = 2;
	public static int GriffinTower = 3;
	public static int CampTower = 4;
	public static int Temple = 5;
	public static int TrainGround = 6;
	public static int Heaven = 7;

	public static int BuildingType = 7;			//建筑种类
}

//玩家数据
public class CUser
{
//	public int[] UserBuilds = new int[cGameDataDef.BuildingType];
	public Dictionary<int, int>	m_dUserBuilds = new Dictionary<int, int> ();

	private static CUser m_instance = null;

	public CUser()
	{
		m_dUserBuilds.Add (cGameDataDef.WatchTower, 1);
		m_dUserBuilds.Add (cGameDataDef.ShooterTower, 1);
		m_dUserBuilds.Add (cGameDataDef.GriffinTower, 0);
		m_dUserBuilds.Add (cGameDataDef.CampTower, 0);
		m_dUserBuilds.Add (cGameDataDef.Temple, 0);
		m_dUserBuilds.Add (cGameDataDef.TrainGround, 0);
		m_dUserBuilds.Add (cGameDataDef.Heaven, 0);
	}

	public static CUser Instance()
	{
		if (m_instance == null) 
		{
			m_instance = new CUser ();
		}
		return m_instance;
	}

	public int GetBuildLevel(int iBType)
	{
		return m_dUserBuilds [iBType];
	}
}

public class mbgPanel : MonoBehaviour {
	public GameObject goTownHall;
	GameObject goCancelBuild;

	private static mbgPanel m_instance = null;

	public static mbgPanel Instance()
	{
		if (m_instance == null) m_instance = new mbgPanel();
		return m_instance;
	}
	// Use this for initialization
	void Start () {
		GameObject goButton = GameObject.Find ("internalBuild");
		UIEventListener.Get (goButton).onClick = TownHallClickEvent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CancelClickEvent(GameObject goCancel)
	{
		goTownHall.SetActive (false);
	}

	void TownHallClickEvent(GameObject goButton)
	{
		goTownHall.SetActive (true);
		if (goCancelBuild == null)
		{
			goCancelBuild = GameObject.Find ("cancelBuildsp");
			UIEventListener.Get (goCancelBuild).onClick = CancelClickEvent;
		}
		var goGriffin = goTownHall.transform.Find ("griffinSprite");
		UISprite uspGri = goGriffin.GetComponent<UISprite> ();
		//查看建筑修建条件是否达成

		if (CUser.Instance().GetBuildLevel(cGameDataDef.CampTower) > 0)
		{
			uspGri.spriteName = "griffin";
		}
		else
		{
			uspGri.spriteName = "griffin_un";
		}

		var goCamp = goTownHall.transform.Find ("campSprite");
		UISprite uspCamp = goCamp.GetComponent<UISprite> ();
		//查看建筑修建条件是否达成
		if (CUser.Instance().GetBuildLevel(cGameDataDef.WatchTower) > 0)
		{
			uspCamp.spriteName = "camp";
		}
		else
		{
			uspCamp.spriteName = "camp";
		}
	}

	//建筑建造

}
