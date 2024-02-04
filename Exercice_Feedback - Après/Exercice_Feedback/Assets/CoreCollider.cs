using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<wall>() || collision.gameObject.GetComponent<obstacle>())
        {
            this.gameObject.GetComponentInParent<Ship>().Death();

        }
    }

}
