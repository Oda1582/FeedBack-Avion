using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    int life;
    int MaxLife;
    bool Aggro = false;
    GameObject Player;
    float NextShoot1Time = -10;
    public GameObject bullet;
    public weapon currentWeapon;
    public GameObject DestroyEffect;
    public EnnemyHealthBarScript healthBar;
    public GameObject UIHealthBar;
    public AudioManager AudioManager;
    public float DeactivateRange = 250;

    void Start()
    {
        MaxLife = 25;
        life = MaxLife;
        healthBar.SetMaxHealth(MaxLife);
        UIHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Aggro)
        {
            this.gameObject.transform.LookAt(Player.transform.GetChild(0).transform);
            Shoot();
            Vector3.Distance (this.transform.position,  Player.transform.position);
            //Debug.Log(Vector3.Distance (this.transform.position,  Player.transform.position));
            if (Vector3.Distance (this.transform.position,  Player.transform.position) >= DeactivateRange)
            {
                Aggro = false;
            }
        }
    }
    private void Shoot()
    {
        if (NextShoot1Time < Time.time)
        {
            GameObject newbullet = Instantiate(bullet);
            newbullet.transform.position = this.transform.position + this.transform.forward * 4;
            newbullet.GetComponent<bullet>().ActiveBullet(this.transform.forward, this.gameObject, currentWeapon.Damage);
            NextShoot1Time = Time.time + (1 / currentWeapon.ShootRate);

        }
    }
    public void TakeDamage(int dmg, GameObject emmiter)
    {
        life -= dmg;
        healthBar.SetHealth(life);
        UIHealthBar.SetActive(true);
        //Debug.Log("life : " + life);
        if(life<=0)
        {
            if (emmiter != null)
            {
                emmiter.GetComponent<Ship>().EnnemyDestroyed();
            }
            
            GameObject newDestroyEffect = Instantiate(DestroyEffect);
            newDestroyEffect.transform.position = this.transform.position;
            Destroy(newDestroyEffect.gameObject, 1);
            AudioManager.PlayOneShot("Ennemy Death");
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
    public void TakeDamage(int dmg)
    {
        life -= dmg;
        healthBar.SetHealth(life);
        //Debug.Log("life : " + life);
        if (life <= 0)
        {
            
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
    public void ActiveAggro(GameObject player)
    {
        Player = player;
        Aggro = true;
    }
    public void DesactiveAggro(GameObject player)
    {
        Player = null;
        Aggro = false;
    }
}
