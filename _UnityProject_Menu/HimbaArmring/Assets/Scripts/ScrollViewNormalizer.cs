using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollViewNormalizer : MonoBehaviour {

	public ScrollRect mScrollRect;
	public Scrollbar mScrollBar;

	public void Start() {
		mScrollRect.verticalNormalizedPosition = 1;
	}
}
