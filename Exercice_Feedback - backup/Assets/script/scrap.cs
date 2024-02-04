using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrap : MonoBehaviour
{
    public int ScrapsQuantity = 10;
    public void DestroyScrap()
    {
        
        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponentInParent<Ship>())
        {
            collision.gameObject.GetComponentInParent<Ship>().addScraps(ScrapsQuantity);
    
        }
        else if (collision.gameObject.GetComponent<Ship>())
        {
            collision.gameObject.GetComponent<Ship>().addScraps(ScrapsQuantity);
            
        }

        //Debug.Log("collision name : " + collision.gameObject.name);
        if(!collision.gameObject.GetComponent<bullet>())
        {
            DestroyScrap();
        }
 
           


    }
}
