using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    int life;
    bool Aggro = false;
    GameObject Player;
    float NextShoot1Time = -10;
    public GameObject bullet;
    public weapon currentWeapon;
    void Start()
    {
        life = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if(Aggro)
        {
            this.gameObject.transform.LookAt(Player.transform.GetChild(0).transform);
            Shoot();
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
        //Debug.Log("life : " + life);
        if(life<=0)
        {
            emmiter.GetComponent<Ship>().EnnemyDestroyed();
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
    public void TakeDamage(int dmg)
    {
        life -= dmg;
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
