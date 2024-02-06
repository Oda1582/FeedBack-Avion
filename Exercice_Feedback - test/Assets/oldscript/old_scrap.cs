using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_scrap : MonoBehaviour
{
    public int ScrapsQuantity = 10;
    public void DestroyScrap()
    {
        
        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponentInParent<old_Ship>())
        {
            collision.gameObject.GetComponentInParent<old_Ship>().addScraps(ScrapsQuantity);
    
        }
        else if (collision.gameObject.GetComponent<old_Ship>())
        {
            collision.gameObject.GetComponent<old_Ship>().addScraps(ScrapsQuantity);
            
        }

        //Debug.Log("collision name : " + collision.gameObject.name);
        if(!collision.gameObject.GetComponent<old_bullet>())
        {
            DestroyScrap();
        }
 
           


    }
}
