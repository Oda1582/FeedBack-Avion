using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Ship : MonoBehaviour
{
    int countEnnemy = 0;
    int CountObstacle = 0;
    int Life;
    float Energy;
    float EnergyRegen;
    int Shield;
    int scraps;
    scrapsCombo CurrentScrapcombo = scrapsCombo.Médiocre;
    float TimeLastScrap;
    float ScrapComboTime = 1f;
    bool bLoosingCombo = false;
    float TimeLoose = 3;
    float LastTimeLoose=0;
    enum scrapsCombo
    {
        Médiocre=1, Satisfaisant=2, Surprenant=3, Impressionant=4, Excellent=5, Incroyable=6, Inconcevable=7, Extraordinaire=8, Abracadabrant =9, Excessif =10
    }

    Vector3 Direction;
    float CurrentSpeed =0;
    float ForwardSpeed = 0;
    float CurrentForwardSpeed=10;
    float MinforwardSpeed = 10;
    float MaxforwardSpeed = 60;


    float AccelerateValue;
    float DecelerateValue;
    bool bAccelerate;
    bool bDecelerate;

    float UpDownRotationSpeed = 80;
    float RightLeftRotationSpeed = 80;

    float UpDownShipAngle = 40;
    float RightLeftShipAngle = 35;


    Vector2 InputMove1;
    Vector2 InputMove2;

    float RollSpeed;
    float Roll;

    Vector3 InitPosCam;

    bool bShoot1 =false;
    float NextShoot1Time = -10 ;
    float CDShoot1 = 0.5f;
    bool bShoot2 = false;

    bool bChargingWeapon = false;
    float currentCharge = 0;
    bool MaxCharge = false;

    weapon currentWeapon1;
    int indexcrtweapon = 0;
    //weapon currentWeapon2;

    public List<weapon> shipweapons;// = new List<weapon>();


    Rigidbody rbShip;
    public GameObject ship;
    public Camera cam;
    public GameObject bullet;
    public GameObject Spawn;

    // Start is called before the first frame update
    void Start()
    {
        InitPosCam = cam.gameObject.transform.localPosition;
        rbShip = this.GetComponent<Rigidbody>();
        AccelerateValue = MaxforwardSpeed /0.25f;
        DecelerateValue = MaxforwardSpeed /0.25f;
        RollSpeed = 360 / 2;
        Life = 100;
        Energy = 100;
        Shield = 100;
        scraps = 0;
        rbShip.velocity = Vector3.zero;
        InitStatistique();
        CurrentForwardSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(currentWeapon1.type==WeaponType.Classic)
        {
            //currentWeapon1.PrintInfo();
            Shoot();

        }else if(currentWeapon1.type == WeaponType.Charged && bChargingWeapon )
        {
            currentCharge += Time.deltaTime;
            if(currentCharge>currentWeapon1.ChargeTime)
            {
                currentCharge = currentWeapon1.ChargeTime;
                MaxCharge = true;
            }
        }

        Energy += EnergyRegen * Time.deltaTime;

        //scrap
        if (Time.time >= TimeLastScrap + 3 && bLoosingCombo == false)
        {
            bLoosingCombo = true;
           
        }
       
        if(bLoosingCombo && LastTimeLoose+TimeLoose<Time.time)
        {
            
            CurrentScrapcombo--;
            LastTimeLoose = Time.time;

            if (CurrentScrapcombo < 0)
            {
                CurrentScrapcombo = 0;
            }
        }
    }

    public void onAccelerate(InputAction.CallbackContext Value)
    {
        if (Value.ReadValue<float>() > 0f)
        {
            //Debug.Log("accelerate " + Value.ReadValue<float>());
            bAccelerate = true;
        }
        else if (Value.ReadValue<float>() == 0f)
        {
            // Debug.Log("stopaccelerate");
            bAccelerate = false;
        }

    }
    public void onDecelerate(InputAction.CallbackContext Value)
    {
        if (Value.ReadValue<float>() > 0f)
        {
            //Debug.Log("accelerate " + Value.ReadValue<float>());
            bDecelerate = true;
        }
        else if (Value.ReadValue<float>() == 0f)
        {
            // Debug.Log("stopaccelerate");
            bDecelerate = false;
        }
    }
    public void onRoll(InputAction.CallbackContext Value)
    {
        Roll = Value.ReadValue<float>();
    }
    public void onShoot1(InputAction.CallbackContext Value)
    {
        if (Value.ReadValue<float>() > 0f)
        {
            bShoot1 = true;
            if(currentWeapon1.type == WeaponType.Charged)
            {
                bChargingWeapon = true;
            }
        }
        else if (Value.ReadValue<float>() == 0f)
        {
            bShoot1 = false;
            if (currentWeapon1.type == WeaponType.Charged)
            {
                bChargingWeapon = false;
                ChargeShoot();
            }

        }
        //Debug.LogError("Shoot 1 : " + bShoot1);
    }
    public void onShoot2(InputAction.CallbackContext Value)
    {
        if (Value.ReadValue<float>() > 0f)
        {

            bShoot2 = true;
        }
        else if (Value.ReadValue<float>() == 0f)
        {

            bShoot2 = false;
        }
    }
    public void onChangeWeapon(InputAction.CallbackContext Value)
    {
       // Debug.Log("" + Value.ReadValue<float>());
       if(Value.started)
        {
            ChangeWeapon(Value.ReadValue<float>());
        }
      
    }
    private void ChangeWeapon(float nextweapon)
    {
        Debug.Log("Index : " + indexcrtweapon);
        indexcrtweapon += (int)nextweapon;

        if(indexcrtweapon<0)
        {
            indexcrtweapon = shipweapons.Count-1;
        }
        else if(indexcrtweapon>shipweapons.Count-1)
        {
            indexcrtweapon = 0;
        }
        Debug.Log("Index : " + indexcrtweapon);

        currentWeapon1 = shipweapons[indexcrtweapon];


       // currentWeapon1.PrintInfo();

       
    }
    public void onMove1(InputAction.CallbackContext Value)
    {
        Vector2 Mvt1 = Value.ReadValue<Vector2>();
        InputMove1 = Mvt1;
        //Debug.Log("Mvt1 : " + InputMove1);

    }
    public void onMove2(InputAction.CallbackContext Value)
    {
        Vector2 Mvt2 = Value.ReadValue<Vector2>();
        InputMove2 = Mvt2;
    }
    private void Movement()
    {
        if (bDecelerate)
        {
            ForwardSpeed -= DecelerateValue * Time.fixedDeltaTime;
            if (ForwardSpeed < MinforwardSpeed)
            {
                ForwardSpeed = MinforwardSpeed;
            }
        }
        else if (bAccelerate)
        {
            ForwardSpeed += AccelerateValue * Time.fixedDeltaTime;
            if (ForwardSpeed > MaxforwardSpeed)
            {
                ForwardSpeed = MaxforwardSpeed;
            }
        }
        CurrentForwardSpeed = ForwardSpeed;

        
        // Debug.Log("ForwardSpeed : " + CurrentForwardSpeed);
        //rotation manager
        float vertical = InputMove1.y;
        float Horizontal = InputMove1.x;
        float roll = Roll;

        Vector3 rot = new Vector3(vertical * UpDownRotationSpeed, Horizontal * RightLeftRotationSpeed, Roll * RollSpeed);
        this.gameObject.transform.Rotate(rot * Time.fixedDeltaTime);

        // ship rotation
        Vector3 shipRotation = new Vector3(vertical * UpDownShipAngle, Horizontal * RightLeftShipAngle, 0);
        ship.gameObject.transform.localRotation = Quaternion.Lerp(ship.gameObject.transform.localRotation, Quaternion.Euler(shipRotation), 10 * Time.fixedDeltaTime);

        //camera move / rotation
        Vector3 Endposcam = InitPosCam - new Vector3(0, 0, 5);
        cam.gameObject.transform.localPosition = Vector3.Lerp(cam.gameObject.transform.localPosition, Endposcam, 0.5f * Time.fixedTime);

        Vector3 CamRotation = new Vector3(vertical * UpDownShipAngle / 2, Horizontal * RightLeftShipAngle / 2, 0);

        cam.gameObject.transform.localRotation = Quaternion.Lerp(cam.gameObject.transform.localRotation, Quaternion.Euler(CamRotation), 10 * Time.fixedDeltaTime);


        // Vector3 dirCompensation = QOLMove();

        Direction = this.transform.forward;// + dirCompensation * 0.5f;

        this.GetComponent<Rigidbody>().velocity = Direction * CurrentForwardSpeed;
    }
    public void hit(string type,GameObject cObjcet)
    {
        switch (type)
        {
            case "wall":
                Death();
                break;
            case "obstacle":
                TakeDamage(25);
                this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.5f;
                break;
            case "ennemy":
                Death();
               // this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.5f;
                break;
        }
    }
    private void Shoot()
    {
        if(bShoot1 && NextShoot1Time < Time.time && Energy>=currentWeapon1.energyconsumption)
        {
            GameObject newbullet = Instantiate(bullet);
            newbullet.transform.position = ship.transform.position + ship.transform.forward*7 ;
            newbullet.GetComponent<bullet>().ActiveBullet(this.transform.forward,this.gameObject,currentWeapon1.Damage);
            NextShoot1Time = Time.time + (1/currentWeapon1.ShootRate);
            Energy -= currentWeapon1.energyconsumption;
        }
    }
    private void ChargeShoot()
    {
        float pourcentcharge = currentCharge/currentWeapon1.ChargeTime;
        if(Energy >= currentWeapon1.energyconsumption*pourcentcharge )
        {
            GameObject newbullet = Instantiate(bullet);
            newbullet.transform.position = ship.transform.position + (ship.transform.forward * 7) * pourcentcharge * currentWeapon1.ChargeSizeMultiplier ;
            newbullet.GetComponent<bullet>().ActiveChargedBullet(this.transform.forward, this.gameObject, Mathf.RoundToInt(currentWeapon1.Damage * pourcentcharge), Mathf.RoundToInt(currentWeapon1.CHargeSpeedMultiplier * pourcentcharge), Mathf.RoundToInt(currentWeapon1.ChargeSizeMultiplier * pourcentcharge)); ;

            Energy -= currentWeapon1.energyconsumption*pourcentcharge;
        }

        currentCharge = 0;
        MaxCharge = false;
        bChargingWeapon = false;

    }
    public void TakeDamage(int dmg)
    {
        if(Shield>0)
        {
            Shield -= dmg;
            dmg = 0;
        }

        if(Shield<0)
        {
            dmg = -Shield;
            Shield = 0;
        }

        Life -= dmg;
  
        if(Life <= 0 )
        {
            Death();
        }
       
    }
    public void Death()
    {
        InitStatistique();
        this.gameObject.transform.position = Spawn.transform.position;
        this.gameObject.transform.forward = Spawn.transform.forward;
        

    }
    private void InitStatistique()
    {
        AccelerateValue = MaxforwardSpeed / 2;
        DecelerateValue = MaxforwardSpeed / 2;
        RollSpeed = 360 / 2;
        Life = 100;
        Energy = 100;
        EnergyRegen = 20;
        Shield = 100;
        scraps = 0;
        rbShip.velocity = Vector3.zero;
        currentWeapon1 = shipweapons[0];
         countEnnemy = 0;
         CountObstacle = 0;
    }
    public void addScraps(int nbscraps)
    {
        bLoosingCombo = false;
        scraps += nbscraps*(int)CurrentScrapcombo;
        Energy += nbscraps * (int)CurrentScrapcombo;
        Shield += nbscraps * (int)CurrentScrapcombo;
        if (Time.time<TimeLastScrap+ScrapComboTime)
        {
            CurrentScrapcombo++;
        }

        
        //Debug.Log("Scraps combo : " + CurrentScrapcombo);
       // Debug.Log("Scrap score : " + scraps);

        TimeLastScrap = Time.time;
    }
    public void EnnemyDestroyed()
    {
        countEnnemy++;

    }
    public void ObstacleDesgtroyed()
    {
        CountObstacle++;

    }
}
public enum WeaponType
{
    Classic, Charged
}
[Serializable]
public class weapon 
{
    public string Name;
    public int Damage;
    public float ShootRate;
    public int energyconsumption;
    public WeaponType type;
    public float ChargeTime;
    public float ChargeSizeMultiplier;
    public float CHargeSpeedMultiplier;
    

    
    public void PrintInfo()
    {
        Debug.Log("Name : "+Name);
        Debug.Log("Damage : " + Damage);
        Debug.Log("ShootRate : " + ShootRate);
        Debug.Log("energyconsumption : " + energyconsumption);
        Debug.Log("type : " + type);
        Debug.Log("ChargeTime : " + ChargeTime);


    }
    public weapon(string name, int dmg, float shootrate)
    {
        Damage = dmg;
        ShootRate = shootrate;
       
    }
    
}
