using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour 
{
	public GameObject topLeftGun;
	public GameObject topRightGun;
	public GameObject bottomLeftGun;
	public GameObject bottomRightGun;
	public GameObject topLeftTarget;
	public GameObject topRightTarget;
	public GameObject bottomLeftTarget;
	public GameObject bottomRightTarget;
	public GameObject weaponPrefab;

	private int screenWidth;
	private int screenHeight;
	private MissilePoolManager mpm;

	// Use this for initialization
	void Start () 
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		mpm = GameObject.Find("GameManager").GetComponent<MissilePoolManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				FireGun (touch.position.x, touch.position.y);
			}
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			FireGun (1, screenHeight - 1);
		}
	}

	private void FireGun(float x, float y)
	{
		Vector2 direction = new Vector2();
		GameObject go = mpm.GetAvailableMissile();
		if (x < screenWidth / 2) //Left
		{
			if (y < screenHeight / 2) //Bottom
			{
				direction = bottomLeftTarget.transform.position;
				go.transform.position = bottomLeftGun.transform.position;
			}
			else //Top
			{
				direction = topLeftTarget.transform.position;
				go.transform.position = topLeftGun.transform.position;
			}
		}

		else //Right
		{
			if (y < screenHeight / 2) //Bottom
			{
				direction = bottomRightTarget.transform.position;
				go.transform.position = bottomRightGun.transform.position;
			}
			else //Top
			{
				direction = topRightTarget.transform.position;
				go.transform.position = topRightGun.transform.position;
			}
		}
		go.GetComponent<MissileManager>().SetDirection(direction);
	}
}
