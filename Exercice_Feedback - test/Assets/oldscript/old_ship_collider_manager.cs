using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_ship_collider_manager : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponentInParent<old_wall>() )
        {
            this.gameObject.GetComponentInParent<old_Ship>().hit("wall",collision.gameObject);
        }else if(collision.gameObject.GetComponent<old_wall>())
        {
            this.gameObject.GetComponent<old_Ship>().hit("wall", collision.gameObject);
        }

        if(collision.gameObject.GetComponentInParent<old_obstacle>() )
        {
            this.gameObject.GetComponent<old_Ship>().hit("obstacle", collision.gameObject);
            collision.gameObject.GetComponentInParent<old_obstacle>().TakeDamage(2000);
        }else if( collision.gameObject.GetComponent<old_obstacle>())
        {
            this.gameObject.GetComponent<old_Ship>().hit("obstacle", collision.gameObject);
            collision.gameObject.GetComponent<old_obstacle>().TakeDamage(2000);
        }

        if (collision.gameObject.GetComponentInParent<old_Ennemy>())
        {
            this.gameObject.GetComponent<old_Ship>().hit("ennemy", collision.gameObject);
            collision.gameObject.GetComponentInParent<old_Ennemy>().TakeDamage(150);
        }
        else if (collision.gameObject.GetComponent<old_Ennemy>())
        {
            this.gameObject.GetComponent<old_Ship>().hit("ennemy", collision.gameObject);
            collision.gameObject.GetComponent<old_Ennemy>().TakeDamage(150);
        }

    }
}
