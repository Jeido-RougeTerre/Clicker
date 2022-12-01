using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;
    public UIManager manager;
    public List<GunData> guns = new List<GunData>();
    public GunSelect[] inventoryGuns;
    // Start is called before the first frame update

    public Transform inventoryContent;
    public GameObject inventoryObject;
    private void Awake() {
        instance = this;
    }

    public void Add(GunData gun) {
        guns.Add(gun);
    }

    //TODO: remove ? 

    public void ListAll() {

        //clear TODO: find a better way to avoid item multiplication on opening inventory
        foreach(Transform tr in inventoryContent) {
            Destroy(tr.gameObject);
        }

        foreach (GunData gun in guns) {
            GameObject obj = Instantiate(inventoryObject, inventoryContent);
            TMP_Text gunName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            Button gunButt = obj.GetComponent<Button>();

            gunName.SetText(gun.m_GunName);
            gunButt.image.sprite = gun.m_Sprite;
        }

        InitInventoryItems();
    }

    public void InitInventoryItems() {
        inventoryGuns = inventoryContent.GetComponentsInChildren<GunSelect>();

        for (int i = 0; i < guns.Count; i++) {
            inventoryGuns[i].AddGun(guns[i]);
        }
    }
}
