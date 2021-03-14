using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _coinsText;

    [SerializeField]
    private GameObject _inventoryCoins;

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void CollectCoins(int coins)
    {
        _inventoryCoins.SetActive(true);
        _coinsText.text = coins.ToString();
    }

    public void SubtractCoins(int coins)
    {
        _coinsText.text = coins.ToString();
        if (coins >= 0)
        {
            _inventoryCoins.SetActive(false);
        }
    }
}
