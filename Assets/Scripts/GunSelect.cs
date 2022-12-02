using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSelect : MonoBehaviour
{
    private GunData gun;
    private TMP_Text gunName;

    public void AddGun(GunData gun) {
        this.gun = gun;
    }

    private void Awake() {
        gunName = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void OnClick() {
        GunData gunFound = new GunData();
        foreach(GunData _gun in UIManager.uiManager.gunList) {
            if(_gun.m_GunName == gunName.text) {
                gunFound = _gun;
                break;
            }
        }
        if (gunFound.m_GunName == "'GUN'") {
            return;
        }



        Debug.Log("Select Gun : " + gunFound.m_GunName);
        UIManager.uiManager.SetGun(gunFound);
        UIManager.uiManager.CloseInventory();
    }
}
