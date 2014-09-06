using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissilePoolManager : MonoBehaviour 
{
	public int missilePoolSize = 100;
	public GameObject missilePrefab;

	private List<GameObject> missiles;

	// Use this for initialization
	void Start () 
	{
		//Pooling missiles...
		missiles = new List<GameObject>();

		for (int i = 0; i < missilePoolSize; i++)
		{
			GameObject obj = (GameObject)Instantiate(missilePrefab);
			obj.SetActive(false);
			missiles.Add(obj);
		}
	}

	public GameObject GetAvailableMissile()
	{
		for (int i = 0; i < missiles.Count; i++)
		{
			if (!missiles[i].activeInHierarchy)
			{
				//defaultBullets[i].transform.position = myTransform.position + (new Vector3(shootDirection.x, shootDirection.y, 0f) * 0.1f);
				//defaultBullets[i].transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f));
				
				//defaultBullets[i].GetComponent<BulletManager>().bulletDirection = shootDirection;
				missiles[i].SetActive(true);
				return (missiles[i]);
			}
		}
		return null;
	}
}