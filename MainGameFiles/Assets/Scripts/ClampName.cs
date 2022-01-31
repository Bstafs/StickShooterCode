using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{

	public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3 healthPos = Camera.main.WorldToScreenPoint(this.transform.position);
		healthbar.transform.position = healthPos;
    }
}
