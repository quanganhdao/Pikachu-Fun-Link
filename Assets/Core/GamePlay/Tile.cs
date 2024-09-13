using System.Collections;
using System.Collections.Generic;
using OutlineFx;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ItemSO tileSO;
    [SerializeField] private Animator animator;
    [SerializeField] private Outline outline;
    private int posX;
    private int posY;
    private bool isSetUp = false;

    public void SetPosInGrid(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public void SetUp(int x, int y, ItemSO itemso)
    {
        SetPosInGrid(x, y);
        SetItem(itemso);
    }
    public bool IsItemSetUp()
    {
        return isSetUp;
    }
    private bool isPicked;
    private void Awake()
    {
        if (sr == null)
        {
            sr.sprite = tileSO.sprite;
        }
    }
    private void Start()
    {
        Toggle();
    }

    public void SetItem(ItemSO itemSO)
    {
        this.tileSO = itemSO;
        sr.sprite = tileSO.sprite;
        isSetUp = true;

    }

    private void OnValidate()
    {
        if (tileSO != null)
        {
            sr.sprite = tileSO.sprite;
        }
    }
    public void Pick()
    {
        animator.SetTrigger("Spring");
        isPicked = true;
        Toggle();
    }

    public void UnPick()
    {
        isPicked = false;
        Toggle();

    }

    public void ToggleOutline()
    {
        outline.enabled = isPicked ? true : false;
    }
    public void ToggleSprite()
    {
        sr.sprite = isPicked ? tileSO.pickSprite : tileSO.sprite;
    }

    public void Toggle()
    {
        ToggleOutline();
        ToggleSprite();
    }

    private void OnMouseDown()
    {
        Toggle();
    }

}
