using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int totalHealth = 3;
    public GameObject full_healthBar;
    public GameObject medium_healthBar;

    public GameObject low_healthBar;
  
    void OnMouseDown()
    {
        Debug.Log("is clicked");

        switch (totalHealth)
        {
            case 3:
                Debug.Log("medium");
                medium_healthBar.SetActive(true);
                break;
            
            case 2:
                Debug.Log("low");
                medium_healthBar.SetActive(false);
                low_healthBar.SetActive(true);
                break;

            case 1:
                Debug.Log("high");
                low_healthBar.SetActive(false);
                full_healthBar.SetActive(true);
                break;
        }

        totalHealth -= 1;
    }
}
