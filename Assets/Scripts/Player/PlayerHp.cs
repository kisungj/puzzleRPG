using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    public PlayerHit[] playerHit;
    public GameObject failUI;

    public void PlayerAllHp()
    {
        if (playerHit[0].hp == 0 && playerHit[1].hp == 0 && playerHit[2].hp == 0 && playerHit[3].hp == 0 && playerHit[4].hp == 0)
        {
            failUI.SetActive(true);
        }
    }

}
