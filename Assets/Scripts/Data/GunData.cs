using UnityEngine;

[CreateAssetMenu]
public class GunData : ScriptableObject {
    public string m_GunName = "'GUN'";

    [Range(1, byte.MaxValue)]
    public byte m_MagazineSize = 1;
    public uint m_MagazinePrice = 0;
    public uint m_GunPrice = 0;
    public EGunType m_Type = EGunType.Pistol;
    public Sprite m_Sprite;
    [SerializeField] [Range(0, short.MaxValue)] private short m_Damage = 0;

    public Damage getDamage() {
        EDmgType type;
        switch(m_Type) {
            case EGunType.Pistol:
            type = EDmgType.GunPistol;
            break;
            case EGunType.Riffle:
            type = EDmgType.GunRiffle;
            break;
            case EGunType.BFG:
            type = EDmgType.GunBFG;
            break;
            case EGunType.Slingshot:
            type = EDmgType.GunSlingshot;
            break;
            case EGunType.Bow:
            type = EDmgType.GunBow;
            break;
            case EGunType.Magic:
            type = EDmgType.Magic;
            break;
            default:
            type = EDmgType.Magic;
            break;
        }

        return new Damage(m_Damage, type, m_GunName);
    }
}

public enum EGunType {
    Pistol,
    Riffle,
    BFG,
    Slingshot,
    Bow,
    Magic
}

public class Damage {
    public short dmg;
    public string name;
    public EDmgType type;

    public Damage(short dmg, EDmgType type, string name) {
        this.dmg = dmg;
        this.type = type;
        this.name = name;
    }

    public Damage(short dmg, EDmgType type) {
        this.dmg = dmg;
        this.type = type;
        switch(type) {
            case EDmgType.Bleed:
                this.name = "Bleeding";
                break;
            case EDmgType.Fire:
                this.name = "Burning";
                break;
            case EDmgType.Poison:
                this.name = "Poison";
                break;
            case EDmgType.Magic:
                this.name = "Magic";
                break;
            default :
                this.name = "Magic";
                break;
        }
    }

    public Damage(short dmg) : this(dmg, EDmgType.Magic, "Magic") {}

    public Damage() : this(1) {}
}

public enum EDmgType {
    GunPistol,
    GunRiffle,
    GunBFG,
    GunSlingshot,
    GunBow,
    Bleed,
    Fire,
    Poison,
    Magic
}
