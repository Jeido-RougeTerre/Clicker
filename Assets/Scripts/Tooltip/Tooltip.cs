using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class Tooltip : MonoBehaviour {

	public TextMeshProUGUI headerField;
	public TextMeshProUGUI contentField;

	public LayoutElement layoutElement;

	///<summary>
	/// the size in texels (px/units) of the text before wraping it to a new line. Default = <c>200</c>.
	///</summary>
	public byte charWarpLimit = 200;

	private RectTransform rectTransform;

	private void Awake() {
		rectTransform = GetComponent<RectTransform>();
	}

	private void Update() {
		Vector2 offset = new Vector2();
		Vector2 pos = Input.mousePosition;

		offset.x = -(Screen.width / 2f);
		offset.y = Screen.height;

		if (Application.isEditor) {
			layoutElement.enabled = Mathf.Max(headerField.preferredWidth, contentField.preferredWidth) >= layoutElement.preferredWidth;
		}

		float pX = (pos.x + offset.x) / Screen.width;
		float pY = (pos.y + offset.y) / Screen.height;


		rectTransform.pivot = new Vector2(pX, pY);

		transform.position = pos;
	}
	///<summary> Change the content of the Tooltip.</summary>
	/// <param name="content">the new content of the Tooltip.</param>
	/// <param name="header">the new header of the Tooltip. If <c>Null</c> or <c>Empty</c> the header object will be <c>Disabled</c>.</param>
	public void SetText(string content, string header = "") {
		if (string.IsNullOrEmpty(header)) {
			headerField.gameObject.SetActive(false);
		} else {
			headerField.gameObject.SetActive(true);
			headerField.SetText(header);
		}

		contentField.SetText(content);
		layoutElement.enabled = Mathf.Max(headerField.preferredWidth, contentField.preferredWidth) >= layoutElement.preferredWidth;
	}


}