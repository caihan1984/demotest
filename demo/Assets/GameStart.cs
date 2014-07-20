using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {
	public static GameObject mbp = null;
	// Use this for initialization
	void Awake () {
		mbp =  GameObject.FindWithTag("mbg");
	}

	//跳转screen 析构静态变量
	public void Dispose()
	{
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
