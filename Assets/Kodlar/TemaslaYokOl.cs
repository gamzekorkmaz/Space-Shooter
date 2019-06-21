using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour {
    public GameObject asteroidPatlama;
    public GameObject playerPatlama;
    GameObject oyunKontrolNesnesi;
    OyunKontrol oyunKontrolScript;

    void Start()
    {
        oyunKontrolNesnesi = GameObject.FindGameObjectWithTag("OyunKontrol"); //oyunkontrol nesnesini ekledik
        oyunKontrolScript = oyunKontrolNesnesi.GetComponent<OyunKontrol>(); //oyunkontrol scriptini/komponentini ekledik
        
    }
    void OnTriggerEnter(Collider col)
    {
        
        if(col.tag != "Sinir") //eğer tag sinir değilse kurşunu ve asteroidi yok edecek
         //böylece sinir nesnemiz yok olmayacak
        {
            Destroy(col.gameObject); //çarpan objeyi yani çarpan kurşunu yok et
            Destroy(gameObject); //asteroidi yok et
            Instantiate(asteroidPatlama, transform.position, transform.rotation);
            //patlama nesnesini asteroidin pozisyon ve rotasyon bilgilerini alarak kopyalar
            oyunKontrolScript.ScoreArttir(10);
        }
        if (col.tag == "Player")
        {
            Instantiate(playerPatlama, col.transform.position, col.transform.rotation);
            //eğer player a çarparsa player ın olduğu rotasyon ve pozisyon bilgilerini alarak player üzerinde patlama oluşturur
            oyunKontrolScript.OyunBitti();
        }
        
    }
}
