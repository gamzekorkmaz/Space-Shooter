using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKontrol : MonoBehaviour {

    Rigidbody rb;
    public float hiz;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * hiz; 
        //random rotasyon sağlar yani cisin kendi etrafında random olarak döner

	}
	
}
