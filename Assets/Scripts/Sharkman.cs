using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharkman : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    Debug.Log(player.Coins);
                    if (player.Coins > 0)
                    {
                        player.SubtractCoins(1);
                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (uiManager != null)
                        {
                            uiManager.SubtractCoins(player.Coins);
                        }

                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapon();
                    }
                    else
                    {
                        Debug.Log("Get out of here!");
                    }
                }
            }
        }
    }
}
