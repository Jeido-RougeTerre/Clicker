using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListManager : MonoBehaviour {


    // Start is called before the first frame update
    void Start() {
        GameObject template = transform.GetChild(0).gameObject;
        GameObject g;// just to keep track of item inst

        foreach(GunData gun in UIManager.uiManager.gunList) {
            g = Instantiate(template, transform);
            g.GetComponent<ItemShop>().SetGun(gun);
        }
        
        Destroy(template);
    }
}
