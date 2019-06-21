using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {

    public GameObject asteroid;
    public Vector3 randomPoz;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    bool oyunBittiKontrol = false;
    bool yenidenBaslat = false;
    public Text oyunBittiText;
    public Text yenidenBaslaText;

    int score;
	void Start ()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(Olustur());
	}
    void Update() //mouse klavye girişleri buradan alınır
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenBaslat) //R ye basıldığında ve yenidenbaşlatma true olduğunda yeniden başlatır
        {
            SceneManager.LoadScene("level1");
        }
    }
    IEnumerator Olustur()
    {
        /*
         * önce 2 sn bekler
         sonra while ve for döngülerine girer
         sonra bir nesne oluşturur 0.7 sn bekler
         10 tane nesneyi bu şekilde oluşturur sonra döngüden çıkar
         2 sn bekler
         sonra aynı şeyleri tekrar yapar
         */
        yield return new WaitForSeconds(baslangicBekleme); //oyun başladıktan sonra baslangic bekleme süresi kadar bekler sonra oyun çalışır
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPoz.x, randomPoz.x), 0, randomPoz.z);
                //asteroidin belirli değerler (6-12) arasında oluşmasını istiyoruz
                //bu değerleri unity üzerinden giriyoruz
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme); //nesneyi oluşturduktan sonra 1 sn bekler
            }

            if (oyunBittiKontrol)
            {
                yenidenBaslaText.text = "Yeniden başlamak için R tuşuna basınız"; 
                yenidenBaslat = true;
                break;
            }

            yield return new WaitForSeconds(donguBekleme);
            
        }        
    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "Score = " + score;
    }
    public void OyunBitti()
    {
        oyunBittiText.text = "OYUN BİTTİ";
        oyunBittiKontrol = true;

    }
	
}
