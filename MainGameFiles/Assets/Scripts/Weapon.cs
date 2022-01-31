using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bullet;
	public int damage = 25;
	public GroundChecker groundChecker;
	public float fireRate;
	float timeFire = 0;

	public int maxAmmo = 10;
	public int currentAmmo;
	public float reloadTime = 5f;
	public bool isReloading = false;
	public bool canReload = true;
	private bool canShoot = true;
	public TextMeshProUGUI ammoAmount;
    public Transform bulletRoation;

	public AudioSource assaultRifle;
	public AudioSource pistol;
	public AudioSource assaultRifleReload;
	public AudioSource pistolReload;
	
	public PlayerMovement mag;
	public WeaponSwitcher whatWeapon;
	

	private void Start()
	{
		currentAmmo = maxAmmo;
		currentAmmo = 0;
	}
	private void OnEnable()
	{
		isReloading = false;
		canReload = true;
		canShoot = true;
		whatWeapon.canSwitchWeapon = true;
	}
	void Update()
    {
		ammoAmount.text = "Ammo: " + currentAmmo;

		if (isReloading)
		{
			return;
		}
		if (currentAmmo <= 0 && canReload == true && whatWeapon.selectedWeapon == 1 && Input.GetAxisRaw("ControllerButtonX") > 0) // if  you have no ammo; reload and remove a mag
		{
			whatWeapon.canSwitchWeapon = false;					
					
			StartCoroutine(Reload());
			canShoot = true;
			return;
		}
		else if (currentAmmo <= 0 && canReload == false && whatWeapon.selectedWeapon == 1)
		{
			currentAmmo = 0;
			canShoot = false;
		}
		if(mag.pistolCurrentMagCount < 1 && whatWeapon.selectedWeapon == 1)  // if  you have no mags, cant reload.
		{
			canReload = false;
			mag.pistolCurrentMagCount = 0;
			if (currentAmmo > 0)
			{
				canShoot = true;
			}
			else if (currentAmmo == 0)
			{
				canShoot = false;
			}
		}
		else if (mag.pistolCurrentMagCount > 0 && whatWeapon.selectedWeapon == 1 && isReloading == false)// if you have more than 0 mags, can reload
		{
			canReload = true;
			if (currentAmmo == 0)
			{
				canShoot = false;
			}
		}
   
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (currentAmmo <= 0 && canReload == true && whatWeapon.selectedWeapon == 0 && Input.GetAxisRaw("ControllerButtonX") > 0) // if  you have no ammo; reload and remove a mag
		{
			whatWeapon.canSwitchWeapon = false;										
			StartCoroutine(Reload());
			canShoot = true;
			return;
		}
		else if (currentAmmo <= 0 && canReload == false && whatWeapon.selectedWeapon == 0) 
		{
			currentAmmo = 0;
			canShoot = false;
		}
		if (mag.assaultCurrentMagCount <= 0 && whatWeapon.selectedWeapon == 0)  // if  you have no mags, cant reload.
		{
			canReload = false;
			mag.assaultCurrentMagCount = 0;
			if (currentAmmo > 0)
			{
				canShoot = true;
			}
			else if ( currentAmmo == 0)
			{
				canShoot = false;
			}

		}
		else if (mag.assaultCurrentMagCount >= 0 && whatWeapon.selectedWeapon == 0)// if you have more than 0 mags, can reload
		{
			canReload = true;      
			if (currentAmmo == 0)
			{
				canShoot = false;
			}
        }
       
		if (mag.isGrounded == true)
		{
			if (Input.GetAxisRaw("ControllerRightTrigger") > 0 && fireRate == 0)
			{
				OnShoot();
			}
			if (Input.GetAxisRaw("ControllerRightTrigger") == 1 && fireRate > 0)
			{
			  OnShoot();
		    }

		}
		void OnShoot()
		{
			if (fireRate == 0)
			{
				OnShoot();
			}
			else
			{
				if (Time.time > timeFire)
				{
					timeFire = Time.time + 1 / fireRate;
					Shoot();
				}
			}
		}
		void Shoot()
		{
			if (canShoot == true)
			{
				if (whatWeapon.selectedWeapon == 0)
				{
					Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
					currentAmmo--;
					assaultRifle.Play();
					Debug.Log("Rifle");
				}
				else if (whatWeapon.selectedWeapon == 1)
				{
					Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
					currentAmmo--;
					pistol.Play();
					Debug.Log("Pistol");
				}

			
			}
		}
		IEnumerator Reload()
		{
			
			isReloading = true;
            whatWeapon.canSwitchWeapon = false;
			Debug.Log("Reloading");
			if (whatWeapon.selectedWeapon == 1)
			{
				pistolReload.Play();
			}
			else if (whatWeapon.selectedWeapon == 0)
			{
				assaultRifleReload.Play();
			}

			yield return new WaitForSeconds(reloadTime);
           
			currentAmmo = maxAmmo;
           if(whatWeapon.selectedWeapon == 1)
           {
                mag.pistolCurrentMagCount -= 1;
           }
            else if (whatWeapon.selectedWeapon == 0)
            {
                mag.assaultCurrentMagCount -= 1;
				
            }
            whatWeapon.canSwitchWeapon = true;
            isReloading = false;
			whatWeapon.canSwitchWeapon = true;
            
        }
		
	}
}
