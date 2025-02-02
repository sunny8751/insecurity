﻿using UnityEngine;
using System.Collections;

public class Clothes : MonoBehaviour {

	public bool hasToy = false;
	//if counter reaches 3, the clothes disappear
	int counter=0;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//jumped on clothes
		if(other.GetComponent<Rigidbody2D>().velocity.y<0){
		counter++;
			//instantiate poof
			Instantiate((GameObject)Resources.Load("ClothesPoof"), transform.position, Quaternion.identity);
		}
		if(counter==3){
			//make clothes disappear
			Destroy(transform.parent.gameObject);
			if(hasToy){
				//drop the toy now
				Instantiate((GameObject)Resources.Load("Sprites/toy"), new Vector3(transform.position.x,-4,0),Quaternion.identity);
				GameObject.FindWithTag("Player").GetComponent<Player>().next();
			}
		}
	}
}
