using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_ennemy_detector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<old_Ship>())
        {
            this.gameObject.GetComponentInParent<old_Ennemy>().ActiveAggro(other.gameObject.GetComponentInParent<old_Ship>().gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<old_Ship>())
        {
            this.gameObject.GetComponentInParent<old_Ennemy>().ActiveAggro(other.gameObject.GetComponentInParent<old_Ship>().gameObject);
        }
    }
}
