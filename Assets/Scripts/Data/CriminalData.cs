using UnityEngine;

[CreateAssetMenu]
public class CriminalData : ScriptableObject {
    public string m_CriminalName;
    public short m_Health;
    public uint m_Bounty;
    public Sprite m_Portrait;

    public Sprite m_Sprite;
}
