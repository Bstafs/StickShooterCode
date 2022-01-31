using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingIntoBoss : MonoBehaviour
{
	public GameObject wall;
	public GameObject boss;
	public GameObject health1;
	public GameObject health2;
	public int targetFrameRate = 60;

	void Start()
	{
		wall.SetActive(false);
		boss.SetActive(false);
		health1.SetActive(false);
		health2.SetActive(false);

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
	
}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			wall.SetActive(true);
			boss.SetActive(true);
			health1.SetActive(true);
			health2.SetActive(true);
		}
	}


}
