using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHareketKontrol : MonoBehaviour {
    Rigidbody fizik;
    public float hiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * hiz; //oyun daha stabil çalışsın diye
                                                  //kurşuna bir kere ileri yönde kuvvet uygulanacak, ardından kurşun hep aynı hızda gidecek
    }
}
