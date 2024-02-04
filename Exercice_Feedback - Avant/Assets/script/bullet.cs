using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed=125;
    int damage= 10;
    bool bActivebullet = false;
    bool bDestroyed = false;
    
    Rigidbody rb;
    GameObject Emmiter =null;
    
    void Start()
    {
        
    }
    public void ActiveBullet(Vector3 direction,GameObject emmiter,int dmg)
    {
        Emmiter = emmiter;
        damage = dmg;
        bActivebullet = true;
        this.transform.forward = direction;
        rb = this.GetComponent<Rigidbody>();
        if (bActivebullet)
        {
            rb.velocity = this.transform.forward * speed;
        }

    }
    public void ActiveChargedBullet(Vector3 direction, GameObject emmiter, int dmg, float spd,float size)
    {
        bActivebullet = true;
        Emmiter = emmiter;
        this.transform.forward = direction;
        damage = dmg;
        speed = 100 * spd;
        this.gameObject.transform.localScale = Vector3.one * size;


        rb = this.GetComponent<Rigidbody>();
        if (bActivebullet)
        {
            rb.velocity = this.transform.forward * speed;
        }

    }

    public void Destroybullet()
    {
        if(bActivebullet )
        {
            bDestroyed = true;
            bActivebullet = false;
            rb.velocity = Vector3.zero;
            this.GetComponent<MeshRenderer>().enabled = false;

            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }       

    }
    // Update is called once per frame
    void Update()
    {
        if(bActivebullet && bDestroyed ==false)
        {
            //if (Vector3.Distance(this.transform.position, Emmiter.transform.position) > 1000) { Destroybullet(); }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Ennemy>())
        {
            
            if (Emmiter != null && Emmiter.GetComponentInParent<Ship>()!=null)
            {
                Debug.Log("Emmiter" + Emmiter);
                collision.gameObject.GetComponentInParent<Ennemy>().TakeDamage(damage, Emmiter);
                Destroybullet();

            }
            else if (Emmiter != null && Emmiter.GetComponent<Ennemy>() != null)
            {
                // do nothing
                Debug.Log("Emmiter" + Emmiter.GetComponent<Ennemy>());
            }
            else
            {
                Debug.Log("Emmiter" );
                collision.gameObject.GetComponentInParent<Ennemy>().TakeDamage(damage);
                Destroybullet();
            }
            
        }
        else if (collision.gameObject.GetComponentInParent<obstacle>())
        {
            collision.gameObject.GetComponentInParent<obstacle>().TakeDamage(damage, Emmiter);
            Destroybullet();
        }
        else if (collision.gameObject.GetComponentInParent<Ship>())
        {
            collision.gameObject.GetComponentInParent<Ship>().TakeDamage(damage);
            Destroybullet();
        }
        else
        {
            Destroybullet();
        }

        

    }
}
