using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TooltipTrigger))]
public class ItemShop : MonoBehaviour {
    public GunData gun;

    public UIManager manager;
    public Image img;
    public TMP_Text headerField;
    public TMP_Text priceField;

    private TooltipTrigger tooltip;
    private Button button;

    public bool bought = false;

    private void Awake() {
        tooltip = GetComponent<TooltipTrigger>();
        button = GetComponent<Button>();
    }
    public void SetGun(GunData gun) {
        this.gun = gun;
        tooltip.header = gun.m_GunName;
        img.sprite = gun.m_Sprite;
        headerField.SetText(gun.m_GunName);
        priceField.SetText(gun.m_GunPrice.ToString() + "$");
    }

    public void Buy() {
        manager.SubMoney(gun.m_GunPrice);
        manager.gun = gun;
        bought = true;
    }

    public bool Buyable() {
        return manager.money >= gun.m_GunPrice && !bought;
    }

    private void Update() {
        button.interactable = Buyable();
        if (Buyable()) {
            tooltip.content = "click to buy for " + gun.m_GunPrice + "$";
        } else {
            if (bought) {
                tooltip.content = "You've bought this gun.";
            } else { //assume that if not buyable and bought => not enough money
                tooltip.content = "Not Enough Money :c";
            }

        }
    }
}
