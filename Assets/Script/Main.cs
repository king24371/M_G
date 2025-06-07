using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public int knock;
    public int plus;
    public int first = 5;
    public int second = 10;
    public int third = 15;
    public int fourth = 20;
    public int thirty = 30;
    public string[] jing;
    public string[] 真言;
    public GameObject Panel;
    public Button Knock;
    public InputField frequency;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        knock = PlayerPrefs.GetInt("Now");
        plus = PlayerPrefs.GetInt("Plus");
        thirty = PlayerPrefs.GetInt("Thirty");

        frequency.text = knock.ToString();
        
        Knock.onClick.AddListener(delegate() {
            _knock();
            PlayerPrefs.SetInt("Now", knock);
            PlayerPrefs.Save();

            frequency.text = knock.ToString();
            AudioManager.inst.Knock();
        });

        frequency.onValueChanged.AddListener(delegate
        {
            GameObject obj = Instantiate(Resources.Load("pfb/Text")) as GameObject;
            obj.transform.SetParent(Knock.transform);
            obj.transform.localPosition = Knock.gameObject.transform.localPosition;

            int r = Random.Range(0, jing.Length);
            obj.GetComponent < Text >().text = jing[r];
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Now");
            PlayerPrefs.DeleteKey("Plus");
            PlayerPrefs.SetInt("Thirty", 30);
            PlayerPrefs.Save();
        }
    }

    void _knock() {
        knock++;

        if(knock == first)
        {
            Panel.SetActive(true);
            txt.text = "敲電子木魚，拜機械佛祖";
            GoogleAdManager.inst.ShowFullScreenAd();
            Invoke("panelOn", 0.8f);
            GoogleAdManager.inst.RequestFullScreenAd();
;        }else if(knock == second)
        {
            Panel.SetActive(true);
            txt.text = "積量子功德，讀賽博真經";
            GoogleAdManager.inst.ShowFullScreenAd();
            Invoke("panelOn", 0.8f);
            GoogleAdManager.inst.RequestFullScreenAd();
        }
        else if (knock == third)
        {
            Panel.SetActive(true);
            txt.text = "行好事，說好話，西方極樂無棉花";
            GoogleAdManager.inst.ShowFullScreenAd();
            Invoke("panelOn", 0.8f);
            GoogleAdManager.inst.RequestFullScreenAd();
        }
        else if (knock == fourth)
        {
            Panel.SetActive(true);
            txt.text = "年輕人，莫地獄，看看廣告積功德";
            GoogleAdManager.inst.ShowFullScreenAd();
            Invoke("panelOn", 0.8f);
            GoogleAdManager.inst.RequestFullScreenAd();
        }

        if(PlayerPrefs.GetInt("Now") >= fourth)
        {
            plus = fourth + thirty;
            PlayerPrefs.SetInt("Plus", plus);
            PlayerPrefs.Save();
            print(plus);
            if (knock == plus)
            {
                int r = Random.Range(0, 4);
                Panel.SetActive(true);
                txt.text = 真言[r];
                GoogleAdManager.inst.ShowFullScreenAd();
                Invoke("panelOn", 0.8f);
                thirty = thirty + 10;
                PlayerPrefs.SetInt("Thirty", thirty);
                PlayerPrefs.Save();
                GoogleAdManager.inst.RequestFullScreenAd();
            }
        }

    }

    void panelOn()
    {
        Panel.SetActive(false);
    }
}
