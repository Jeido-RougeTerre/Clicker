using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;

public class OnHoverCriminal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public CriminalManager manager;

    private const CursorMode cursorMode = CursorMode.Auto;
    private Texture2D texture2D;
    private Vector2 hotPoint;

    private bool mouseOver = false;
    // Start is called before the first frame update
    void Start() {
        texture2D = Resources.Load<Texture2D>("shootCursor");
        hotPoint = new Vector2(texture2D.width / 2, texture2D.height / 2);

        CriminalEvents.OnMouseIn.AddListener(SetShoot);
        CriminalEvents.OnMouseOut.AddListener(UnsetShoot);
        
    }

    private void OnMouseEnter() {
        if (mouseOver) {
            return;
        }

        CriminalEvents.OnMouseIn.Invoke(manager.criminal);
        mouseOver = true;

    }

    private void OnMouseLeave() {
        if (!mouseOver) {
            return;
        }

        CriminalEvents.OnMouseOut.Invoke(manager.criminal);
        mouseOver = false;
    }

    private void SetShoot(CriminalData _d) {
        Cursor.SetCursor(texture2D, hotPoint, cursorMode);
    }

    private void UnsetShoot(CriminalData _d) {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

	public void OnPointerEnter(PointerEventData eventData) {
		CriminalEvents.OnMouseIn.Invoke(manager.criminal);
	}

	public void OnPointerExit(PointerEventData eventData) {
		CriminalEvents.OnMouseOut.Invoke(manager.criminal);
		
	}
}
