using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventHandler {
    public static UnityEvent<CriminalData> OnCriminalDeath = new UnityEvent<CriminalData>();
    public static UnityEvent<CriminalData> OnCriminalSpawn = new UnityEvent<CriminalData>();
}
