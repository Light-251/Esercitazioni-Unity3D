using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    public float life = 10f;
    public Text testoVita;
    public Text alertText;
    string nomeDanno = "null";
    public bool regen = false;
    public float danno = 0.03f;

    private void Awake()
    {
        alertText.text = null;
        life = 10f;
        testoVita.text = ("Vita attuale: " + (int)life);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //testoVita.text = ("Vita attuale: " + (int)life);
        Debug.Log("Vita(float): " + life + " Vita (int): " + (int)life);

        //Controllo regen
        if (regen)
        {
            regenLife();
        }
        
    }
    private void regenLife()
    {
        if (life < 10f & regen == true)
        {
            StartCoroutine(lifeRegen());
        }
    }
    IEnumerator lifeRegen()
    {
        yield return new WaitForSeconds(1);
        alertText.text = ("Regen in Corso");
        if (life < 10f)
        {
            life += 0.01f;
            testoVita.text = ("Vita attuale: " + (int)life);
        }
        if (life >= 10f)
        {
            testoVita.text = ("Vita attuale: " + (int)life);
            regen = false; //Creare un oggetto in-game che attiva la rigenerazione
            StartCoroutine(alertLifeRestored());
            yield break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            danno = 0.5f;
            life -= danno;
            testoVita.text = ("Vita attuale: " + (int)life);
            nomeDanno = "Zombie";
            StartCoroutine(alertDamage());
        }
        if(collision.tag == "endLevel")
        {
            StartCoroutine(alertEndLevel());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger Stay, nome collisione: " + collision.name + ", tag collisione: " + collision.tag);
        if (collision.name == "lava")
        {
            danno = 0.03f;
            life -= danno;
            testoVita.text = ("Vita attuale: " + (int)life);
            nomeDanno = "Lava";
            StartCoroutine(alertDamage());
        }
    }
    IEnumerator alertDamage()
    {
        if (alertText != null)
        {
            alertText.text = ("Danno da " + nomeDanno + " -" + danno);
        }
        yield return new WaitForSeconds(3);
        alertText.text = null;
    }
    IEnumerator alertLifeRestored()
    {
        alertText.text = ("Vita Ripristinata");
        yield return new WaitForSeconds(3);
        alertText.text = null;
        yield break;
    }
    IEnumerator alertEndLevel()
    {
        alertText.text = "Livello Completato";
        yield return new WaitForSeconds(5);
        alertText.text = null;
        yield break;
    }
}
