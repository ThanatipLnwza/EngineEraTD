using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
	private float cooldownCounter;
	[SerializeField] private float firerate;
	Gun[] guns;

	private void Start()
	{
		guns = transform.GetComponentsInChildren<Gun>();
	}
	
	void FixedUpdate()
	{
		if (cooldownCounter < firerate)
		{
			cooldownCounter += Time.fixedDeltaTime;
		}
	}
	
	public void Update()
	{
		if (cooldownCounter >= firerate)
		{
			cooldownCounter = 0f;
			foreach (Gun gun in guns)
			{
				gun.Shoot();
			}
		}
	}

	
}
