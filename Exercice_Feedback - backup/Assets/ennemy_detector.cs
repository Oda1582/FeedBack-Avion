using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_detector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Ship>())
        {
            this.gameObject.GetComponentInParent<Ennemy>().ActiveAggro(other.gameObject.GetComponentInParent<Ship>().gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Ship>())
        {
            this.gameObject.GetComponentInParent<Ennemy>().ActiveAggro(other.gameObject.GetComponentInParent<Ship>().gameObject);
        }
    }
}
