using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinirKontrol : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject); 
        //oluşturduğumuz küp şeklindeki collider'a kurşun çarpacak ve kurşun yok olacak
        //eğer böyle yapmazsak oyun sırasında sürekli kurşun oluşacak ve bir süre sonra oyun kasacak fps değeri yükselecek

    }
}
