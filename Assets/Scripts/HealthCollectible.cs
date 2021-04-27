using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Strawberry)
    {
        RubyController controller = Strawberry.GetComponent<RubyController>();
        if(controller != null)
        {
            if(controller.currentHealth < controller.maxHealth)
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
