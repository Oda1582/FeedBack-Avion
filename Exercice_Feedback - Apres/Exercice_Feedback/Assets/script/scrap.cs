using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrap : MonoBehaviour
{
    public int ScrapsQuantity = 10;
    public AudioManager AudioManager;
    public float RandomRotate;
    public GameObject Cube;

    public void Start()
    {
        RandomRotate = Random.Range(0.5f,1.5f);
    }
    public void Update()
    {
        Cube.transform.Rotate(0, RandomRotate, 0);
    }
    public void DestroyScrap()
    {
        
        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(Cube.transform.root.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponentInParent<Ship>())
        {
            collision.gameObject.GetComponentInParent<Ship>().addScraps(ScrapsQuantity);
            // AudioManager.PlayOneShot("Scrap Sound");
            //Debug.Log("scrap added");
    
        }
        else if (collision.gameObject.GetComponent<Ship>())
        {
            collision.gameObject.GetComponent<Ship>().addScraps(ScrapsQuantity);
            // AudioManager.PlayOneShot("Scrap Sound");            
        }

        //Debug.Log("collision name : " + collision.gameObject.name);
        if(!collision.gameObject.GetComponent<bullet>())
        {
            DestroyScrap();
        }
 
           


    }
}
