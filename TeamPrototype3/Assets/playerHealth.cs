using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public Text playerHP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.text = Player.hitPoints.ToString();
    }
}
