using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CriminalManager : MonoBehaviour {

    public Slider _healthSlider;
    public TMP_Text _nameText;
    public TMP_Text _healthText;

    ///<summary>
    /// I want to speak to your manager
    ///</summary>
    public UIManager manager;

	public CriminalData criminal;

    private short health;	

    private bool dead;

	// Start is called before the first frame update
	void Start() {
        dead = false;
        health = criminal.m_Health;
		_nameText.text = criminal.m_CriminalName;
		_healthText.text = health + "/" + health;
    }

    public bool IsDead() {
        return dead;
    }

    // Update is called once per frame
    void Update() {
        //time related damage here
        //smooth slider
        //animation
    }

    public void Die(Damage dmg) {
        dead = true;
		Debug.Log("Criminal '" + criminal.m_CriminalName + "' have died from " + dmg.name + ", You won " + criminal.m_Bounty + "$.");
        manager.AddMoney(criminal.m_Bounty);
    }

    public void Hurt(Damage damage) {
		string s = "-" + damage.dmg;
		Color c = Color.red;
    }

    public void Heal(Damage damage) {
		string s = "+" + damage.dmg;
		Color c = Color.green;
    }

    public short Health { get => health; set => health = value; }

    public void Damage(Damage dmg) {
        if (Health - dmg.dmg > criminal.m_Health) {
            return;
        }

        Health -= dmg.dmg;

        

        if (dmg.dmg < 0) {
            Heal(dmg);
        } else {
            Hurt(dmg);
        }
		_healthText.text = health + "/" + health;
        _healthSlider.value = (float)health / (float)criminal.m_Health;
        if (Health <= 0) {
            Die(dmg);
        }
    }
     
}
