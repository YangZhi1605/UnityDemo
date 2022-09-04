using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private int _damage = -1;

    private void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if(controller != null)
        {
            controller.ChangeHealth(_damage);
            Debug.Log($"此时和伤血区域发生碰撞的是{other}");
        }
    }
}
