using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 v3;
    public float karakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0;
    public float atesGecenSure;
    public GameObject kursun;
    public Transform kursunCikisYeri;
    AudioSource audio;

    void Start ()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}

    void Update() //her frame de çalıştığı için her tıklamada kesin olarak algılanır
    {
        if (Input.GetButton("Fire1") && Time.time>atesZamani)
        {
            //Debug.Log("ates edildi");
            atesZamani = Time.time + atesGecenSure;
            //0.1 sn aralıklarla ateş etmesini sağlar
            Instantiate(kursun, kursunCikisYeri.position, Quaternion.identity); //ilgili objenin klonlanmasını sağlar
            audio.Play();                                                                   // Quaternion.identity objenin pozisyonunu alır

        }
    }

    void FixedUpdate () //uygulamada fizik olaylarını kullanacağımız için fixed update kullanıyoruz
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        v3 = new Vector3(horizontal, 0, vertical); 
        //cisim y ekseninde hareket etmemeli yani yukarı aşağı gitmemeli
        //o yüzden y parametresi 0 oldu

        fizik.velocity = v3*karakterHiz; //cismin hızını değiştirmek için bunu kullandık
        
        //cismin ekrandan dışarı çıkmaması için önce fizik nesnesinin pozisyonunu kısıtlamak gerekir
        //Mathf.Clamp(fizik.position.x, minX, maxX)
        //bu fonksiyon fizik nesnesinin pozisyonunu verdiğimiz min ve max değerler arasına ayarlar

        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x, minX, maxX), 
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)
            );

        //cisim sağa ya da sola gireken hafif yamulsun istiyoruz
        //sağa sola x ekseninde gittiği için en sonda x dedik
        //saga gidince saga sola gidince sola yamulsun diye en sonda -egim ile carptık
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * (-egim));

    }
}
