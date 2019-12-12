using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject isDie;
    public GameObject isShengli;
    public AudioSource audio;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;

    public int suipian = 0;
    public int yaoshi = 0;
    public int juanzhou = 0;
    public Text yaoshiText;
    public Text juanzhouText;
    public Text yaoshisuipianText;

    public Text guanqiaText;

    public int zuobiaoValue = 0;

    public bool istrue = false;
    bool a = false;


    public Slider ImageHp;


    void Start()
    {
        Light1.SetActive(true);
        Light2.SetActive(false);
        Light3.SetActive(false);

        guanqiaText.text = "Level_1";
        audio.Stop();
        ImageHp.value = 100;
    }
    void Update()
    {
        //yaoshiText.text = "Keys:" + yaoshi;
        //juanzhouText.text = "卷轴碎片:" + juanzhou;
        yaoshisuipianText.text = "Trophies：" + suipian + "/5";

        if (istrue)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                switch (zuobiaoValue)
                {
                    case 0:
                        transform.position = new Vector3(9.52f, 1.1f, -265.5f);
                        break;
                    case 1:
                        transform.position = new Vector3(42.5f, 5.78f, -209.1f);
                        break;
                    case 2:
                        transform.position = new Vector3(94.92f, 13.43f, -61.06f);
                        break;
                }

                isDie.SetActive(false);
                Time.timeScale = 1;
                ImageHp.value = 100;
            }
        }
        if (suipian == 5)
        {
            yaoshi++;
            suipian = 0;
        }

        if (juanzhou == 3)
        {
            isShengli.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.T))
            {
                isShengli.SetActive(false);
                Time.timeScale = 1;
                juanzhou = 0;
                yaoshi = 0;
                suipian = 0;
                Uibutton();
            }

        }
        if (ImageHp.value <= 0)
        {
            isDie.SetActive(true);
            istrue = true;
            Time.timeScale = 0;
        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "isDie")
        {
            isDie.SetActive(true);
            istrue = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "suipian")
        {
            audio.Play();
            suipian++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "men")
        {
            if (yaoshi == 1)
            {
                Light1.SetActive(false);
                Light2.SetActive(true);
                Light3.SetActive(false);
                guanqiaText.text = "Level_2";
                zuobiaoValue++;
                juanzhou++;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "men2")
        {
            if (yaoshi == 2)
            {
                Light1.SetActive(false);
                Light2.SetActive(true);
                Light3.SetActive(true);
                guanqiaText.text = "Level_3";
                zuobiaoValue++;
                juanzhou++;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "shayv")
        {
            ImageHp.value -= 10;
        }

    }
    public void Uibutton()
    {
        SceneManager.LoadScene("UI");
    }
}