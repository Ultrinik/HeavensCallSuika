using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    public RawImage img;
    public float x, y;

    void Update()
    {
        float maxHeight = GameManager.Instance.maxHeight;
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * maxHeight * Time.deltaTime, img.uvRect.size);

    }
}
