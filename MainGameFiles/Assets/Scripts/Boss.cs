using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
	public float health = 100f;
	[SerializeField]
	public float currentHealth;
	public Slider healthBarSlider;
	public GameObject healthbarObject;

	public float minSize;
	public GameObject bossPreFab;
	public GameObject boss;

	public AudioSource death;


	void Start()
	{
		currentHealth = health;
	}

	private void Update()
	{
		healthBarSlider.value = currentHealth;
	}

	public void BossDamage(float damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			death.Play();
			BossDeath();			
			Destroy(boss);
			Destroy(healthbarObject);
		
		}
	}
	void BossDeath()
	{
		Debug.Log("Dead");

		if (transform.localScale.y > minSize)
		{
			GameObject clone1 = Instantiate(bossPreFab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
			GameObject clone2 = Instantiate(bossPreFab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

			clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
            
			clone1.GetComponent<Boss>().health = 50;
			


			clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
           
            clone2.GetComponent<Boss>().health = 50;
			

		}

		

	}
}
