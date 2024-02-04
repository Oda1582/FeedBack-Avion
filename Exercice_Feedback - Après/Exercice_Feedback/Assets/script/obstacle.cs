using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    int life;
    bool bActive = true;
    public GameObject DestroyEffect;
    public AudioManager AudioManager;
    public Color CrackColor;
    public float ColorRFloat, ColorGFloat, ColorBFloat, ColorAFloat;
    public Renderer Renderer;

    void Start()
    {
        life = 10;
        ColorAFloat = 0;
        Renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update() 
    {
        Material[] mats = Renderer.materials;
        Material CrackMaterial;
        CrackColor = new Color(ColorRFloat, ColorGFloat, ColorBFloat, ColorAFloat);
        CrackMaterial = mats[1];
        CrackMaterial.color = CrackColor;
        // ColorAFloat = (0 + dmg);
    }
 
    public void TakeDamage(int dmg,GameObject emmiter)
    {
        if(bActive)
        {
            life -= dmg;
            ChangeFloat(dmg);
            //Debug.Log("life : " + life);
            if (life <= 0)
            {
                this.GetComponent<Collider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                bActive = false;
                if (emmiter != null && emmiter.GetComponentInParent<Ship>()!=null) {
                emmiter.GetComponent<Ship>().ObstacleDesgtroyed();
                }
                
            if (DestroyEffect != null)
            {
                GameObject newDestroyEffect = Instantiate(DestroyEffect);
                newDestroyEffect.transform.position = this.transform.position;
                Destroy(newDestroyEffect.gameObject, 1);
            }

                AudioManager.PlayOneShot("Obstacle Death");
                //Destroy(newDestroyEffect.gameObject, 1);
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
    public void ChangeFloat(float dmg)
    {
        ColorAFloat = (ColorAFloat + (dmg/5));
    }
}
