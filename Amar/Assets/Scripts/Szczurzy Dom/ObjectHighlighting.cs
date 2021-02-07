using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite nonHighlightedObject;
    public Sprite highlightedObject;
    
    void OnMouseOver()
    {
        ChangeSprite(highlightedObject);
    }
    void OnMouseExit()
    {
        ChangeSprite(nonHighlightedObject);
    }

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

}
