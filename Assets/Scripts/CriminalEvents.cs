using  UnityEngine.Events;

public class CriminalEvents {
    public static readonly UnityEvent<CriminalData> OnMouseIn = new UnityEvent<CriminalData>();
    public static readonly UnityEvent<CriminalData> OnMouseOut = new UnityEvent<CriminalData>();
    public static readonly UnityEvent<CriminalData> OnShot = new UnityEvent<CriminalData>();
    public static readonly UnityEvent<CriminalData> OnCriminalDeath = new UnityEvent<CriminalData>();
    public static readonly UnityEvent<CriminalData> OnCriminalSpawn = new UnityEvent<CriminalData>();
}
