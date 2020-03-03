using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clicker : MonoBehaviour
{
    //private
    float speed = 40f;
    float amount = 1f;
    bool shaking = false, saved = false, Gtimerstared = false, staminazero = false;
    Vector3 startingpos;
    int clicks = 0;
    List<Effect> effectlist;

    //public
    public Image playerhealthbar, enemyhealthbar, staminabar, staminaborder;
    public ParticleSystem ps;
    public GameObject panel, enemypicture;
    public Text globaltimer_text, starttimer_text, clickstext, clicktxt, moneytxt;
    public int minutes, enemyhp;


    private void Start()
    {
        Player.data.Refresh();
        starttimer_text.GetComponent<Timer>().StartTimer();
        startingpos = enemypicture.transform.position;
        effectlist = Player.data.effects;
    }
    //using check in update methods now
    /*
    private void OnMouseDown()
    {
        if (starttimer_text.GetComponent<Timer>().finished && !globaltimer_text.GetComponent<Timer>().finished)
        {
            enemyhp -= Player.data.stats.strength;
            clicks++;
            clickstext.text = Lang.GetText("clicks") + ":" + clicks;
            if (!shaking)
            {
                StartCoroutine(ShakeIt());
            }
            Player.data.indicators.stamina -= 20f;
        }
    }
    */
    IEnumerator ShakeIt()
    {
        ps.Play();
        shaking = true;
        yield return new WaitForSeconds(1);
        shaking = false;
        enemypicture.transform.position = startingpos;
    }

    IEnumerator StaminaCD()
    {
        staminaborder.color = Color.red;
        yield return new WaitForSeconds(3);
        staminazero = false;
        staminaborder.color = Color.black;
    }

    void Update()
    {
        if (!staminazero && Input.GetKeyDown(KeyCode.Mouse0) && enemypicture.GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (starttimer_text.GetComponent<Timer>().finished && !globaltimer_text.GetComponent<Timer>().finished)
            {
                enemyhp -= Player.data.stats.strength;
                clicks++;
                clickstext.text = Lang.GetText("clicks") + ":" + clicks;
                if (!shaking)
                {
                    StartCoroutine(ShakeIt());
                }
                //stamina handle
                Player.data.indicators.stamina -= 20f;
                if (Player.data.indicators.stamina <= 0)
                    Player.data.indicators.stamina = 0;
                if (Player.data.indicators.stamina == 0)
                {
                    staminazero = true;
                    StartCoroutine(StaminaCD());
                }
            }
        }

        if (globaltimer_text.GetComponent<Timer>().finished && !saved)
        {
            RaidBlock._lastraid = DateTime.Now;
            Player.data.lastraid = DateTime.Now;
            RaidBlock._endtime = DateTime.Now.AddMinutes(minutes);
            Player.data.endtime = DateTime.Now.AddMinutes(minutes);

            Moneycount();
            ExpCount();

            SaveSystem.Save();        
            panel.SetActive(true);
            clicktxt.text = clicks.ToString();
            
            var animator = panel.GetComponent<Animator>();
            animator.SetBool("LevelFinished", true);
            saved = true;
        }

        if (starttimer_text.GetComponent<Timer>().finished && !Gtimerstared)
        { 
            starttimer_text.enabled = false;
            globaltimer_text.GetComponent<Timer>().StartTimer();
            Gtimerstared = true;
        }

        if (shaking)
        {
            enemypicture.transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount, enemypicture.transform.position.y, enemypicture.transform.position.z);
        }

        HandleBars();
        StaminaRegen();
    }
    //Methods to Update
    public void HandleBars()
    {
        playerhealthbar.fillAmount = Player.data.indicators.health / (Player.data.indicators.maxhealth / 100) / 100;
        staminabar.fillAmount = Player.data.indicators.stamina / 100f;
        enemyhealthbar.fillAmount = enemyhp / 100f;
    }

    public void StaminaRegen()
    {
        if(!staminazero)
            Player.data.indicators.stamina = Mathf.Clamp(Player.data.indicators.stamina + (Player.data.indicators.staminaregenspeed * Time.deltaTime), 0.0f, Player.data.indicators.maxstamina);
    }
    //End Update methods
    void Moneycount()
    {
        if (effectlist.Contains(Effects.list[1]))
        {
            Player.data.money += clicks * 2;
            moneytxt.text = (clicks * 2).ToString();
        }
        else
        {
            Player.data.money += clicks;
            moneytxt.text = clicks.ToString();
        }
    }

    void ExpCount()
    {

    }
}
