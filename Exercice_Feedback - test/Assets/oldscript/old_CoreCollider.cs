using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_CoreCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<old_wall>() || collision.gameObject.GetComponent<old_obstacle>())
        {
            this.gameObject.GetComponentInParent<old_Ship>().Death();

        }
    }

}
