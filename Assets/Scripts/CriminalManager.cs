using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CriminalManager : MonoBehaviour {

    public Slider _healthSlider;
    public TMP_Text _nameText;
    public TMP_Text _healthText;

	public CriminalData criminal;

    private short health;	

    private bool dead;

	// Start is called before the first frame update
	void Start() {
        eventHandler.OnCriminalSpawn.AddListener(SetCriminal);
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
        eventHandler.OnCriminalDeath.Invoke(criminal);
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
		_healthText.text = health + "/" + criminal.m_Health;
        _healthSlider.value = (float)health / (float)criminal.m_Health;
        if (Health <= 0) {
            Die(dmg);
        }
    }

    public void SetCriminal(CriminalData data) {
        criminal = data;
        dead = false;
        health = data.m_Health;
		_nameText.text = data.m_CriminalName;
		_healthText.text = health + "/" + data.m_Health;
        _healthSlider.value = (float)health / (float)data.m_Health;
    }
     
}
