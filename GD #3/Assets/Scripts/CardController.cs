using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer TheSpriteRenderer;
    public Sprite Front;
    public Sprite Back;
    public bool isFront=false;
    public int CardIndex;
    public bool found = false;
    void Start()
    {
        ShowBack();
    }

    // Update is called once per frame
    void Update()
    {
        if (found) gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("CardIndex: " + CardIndex);
        if (!isFront) ShowFront();
        else ShowBack();
    }
    public void ShowFront()
    {
        TheSpriteRenderer.sprite = Front;
        isFront = true;
    }
    public void ShowBack()
    {
        TheSpriteRenderer.sprite = Back;
        isFront = false;
    }
}
