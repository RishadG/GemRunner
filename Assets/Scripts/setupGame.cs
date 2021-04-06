using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setupGame : MonoBehaviour
{
    public SkinnedMeshRenderer playerT;
    public Material[] playerMat; 
    private void Awake()
    {
        // set the player skin
        if (PlayerPrefs.HasKey("matChoice"))
        {
            int matChoice = PlayerPrefs.GetInt("matChoice");
            playerT.material = playerMat[matChoice];
        }

    }
}
