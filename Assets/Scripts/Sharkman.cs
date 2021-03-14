using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharkman : MonoBehaviour
{
    private bool _canInteract = true;

    private void Update()
    {
        _canInteract = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && _canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uiManager != null)
                    {
                        if (player.Coins > 0)
                        {
                            player.SubtractCoins(1);
                            uiManager.SubtractCoins(player.Coins);
                            AudioSource audio = GetComponent<AudioSource>();
                            audio.Play();
                            player.EnableWeapon();
                            _canInteract = false;
                        }
                        else
                        {
                            uiManager.ShowDialog("Get out of here!");
                        }
                    }
                }
            }
        }
    }
}
