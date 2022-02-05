using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="shopMenu", menuName="ShopItems/ShopItem", order=1)]
public class ShopItem : ScriptableObject
{
    public string title;
    public string description;
    public Sprite itemIcon;

    public int itemPrice;
    public int addAmount;
    public int removeAmount;

    
}
