using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_collider_manager : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponentInParent<wall>() )
        {
            this.gameObject.GetComponentInParent<Ship>().hit("wall",collision.gameObject);
        }else if(collision.gameObject.GetComponent<wall>())
        {
            this.gameObject.GetComponent<Ship>().hit("wall", collision.gameObject);
        }

        if(collision.gameObject.GetComponentInParent<obstacle>() )
        {
            this.gameObject.GetComponent<Ship>().hit("obstacle", collision.gameObject);
            collision.gameObject.GetComponentInParent<obstacle>().TakeDamage(2000);
        }else if( collision.gameObject.GetComponent<obstacle>())
        {
            this.gameObject.GetComponent<Ship>().hit("obstacle", collision.gameObject);
            collision.gameObject.GetComponent<obstacle>().TakeDamage(2000);
        }

        if (collision.gameObject.GetComponentInParent<Ennemy>())
        {
            this.gameObject.GetComponent<Ship>().hit("ennemy", collision.gameObject);
            collision.gameObject.GetComponentInParent<Ennemy>().TakeDamage(150);
        }
        else if (collision.gameObject.GetComponent<Ennemy>())
        {
            this.gameObject.GetComponent<Ship>().hit("ennemy", collision.gameObject);
            collision.gameObject.GetComponent<Ennemy>().TakeDamage(150);
        }

    }
}
