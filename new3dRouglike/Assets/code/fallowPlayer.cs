﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallowPlayer : MonoBehaviour
{

	public GameObject Target;
	// Update is called once per frame
	void Update ()
	{
		transform.position = Target.transform.position;
	}
}
