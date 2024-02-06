using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_obstacle : MonoBehaviour
{
    int life;
    bool bActive = true;
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
 
    public void TakeDamage(int dmg,GameObject emmiter)
    {
        if(bActive)
        {
            life -= dmg;
            //Debug.Log("life : " + life);
            if (life <= 0)
            {
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                bActive = false;
                emmiter.GetComponent<old_Ship>().ObstacleDesgtroyed();
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
        
    }
    public void TakeDamage(int dmg)
    {
        if (bActive)
        {
            life -= dmg;
            //Debug.Log("life : " + life);
            if (life <= 0)
            {
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                bActive = false;
               
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }

    }
}
