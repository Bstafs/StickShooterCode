using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Pause : MonoBehaviour
{

	public AudioSource gameSound;
	public GameObject MenuButton;

	// Start is called before the first frame update
	void Start()
	{
		MenuButton.SetActive(false);
		
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			if (Time.timeScale == 1)
			{
				Pausing();
			}
			else
			{
				Unpausing();
			}

		}

	}
	public void Pausing()
	{ 
		Time.timeScale = 0;
		gameSound.Stop();
		MenuButton.SetActive(true);
	

		EventSystem es = EventSystem.current;
		es.SetSelectedGameObject(null);
		es.firstSelectedGameObject = MenuButton;
		es.SetSelectedGameObject(MenuButton);

	}
	public void Unpausing()
	{
		Time.timeScale = 1;
		gameSound.Play();
		MenuButton.SetActive(false);
	
		
	}

}
