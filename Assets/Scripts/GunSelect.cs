using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour
{
    private GunData gun;

    public void AddGun(GunData gun) {
        this.gun = gun;
    }

    public void OnClick() {
        UIManager.uiManager.SetGun(gun);
    }
}
