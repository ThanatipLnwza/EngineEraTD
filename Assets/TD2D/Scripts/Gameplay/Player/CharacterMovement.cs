﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour 
{
	float dirX, dirY, rotateAngle;

	[SerializeField]
	float moveSpeed = 2f;

	Animator anim;
	// Use this for initialization
	void Start ()
	{
		rotateAngle = 0f;
		anim = GetComponent<Animator> ();
		anim.speed = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
		Rotate ();
	}

	void Move()
	{
		dirX = Mathf.RoundToInt(CrossPlatformInputManager.GetAxis ("Horizontal"));
		dirY = Mathf.RoundToInt(CrossPlatformInputManager.GetAxis ("Vertical"));
		transform.position = new Vector2 (dirX * moveSpeed * Time.deltaTime + transform.position.x,
			dirY * moveSpeed * Time.deltaTime + transform.position.y);
	}
	
	void Rotate()
	{
		if (dirX == 0 && dirY == 1) {
			rotateAngle = 0;
			anim.speed = 1;
			anim.SetInteger ("Direction", 1);
		}

		if (dirX == 1 && dirY == 1) {
			rotateAngle = -45f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 2);
		}

		if (dirX == 1 && dirY == 0) {
			rotateAngle = -90f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 3);
		}

		if (dirX == 1 && dirY == -1) {
			rotateAngle = -135f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 4);
		}

		if (dirX == 0 && dirY == -1) {
			rotateAngle = -180f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 5);
		}

		if (dirX == -1 && dirY == -1) {
			rotateAngle = -225f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 6);
		}

		if (dirX == -1 && dirY == 0) {
			rotateAngle = -270f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 7);
		}

		if (dirX == -1 && dirY == 1) {
			rotateAngle = -315f;
			anim.speed = 1;
			anim.SetInteger ("Direction", 8);
		}

		if (dirX == 0 && dirY == 0) {
			anim.speed = 1;
			anim.SetInteger ("Direction", 0);
		}
	}

}
