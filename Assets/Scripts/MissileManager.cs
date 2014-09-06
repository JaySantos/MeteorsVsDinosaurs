using UnityEngine;
using System.Collections;

public class MissileManager : MonoBehaviour 
{
	public float missileSpeed = 4f;
	public float waitToDestroy = 3f;
	private Vector2 target;
	private bool startMoving = false;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startMoving)
		{
			transform.Translate(target * missileSpeed * Time.deltaTime);
		}
	}

	public void SetDirection(Vector2 v)
	{
		Debug.Log("SetDirection");
		/*Vector3 v = new Vector3 (x, y, transform.position.z);
		Debug.Log(v);
		//target = Camera.main.ScreenToWorldPoint(v);
		target.z = 0f;
		//target = v;
		//Debug.Log(target);
		target = Camera.main.WorldToScreenPoint(v);
		Debug.Log(target);
		target.z = 0f;*/
		target = v;
		startMoving = true;
		StartCoroutine("DisableMissile");
	}

	IEnumerator DisableMissile()
	{
		yield return new WaitForSeconds(waitToDestroy);
		gameObject.SetActive(false);
	}
}
