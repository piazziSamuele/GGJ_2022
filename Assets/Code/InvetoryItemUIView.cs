using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryItemUIView : MonoBehaviour
{
    [SerializeField]
    private Image Item;
    [SerializeField]
    private Image ItemLifetime;
    [SerializeField]
    private float Lifetime;
    [SerializeField]
    private bool Assigned;

    // Start is called before the first frame update
    void Start()
    {
        Item.sprite = null;
    }

    public void AssignItemIcon(Sprite icon, float lifetime = 1)
    {
        Item.sprite = icon;
        Assigned = true;
        Lifetime = lifetime;
        ShowItems();
    }

    public void EmptySlot()
    {
        Assigned = false;
        Lifetime = 1f;
        ShowItems();
    }
    // Update is called once per frame
    void Update()
    {
        ShowItems();

        if (!Assigned)
        {
            ItemLifetime.fillAmount = Lifetime;
            if(Lifetime <= 0)
            {
                Assigned = false;
            }
        }

    }

    private void ShowItems()
    {
        Item.gameObject.SetActive(Assigned);
        ItemLifetime.gameObject.SetActive(Assigned);
    }
}
