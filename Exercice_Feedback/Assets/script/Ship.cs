using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public enum scrapsCombo
    {
        Mediocre=1, Satisfaisant=2, Surprenant=3, Impressionant=4, Excellent=5, Incroyable=6, Inconcevable=7, Extraordinaire=8, Abracadabrant =9, Excessif =10
    }
    public int countEnnemy = 0;
    public int CountObstacle = 0;
    int Life;
    int MaxLife;
    public float Energy;
    public float EnergyGain;
    float MaxEnergy;
    float EnergyRegen;
    public int Shield;
    public int ShieldGain;
    public int MaxShield;
    public int scraps;
    public int scrapsGain;
    public scrapsCombo CurrentScrapcombo = scrapsCombo.Mediocre;
    float TimeLastScrap;
    float ScrapComboTime = 3f;
    bool bLoosingCombo = false;
    public float TimeLoose = 3f;
    float LastTimeLoose=0;
    bool bIsShooting;
    float TimeShootingHaptic = 0.1f;
    float LastTimeShootingHaptic;
    bool bIsHit;
    float TimeHitHaptic = 0.5f;
    float LastTimeHitHaptic;
    bool bIsDead;
    float TimeDeathHaptic = 1f;
    float LastTimeDeathHaptic;

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
    public GameObject bullet, bullet2;
    public GameObject Spawn;
    public ParticleSystem MuzzleFlash, HitPlayerEffectShield, HitPlayerEffectHealth;

    public HealthBarScript healthBar;
    public AudioManager AudioManager;
    public UIScript UIRef;
    public Color32 ShieldColor, HexColor;
    public float ColorRFloat1, ColorGFloat1, ColorBFloat1, ColorAFloat1;
    public float ColorRFloat2, ColorGFloat2, ColorBFloat2, ColorAFloat2;
    public Renderer Renderer;
    public int Localdmg;
    public GameObject ShieldGO;
    
    // Start is called before the first frame update
    void Start()
    {
        InitPosCam = cam.gameObject.transform.localPosition;
        rbShip = this.GetComponent<Rigidbody>();
        AccelerateValue = MaxforwardSpeed /0.25f;
        DecelerateValue = MaxforwardSpeed /0.25f;
        RollSpeed = 360 / 2;
        MaxLife = 100;
        Life = MaxLife;
        MaxEnergy = 100;
        Energy = MaxEnergy;
        MaxShield = 100;
        Shield = MaxShield;
        scraps = 0;
        rbShip.velocity = Vector3.zero;
        InitStatistique();
        CurrentForwardSpeed = 10;
        healthBar.SetMaxHealth(MaxLife);
        healthBar.SetMaxShield(MaxShield);
        healthBar.SetMaxEnergy(MaxEnergy);
        ShieldUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetEnergy(Energy);
        Movement();
        // Debug.Log("Time.time : " + Time.time);
        // Debug.Log("TimeLastScrap : " + TimeLastScrap);
        // Debug.Log("TimeLastScrap + 3 : " + TimeLastScrap + 3);
        // Debug.Log("LastTimeLoose : " + LastTimeLoose);
        // Debug.Log("TimeLoose : " + TimeLoose);
        // Debug.Log("bLoosingCombo : " + bLoosingCombo);
        // Debug.Log("ScrapComboTime : " + ScrapComboTime);
        // Debug.Log("TimeLastScrap+ScrapComboTime : " + TimeLastScrap+ScrapComboTime);
        // Debug.Log("LastTimeLoose+TimeLoose : " + LastTimeLoose+TimeLoose);
        // Debug.Log(CurrentScrapcombo);
        // Debug.Log((int)CurrentScrapcombo);

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

        //Met un max à l'énergie pour stopper la regen d'énergie
        if (Energy < MaxEnergy)
        {
        Energy += EnergyRegen * Time.deltaTime;
        }

        //scrap
        //3 secondes pour perdre le combo
        //foutre time loose sur le 3
        //foutre un son à chaque ++ de combo
        //same pour --
        //animation +1 pour compteurs
        //sons différent en fonction du combo 
        //animation du combo à l'écran
        //countdown du combo
        if (Time.time >= TimeLastScrap + 3 && bLoosingCombo == false)
        {
            bLoosingCombo = true;
           
        }
       
        // si le combo est perdu et que c'est un combo supérieur à 1 il décrémente 
        //jusqu'au mini tant qu'on ramasse pas un nouveau scrap 
        if(bLoosingCombo && LastTimeLoose+TimeLoose<Time.time)
        {
            CurrentScrapcombo--;
            LastTimeLoose = Time.time;
            UIRef.SetCombo((int)CurrentScrapcombo);
            //UIRef.ResetTimerDecrement();
            

            if (CurrentScrapcombo < scrapsCombo.Mediocre)
            {
                // if (UIRef.isCombo == false)
                // {
                // UIRef.ComboAnimStart("-1");
                // }
                UIRef.IsDone = true;
                CurrentScrapcombo = scrapsCombo.Mediocre;
                // UIRef.ResetTimer();
                // UIRef.DeactivateComboUI();
            }
            if (CurrentScrapcombo >= scrapsCombo.Mediocre)
            {
                if (UIRef.isCombo && UIRef.IsDone == false)
                {
                UIRef.ComboAnimStart("-1");
                }
            }
        }
        if (CurrentScrapcombo > scrapsCombo.Mediocre)
        {
            UIRef.isCombo = true;
        }
        if (CurrentScrapcombo == scrapsCombo.Mediocre)
        {
            UIRef.isCombo = false;
        }
        if (bIsShooting && LastTimeShootingHaptic+TimeShootingHaptic<Time.time)
        {
            bIsShooting = false;
            LastTimeShootingHaptic = Time.time;
            ResetHaptics();
        }
        if (bIsHit && LastTimeHitHaptic+TimeHitHaptic<Time.time)
        {
            bIsHit = false;
            LastTimeHitHaptic = Time.time;
            ResetHaptics();
        }
            if (bIsDead && LastTimeDeathHaptic+TimeDeathHaptic<Time.time)
        {
            bIsDead = false;
            LastTimeDeathHaptic = Time.time;
            ResetHaptics();
        }
        ShieldUpdate();
        if (Shield <= 0)
        {
            Renderer.transform.GetComponent<Collider>().enabled = false;
        }
        if (Shield >= 0)
        {
            Renderer.transform.GetComponent<Collider>().enabled = true;
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
        //Debug.Log("Index : " + indexcrtweapon);
        indexcrtweapon += (int)nextweapon;

        if(indexcrtweapon<0)
        {
            indexcrtweapon = shipweapons.Count-1;
        }
        else if(indexcrtweapon>shipweapons.Count-1)
        {
            indexcrtweapon = 0;
        }

        currentWeapon1 = shipweapons[indexcrtweapon];


       // currentWeapon1.PrintInfo();
       UIRef.SetWeapon(indexcrtweapon);
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
    public void OnChangeMap()
    {
        SceneManager.LoadScene("OldScene");
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

        //Si veut inverser le mouvement vertical mettre tout en -vertical sur la ligne 291, 295, 302.
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
                Debug.Log("Tu t'es pris un mur");
                break;
            case "obstacle":
                TakeDamage(25);
                this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.5f;
                Debug.Log("Tu t'es pris un obstacle");
                break;
            case "ennemy":
                Death();
                Debug.Log("Tu t'es fait tué par un ennemi");
               // this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * 0.5f;
                break;
        }
    }
    private void Shoot()
    {
        if(bShoot1 && NextShoot1Time < Time.time && Energy>=currentWeapon1.energyconsumption)
        {
            GameObject newbullet = Instantiate(bullet);
            //Maybe Canonend here, ou essayer pour mettre une rotation cohérente
            //newbullet.transform.position = MuzzleFlash.transform.position;
            //newbullet.transform.rotation = MuzzleFlash.transform.rotation;
            newbullet.transform.position = ship.transform.position + ship.transform.forward*7 ;
            newbullet.GetComponent<bullet>().ActiveBullet(this.transform.forward,this.gameObject,currentWeapon1.Damage);
            NextShoot1Time = Time.time + (1/currentWeapon1.ShootRate);
            Energy -= currentWeapon1.energyconsumption;        
            AudioManager.PlayOneShot("Sons Arme Primaire");
            MuzzleFlash.Play();
            ShootHaptic();
            LastTimeShootingHaptic = Time.time;
            bIsShooting = true;
        }
    }
private void ChargeShoot()
    {
        float pourcentcharge = currentCharge/currentWeapon1.ChargeTime;
        if(Energy >= currentWeapon1.energyconsumption*pourcentcharge )
        {
            GameObject newbullet = Instantiate(bullet2);
            // newbullet.transform.localScale += new Vector3(1f, 1f, 1f);
            newbullet.transform.position = ship.transform.position + (ship.transform.forward * 10);
            newbullet.GetComponent<bullet>().ActiveChargedBullet(this.transform.forward, this.gameObject, Mathf.RoundToInt(currentWeapon1.Damage * pourcentcharge), Mathf.RoundToInt(currentWeapon1.CHargeSpeedMultiplier * pourcentcharge), Mathf.RoundToInt(currentWeapon1.ChargeSizeMultiplier * pourcentcharge)); ;

            Energy -= currentWeapon1.energyconsumption*pourcentcharge;
            AudioManager.PlayOneShot("Sons Arme Secondaire");
            MuzzleFlash.Play();
            ChargedShootHaptic();
            LastTimeShootingHaptic = Time.time;
            bIsShooting = true;
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
            Localdmg = dmg;
            dmg = 0;
            healthBar.SetShield(Shield);
            AudioManager.PlayOneShot("Hit Shield Player Sound");
            HitShieldHaptic();
            LastTimeHitHaptic = Time.time;
            bIsHit = true;
            ParticleSystem newHitEffect = Instantiate(HitPlayerEffectShield);
            newHitEffect.transform.SetParent(this.transform, false);
            newHitEffect.transform.position = this.transform.position;
            Destroy(newHitEffect.gameObject, 1);
            ChangeShieldColor();
        }

        if(Shield<0)
        {
            dmg = -Shield;
            Shield = 0;
            healthBar.SetShield(Shield);
            HitShieldHaptic();
            LastTimeHitHaptic = Time.time;
            bIsHit = true;
            ParticleSystem newHitEffect = Instantiate(HitPlayerEffectShield);
            newHitEffect.transform.SetParent(this.transform, false);
            newHitEffect.transform.position = this.transform.position;
            Destroy(newHitEffect.gameObject, 1);
            ChangeShieldColor();
        }

        if (Shield == 0 && dmg > 0){
        Life -= dmg;
        healthBar.SetHealth(Life);
        HitHealthHaptic();
        LastTimeHitHaptic = Time.time;
        bIsHit = true;
        AudioManager.PlayOneShot("Hit Health Player Sound");
        ParticleSystem newHitEffect = Instantiate(HitPlayerEffectHealth);
        newHitEffect.transform.SetParent(this.transform, false);
        newHitEffect.transform.position = this.transform.position;
        Destroy(newHitEffect.gameObject, 1);
        }
  
        if(Life <= 0 )
        {
            //Foutre le HUD death here
            Death();
        }
       
    }
    public void Death()
    {
        InitStatistique();
        this.gameObject.transform.position = Spawn.transform.position;
        this.gameObject.transform.forward = Spawn.transform.forward;
        DeathHaptic();
        LastTimeDeathHaptic = Time.time;
        bIsDead = true;
        ChangeShieldColor();
    }
    private void InitStatistique()
    {
        AccelerateValue = MaxforwardSpeed / 2;
        DecelerateValue = MaxforwardSpeed / 2;
        RollSpeed = 360 / 2;
        Life = MaxLife;
        Energy = MaxEnergy;
        EnergyRegen = 20;
        Shield = MaxShield;
        scraps = 0;
        rbShip.velocity = Vector3.zero;
        currentWeapon1 = shipweapons[0];
        indexcrtweapon = 0;
         countEnnemy = 0;
         CountObstacle = 0;
        CurrentScrapcombo = scrapsCombo.Mediocre;
        healthBar.SetMaxHealth(MaxLife);
        healthBar.SetMaxShield(MaxShield);
        healthBar.SetMaxEnergy(MaxEnergy);
        UIRef.SetWeapon(indexcrtweapon);
    }
    public void addScraps(int nbscraps)
    {
        //UIRef.ResetTimerDecrement();
        bLoosingCombo = false;
        scraps += nbscraps * (int)CurrentScrapcombo;
        scrapsGain = nbscraps * (int)CurrentScrapcombo;
        Energy += nbscraps * (int)CurrentScrapcombo;
        EnergyGain = nbscraps * (int)CurrentScrapcombo;
        Shield += nbscraps * (int)CurrentScrapcombo;
        ShieldGain = nbscraps * (int)CurrentScrapcombo;
        if (Shield >= MaxShield)
        {
            Shield = MaxShield;
        }

        healthBar.SetShield(Shield);
        ChangeShieldColor();
        healthBar.SetEnergy(Energy);
        UIRef.ScrapAnimStart();
        UIRef.ShieldAnimStart();
        UIRef.EnergyAnimStart();

        if (CurrentScrapcombo >= scrapsCombo.Excessif)
        {
            UIRef.ComboAnimStart("+0");
            CurrentScrapcombo = scrapsCombo.Excessif;
        }
        else if (Time.time<TimeLastScrap+ScrapComboTime)
        {
            UIRef.ComboAnimStart("+1");
            CurrentScrapcombo++;
        } else 
        {
            UIRef.ComboAnimStart("+1");
        }
        
        //Debug.Log("Scraps combo : " + CurrentScrapcombo);
       // Debug.Log("Scrap score : " + scraps);

        TimeLastScrap = Time.time;
        //Debug.Log("addscrap");
        UIRef.ActivateComboUI();
        UIRef.SetCombo((int)CurrentScrapcombo);
        UIRef.StartCount();
        ComboSound();
    }
    public void EnnemyDestroyed()
    {
        countEnnemy++;
        UIRef.EnnemyAnimStart();
    }
    public void ObstacleDesgtroyed()
    {
        CountObstacle++;
        UIRef.ObstacleAnimStart();
    }
    public void HitHealthHaptic()
    {
        Gamepad.current.SetMotorSpeeds(0.5f, 0.5f);
    }
        public void HitShieldHaptic()
    {
        Gamepad.current.SetMotorSpeeds(0.3f, 0.3f);
    }
        public void ShootHaptic()
    {
        Gamepad.current.SetMotorSpeeds(0.2f, 0.2f);
    }
        public void ChargedShootHaptic()
    {
        Gamepad.current.SetMotorSpeeds(1f, 1f);
    }
        public void DeathHaptic()
    {
        Gamepad.current.SetMotorSpeeds(1f, 1f);
    }
    public void ResetHaptics()
    {
        InputSystem.ResetHaptics();
    }
    public void ComboSound()
    {
        if ((int)CurrentScrapcombo == 1)
        {
        AudioManager.PlayOneShot("Combo 1");
        }
        else if ((int)CurrentScrapcombo == 2)
        {
        AudioManager.PlayOneShot("Combo 2");
        }
        else if ((int)CurrentScrapcombo == 3)
        {
        AudioManager.PlayOneShot("Combo 3");
        }
        else if ((int)CurrentScrapcombo == 4)
        {
        AudioManager.PlayOneShot("Combo 4");
        }
        else if ((int)CurrentScrapcombo == 5)
        {
        AudioManager.PlayOneShot("Combo 5");
        }
        else if ((int)CurrentScrapcombo == 6)
        {
        AudioManager.PlayOneShot("Combo 6");
        }
        else if ((int)CurrentScrapcombo == 7)
        {
        AudioManager.PlayOneShot("Combo 7");
        }
        else if ((int)CurrentScrapcombo == 8)
        {
        AudioManager.PlayOneShot("Combo 8");
        }
        else if ((int)CurrentScrapcombo == 9)
        {
        AudioManager.PlayOneShot("Combo 9");
        }
        else if ((int)CurrentScrapcombo == 10)
        {
        AudioManager.PlayOneShot("Combo 10");
        }
    }
    public void ShieldUpdate()
    {
        Material[] mats = Renderer.materials;
        Material ShieldMaterial, HexMaterial;
        ShieldColor = new Color32((byte)ColorRFloat1, (byte)ColorGFloat1, (byte)ColorBFloat1, (byte)ColorAFloat1);
        HexColor = new Color32((byte)ColorRFloat2, (byte)ColorGFloat2, (byte)ColorBFloat2, (byte)ColorAFloat2);
        // ShieldMaterial = mats[0];
        ShieldMaterial = Renderer.material;
        // HexMaterial = mats[1];
        // ShieldMaterial.color = ShieldColor;
        // HexMaterial.color = HexColor;
        ShieldMaterial.SetColor("FrontColor_", ShieldColor);
        ShieldColor.a = (byte)ColorAFloat1;
        HexColor.a = (byte)ColorAFloat2;
    }
    public void ChangeShieldColor()
    {
        ColorAFloat1 = (Shield * 255/MaxShield);
        ColorAFloat2 = (Shield * 255/MaxShield);
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
