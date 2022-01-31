using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

	public float health = 100f;
	[SerializeField]
	public float currentHealth;
	public Slider healthBarSlider;
	public GameObject healthbarObject;
	public AudioSource death;
	

    void Start()
    {
		currentHealth = health;
		
		
    }

	private void Update()
	{
		healthBarSlider.value = currentHealth;
	}

	public void Damage(float damage)
	{
		currentHealth -= damage;

		if ( currentHealth <= 0)
		{
			Die();		
		}
	}
	void Die()
	{
		death.Play();
		Debug.Log("Dead");
		currentHealth = health;
		Destroy(gameObject);
		Destroy(healthbarObject);
	}


}
