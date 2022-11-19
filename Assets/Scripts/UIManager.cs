using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public GunData Gun;
    
    ///<summary>
    /// might be smooth
    ///</summary>
    public CriminalManager Criminal;

    public TMP_Text moneyText;

    public uint money = 0;

    private void Start() {
        moneyText.text = money + "$";
    }

    public void ShootCriminal() {
        Criminal.Damage(Gun.getDamage());
    }

    public void AddMoney(uint val) {
        money = (uint)Mathf.Clamp(money + val, 0, uint.MaxValue); //avoiding uint overflow
        moneyText.text = money + "$";
    }

    public void SubMoney(uint val) {
        money = (uint)Mathf.Clamp(money - val, 0, uint.MaxValue); //avoiding uint overflow
        moneyText.text = money + "$";
    }
}
