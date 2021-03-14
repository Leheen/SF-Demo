using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioCoinPickup;
    [SerializeField]
    private int _amount = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AddCoins(_amount);
                AudioSource.PlayClipAtPoint(_audioCoinPickup, transform.position, 1f);
                UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                if (uiManager != null)
                {
                    uiManager.CollectCoins(player.Coins);
                }

                Destroy(this.gameObject);
            }
        }
    }
}
