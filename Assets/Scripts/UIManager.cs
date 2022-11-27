using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public GunData gun;
    
    ///<summary>
    /// might be smooth
    ///</summary>
    public List<CriminalData> criminals;
    public Dictionary<string, CriminalData> killed = new Dictionary<string, CriminalData>();
    private CriminalData actualCriminal;

    public CriminalManager criminalManager;

    public TMP_Text moneyText;

    public uint money = 0;

    public List<GunData> gunList = new List<GunData>();

    private void Start() {
        moneyText.text = money + "$";
        actualCriminal = Resources.Load<CriminalData>("Criminals/Shadow");
        eventHandler.OnCriminalDeath.AddListener(ChangeCriminal);
        eventHandler.OnCriminalSpawn.Invoke(actualCriminal);
    }

    public void ChangeCriminal(CriminalData prevCrim) {
        AddMoney(prevCrim.m_Bounty);
        if (!killed.ContainsKey(prevCrim.m_CriminalName) && prevCrim.m_CriminalName != "Shadow") {
            killed.Add(prevCrim.m_CriminalName, prevCrim);
        }
        actualCriminal = criminals[Random.Range(0, Mathf.Min(killed.Count + 1, criminals.Count))];
        eventHandler.OnCriminalSpawn.Invoke(actualCriminal);
    }

    public void ShootCriminal() {
        criminalManager.Damage(gun.getDamage());
    }

    public void AddMoney(uint val) {
        money = (uint)Mathf.Clamp(money + val, 0, uint.MaxValue); //avoiding uint overflow (it's posssible i swear)
        moneyText.text = money + "$";
    }
    /// <summary> WIP </summary>
    public bool SubMoney(uint val) {
        money = (uint)Mathf.Clamp(money - val, 0, uint.MaxValue); //avoiding uint overflow (it's posssible i swear)
        moneyText.text = money + "$";
        return true;
    }


}
