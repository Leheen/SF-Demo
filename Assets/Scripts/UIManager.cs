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
    private Text _dialogText;

    [SerializeField]
    private GameObject _inventoryCoins;
    [SerializeField]
    private GameObject _dialogBox;

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

    public void ShowDialog(string str)
    {
        _dialogBox.SetActive(true);
        _dialogText.text = str;
        StartCoroutine(HideDialog());
    }

    IEnumerator HideDialog()
    {
        yield return new WaitForSeconds(5f);
        _dialogBox.SetActive(false);
    }
}
