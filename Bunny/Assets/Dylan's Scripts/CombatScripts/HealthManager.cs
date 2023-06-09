using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    private float healthAmount;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount = transform.parent.gameObject.GetComponent<EnemyCombat>().health;
        transform.rotation = Quaternion.identity;
    }

    public void TakeDamage(float damage) {
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Heal(float healingAmount) {
        // healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }
}
