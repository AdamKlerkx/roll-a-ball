using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respauwn : MonoBehaviour {

	[SerializeField] private Transform player;
	[SerializeField] private Transform respauwnpoint; 

	void OnTriggerEnter(Collider other){
		player.transform.position = respauwnpoint.transform.position;
	} 
}
