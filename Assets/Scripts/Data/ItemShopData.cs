using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopData : MonoBehaviour {

    public static List<GunData> gunBought = new List<GunData>();
    public GunData m_Gun;

    public UIManager manager;

    public static void Buy() {
        if (Buyable()) {
        manager.SubMoney(m_Gun.m_GunPrice);
        gunBought.Add(m_Gun);
        }
    }

    public bool Buyable() {
        return manager.money >= m_Gun.m_GunPrice && !gunBought.Contains(m_Gun);
    }
}
