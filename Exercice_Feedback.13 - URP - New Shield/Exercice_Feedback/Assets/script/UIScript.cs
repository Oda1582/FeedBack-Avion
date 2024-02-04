using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    public Ship refplayer;
    public TMP_Text _UIEnnemis, _UIObstacle, _UIScrap, _UICombo, _UITimer, _UIScrapAnimText, _UIShieldAnimText, _UIComboAnimText;
    public GameObject _UIEnnemyAnim, _UIObstacleAnim, _UIScrapAnim, _UIComboInfo, _UIShieldAnim, _UIEnergyAnim, _UIComboAnim; 
    public GameObject EnnemyAnchor, ObstacleAnchor, ScrapAnchor, ShieldAnchor, EnergyAnchor, ComboAnchor; 
    public bool StartTimer;
    public Image ImageArme;
    public Sprite ArmePrimaire, ArmeSecondaire;
    public AudioManager AudioManager;
    public bool isCombo = false, IsDone = true;
    public Color32 Color1, Color2, Color3, Color4, Color5, Color6, Color7, Color8, Color9, Color10, ColorSec1, ColorSec2, ColorSec3;

    // Attributs 
    public float CurrentTime;
    public float StartingTime;
    public float secondes; 
    public float centiemes;

    // Start is called before the first frame update
    public void Start()
    {
        StartingTime = refplayer.TimeLoose;
        CurrentTime = StartingTime;     
    }

    // Update is called once per frame
    public void Update()
    {
        _UIEnnemis.text = refplayer.countEnnemy.ToString();
        _UIObstacle.text = refplayer.CountObstacle.ToString();
        _UIScrap.text = refplayer.scraps.ToString();
        // Debug.Log((int)refplayer.CurrentScrapcombo);
    }
    public void FixedUpdate()
    {

        if (StartTimer == true){
        
        // Incrémentation du chronomètre
        CurrentTime -= 1 * Time.fixedDeltaTime;
        
        // Arrondissement a 2 chiffres apres la virgule
        CurrentTime = (Mathf.Floor(CurrentTime * 100f))/100;

        // Formatage
        secondes = Mathf.Floor(CurrentTime);
        centiemes = Mathf.Floor((CurrentTime - secondes) * 100f);
        secondes.ToString();
        centiemes.ToString();
        string niceTime = string.Format("{0:0},{1:00}", secondes, centiemes);
        // Debug.Log("Current Time : " + CurrentTime);
        // Debug.Log("Secondes :" + secondes);
        // Debug.Log("Centièmes : " + centiemes);
        //Debug.Log(isCombo);

        // Affichage dans l'UI (et gestion du "0")
        _UITimer.text = niceTime;

        if (isCombo == true && CurrentTime <= 0.01f){
            ResetTimerDecrement();
            //Ne pas mettre de reset ici car ça empêche la décrémentation quand plusieurs combo, ou sinon foutre un boolean
            //CurrentTime = 0;
            //ResetTimer();
            //DeactivateComboUI();
        } 
        else if (isCombo == false && CurrentTime <= 0f)
        {
            // ComboAnimStart("-1");
            ResetTimer();
            DeactivateComboUI();
        }
        ChangeComboTextColor();
        ChangeComboTimerTextColor();
        }
    }

    public void EnnemyAnimStart()
    {
        GameObject newEnnemyAnim = Instantiate(_UIEnnemyAnim);
        newEnnemyAnim.transform.SetParent(EnnemyAnchor.transform, false);
        newEnnemyAnim.transform.position = EnnemyAnchor.transform.position;
        newEnnemyAnim.SetActive(true);
    }
    public void ObstacleAnimStart()
    {
        GameObject newObstacleAnim = Instantiate(_UIObstacleAnim);
        newObstacleAnim.transform.SetParent(ObstacleAnchor.transform, false);
        newObstacleAnim.transform.position = ObstacleAnchor.transform.position;
        newObstacleAnim.SetActive(true);
    }
    public void ScrapAnimStart()
    {
        GameObject newScrapAnim = Instantiate(_UIScrapAnim);
        newScrapAnim.transform.SetParent(ScrapAnchor.transform, false);
        newScrapAnim.transform.position = ScrapAnchor.transform.position;
        newScrapAnim.SetActive(true);
        _UIScrapAnimText.text = ("+" + (refplayer.scrapsGain));
    }
    public void ShieldAnimStart()
    {
        // if (refplayer.Shield >= refplayer.MaxShield)
        // {
        //     _UIShieldAnimText.text = ("+" + (refplayer.MaxShield - refplayer.Shield));
        // } 
        // else 
        // {
        // _UIShieldAnimText.text = ("+" + (refplayer.ShieldGain));
        // }
        GameObject newShieldAnim = Instantiate(_UIShieldAnim);
        TMP_Text newShieldAnimText = newShieldAnim.GetComponent<TMPro.TextMeshProUGUI>();
        newShieldAnim.transform.SetParent(ShieldAnchor.transform, false);
        newShieldAnim.transform.position = ShieldAnchor.transform.position;
        newShieldAnim.SetActive(true);
        newShieldAnimText.text = ("+" + (refplayer.ShieldGain));
    }
    public void EnergyAnimStart()
    {
        // if (refplayer.Shield >= refplayer.MaxShield)
        // {
        //     _UIShieldAnimText.text = ("+" + (refplayer.MaxShield - refplayer.Shield));
        // } 
        // else 
        // {
        // _UIShieldAnimText.text = ("+" + (refplayer.ShieldGain));
        // }
        GameObject newEnergyAnim = Instantiate(_UIEnergyAnim);
        TMP_Text newEnergyAnimText = newEnergyAnim.GetComponent<TMPro.TextMeshProUGUI>();
        newEnergyAnim.transform.SetParent(EnergyAnchor.transform, false);
        newEnergyAnim.transform.position = EnergyAnchor.transform.position;
        newEnergyAnim.SetActive(true);
        newEnergyAnimText.text = ("+" + (refplayer.EnergyGain));
    }
        public void ComboAnimStart(string Text)
    {
        GameObject newComboAnim = Instantiate(_UIComboAnim);
        TMP_Text newComboAnimText = newComboAnim.GetComponent<TMPro.TextMeshProUGUI>();
        newComboAnim.transform.SetParent(ComboAnchor.transform, false);
        newComboAnim.transform.position = ComboAnchor.transform.position;
        newComboAnim.SetActive(true);
        newComboAnimText.text = (Text);
    }

    public void SetCombo(int NbrCombo)
    {
        _UICombo.text = "X" + NbrCombo.ToString() + " " + refplayer.CurrentScrapcombo.ToString();  
    }
    //     public void ResetCombo()
    // {
    //     _UICombo.text = "Inactif";  
    // }
    public void ActivateComboUI()
    {
        _UIComboInfo.SetActive(true);
    }
        public void DeactivateComboUI()
    {
        ComboAnimStart("-1");
        _UIComboInfo.SetActive(false);
    }

    public void StartCount()
    {
        StartingTime = refplayer.TimeLoose;
        CurrentTime = StartingTime;  
        StartTimer = true;
        IsDone = false;
    }

    public void ResetTimer()
    {
        StartingTime = refplayer.TimeLoose;
        CurrentTime = StartingTime;        
        StartTimer = false;
    }
        public void ResetTimerDecrement()
    {
        StartingTime = refplayer.TimeLoose;
        CurrentTime = StartingTime;        
    }
    public void SetWeapon(int index) {

        if(index == 0) {
            ImageArme.sprite = ArmePrimaire;
            AudioManager.PlayOneShot("Change Weapon Sound");
        } else {
            ImageArme.sprite = ArmeSecondaire;
            AudioManager.PlayOneShot("Change Weapon Sound");
        }
    }

    public void ChangeComboTextColor()
    {
        if ((int)refplayer.CurrentScrapcombo == 1)
        {
        _UICombo.color = Color1;
        }
        else if ((int)refplayer.CurrentScrapcombo == 2)
        {
        _UICombo.color = Color2;
        }
        else if ((int)refplayer.CurrentScrapcombo == 3)
        {
        _UICombo.color = Color3;
        }
        else if ((int)refplayer.CurrentScrapcombo == 4)
        {
        _UICombo.color = Color4;
        }
        else if ((int)refplayer.CurrentScrapcombo == 5)
        {
        _UICombo.color = Color5;
        }
        else if ((int)refplayer.CurrentScrapcombo == 6)
        {
        _UICombo.color = Color6;
        }
        else if ((int)refplayer.CurrentScrapcombo == 7)
        {
        _UICombo.color = Color7;
        }
        else if ((int)refplayer.CurrentScrapcombo == 8)
        {
        _UICombo.color = Color8;
        }
        else if ((int)refplayer.CurrentScrapcombo == 9)
        {
        _UICombo.color = Color9;
        }
        else if ((int)refplayer.CurrentScrapcombo == 10)
        {
        _UICombo.color = Color10;
        }
    }
    public void ChangeComboTimerTextColor()
    {
        if(secondes < 3 && secondes >= 2 )
        {
            _UITimer.color = ColorSec1;
        }
        else if (secondes < 2 && secondes >= 1 )
        {
            _UITimer.color = ColorSec2;
        }
        else if (secondes < 1 && secondes >= 0 )
        {
            _UITimer.color = ColorSec3;
        }
    }
}
