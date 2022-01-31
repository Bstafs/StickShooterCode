using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

	public int speed;
	public float timeToDestroy;
	
	

	private void OnEnable()
	{
		StartCoroutine(AutoDestroy(timeToDestroy));
	}

	// Update is called once per frame
	void Update()
    {
		transform.Translate(Vector3.right * Time.deltaTime * speed);
    }


	IEnumerator AutoDestroy ( float _time)
	{
		yield return new WaitForSeconds(_time);
		Destroy(gameObject);
	}
	 
	

}


