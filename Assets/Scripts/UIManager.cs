using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager uiManager;
	private GunData gun;

	///<summary>
	/// might be smooth
	///</summary>
	public List<CriminalData> criminals;
	public Button actualGunButt;
	public Dictionary<string, CriminalData> killed = new Dictionary<string, CriminalData>();
	private InventoryManager inventoryManager;
	private GameObject inventoryObject;
	public GameObject inventoryPrefab;
	private CriminalData actualCriminal;

	public CriminalManager criminalManager;

	public TMP_Text moneyText;

	public uint money = 0;

	public List<GunData> gunList = new List<GunData>();


	public InventoryManager Inventory {get => inventoryManager;}

	private void Awake() {
		uiManager = this;
	}

	private void Start()
	{
		moneyText.text = money + "$";

		actualCriminal = Resources.Load<CriminalData>("Criminals/Shadow");

		actualGunButt.onClick.AddListener(OpenInventory);

		inventoryObject = Instantiate<GameObject>(inventoryPrefab, actualGunButt.transform);
		inventoryObject.SetActive(false);
		inventoryManager = InventoryManager.instance;
		SetGun(Resources.Load<GunData>("Guns/Slingshot"));

		eventHandler.OnCriminalDeath.AddListener(ChangeCriminal);
		eventHandler.OnCriminalSpawn.Invoke(actualCriminal);
	}

	public void ChangeCriminal(CriminalData prevCrim)
	{
		AddMoney(prevCrim.m_Bounty);
		if (!killed.ContainsKey(prevCrim.m_CriminalName) && prevCrim.m_CriminalName != "Shadow")
		{
			killed.Add(prevCrim.m_CriminalName, prevCrim);
		}
		actualCriminal = criminals[Random.Range(0, Mathf.Min(killed.Count + 1, criminals.Count))];
		eventHandler.OnCriminalSpawn.Invoke(actualCriminal);
	}

	public void ShootCriminal()
	{
		criminalManager.Damage(gun.getDamage());
	}

	public void AddMoney(uint val)
	{
		money = (uint)Mathf.Clamp(money + val, 0, uint.MaxValue); //avoiding uint overflow (it's posssible i swear)
		moneyText.text = money + "$";
	}
	/// <summary> WIP </summary>
	public bool SubMoney(uint val)
	{
		money = (uint)Mathf.Clamp(money - val, 0, uint.MaxValue); //avoiding uint overflow (it's posssible i swear)
		moneyText.text = money + "$";
		return true;
	}

	public void SetGun(GunData newGun)
	{
		if (!inventoryManager.guns.Contains(newGun))
		{
			inventoryManager.guns.Add(newGun);
		}
		actualGunButt.image.sprite = newGun.m_Sprite;
		gun = newGun;
	}
	public void OpenInventory()
	{
		if (inventoryObject.activeSelf)
		{
			return;
		}
		inventoryObject.SetActive(true);
		inventoryManager.ListAll();
		actualGunButt.onClick.RemoveListener(OpenInventory);
		actualGunButt.onClick.AddListener(CloseInventory);
	}

	public void CloseInventory()
	{
		if (!inventoryObject.activeSelf)
		{
			return;
		}
		inventoryObject.SetActive(false);
		actualGunButt.onClick.RemoveListener(CloseInventory);
		actualGunButt.onClick.AddListener(OpenInventory);
	}

}
