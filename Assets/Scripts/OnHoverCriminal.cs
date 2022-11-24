using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class OnHoverCriminal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    private const CursorMode cursorMode = CursorMode.Auto;
    private Texture2D texture2D;
    private Vector2 hotPoint;
    private Image img;
    // Start is called before the first frame update
    void Start() {
        texture2D = Resources.Load<Texture2D>("shootCursor");
        hotPoint = new Vector2(texture2D.width / 2, texture2D.height / 2);

        img = GetComponent<Image>();
        eventHandler.OnCriminalSpawn.AddListener(changeSprite);
    }

	public void OnPointerEnter(PointerEventData eventData) {
		Cursor.SetCursor(texture2D, hotPoint, cursorMode);
	}

	public void OnPointerExit(PointerEventData eventData) {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
		
	}

    private void changeSprite(CriminalData data) {
        img.sprite = data.m_Sprite;
    }

    
}
