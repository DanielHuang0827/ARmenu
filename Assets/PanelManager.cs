
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




//左右按鍵狀況枚舉
enum ProductShow
{ BlackCoffee,
  Latte,
  Tea,
  LemonPie,
  CupCake,
  Tiramisu,
  Sandwitch,
  Croissant,
  Hotdog,

}


public class PanelManager : MonoBehaviour
{   //Panel========================================
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject showPanel;
    [SerializeField] GameObject greetingsPanel;
    [SerializeField] GameObject greetings;

    //Botton========================================
    [SerializeField] Button blackCoffeeBotton;
    [SerializeField] Button latteBotton;
    [SerializeField] Button teaBotton;
    [SerializeField] Button lemonPieBotton;
    [SerializeField] Button cupCakeBotton;
    [SerializeField] Button tiramisuBotton;
    [SerializeField] Button sandwitchBotton;
    [SerializeField] Button croissantBotton;
    [SerializeField] Button hotdogBotton;
    [SerializeField] Button greetingsBotton;
    //Show Panel
    [SerializeField] Button returnBotton;
    [SerializeField] Button rightBotton;
    [SerializeField] Button leftBotton;
    [SerializeField] Button rotateBotton;
    //GameObject=========================================
    [SerializeField] GameObject lemonPie;
    [SerializeField] GameObject tiramisu;
    [SerializeField] GameObject cupCake;
    [SerializeField] GameObject croissant;
    [SerializeField] GameObject sandwitch;
    [SerializeField] GameObject hotdog;
    [SerializeField] GameObject blackcoffee;
    [SerializeField] GameObject latte;
    [SerializeField] GameObject tea;



    //Orinigal========================================
    [SerializeField] GameObject lemonPieOriginal;

    //Audio===========================================
    [SerializeField] AudioSource audioPlayer;

    //================================================
    ProductShow show;
    GameObject current;
    bool isRotate;

    // Start is called before the first frame update
    void Start()
    {
        blackCoffeeBotton.onClick.AddListener(OnBlackCoffeeClick);
        latteBotton.onClick.AddListener(OnlatteBottonClick);
        teaBotton.onClick.AddListener(OnTeaBottonClick);
        lemonPieBotton.onClick.AddListener(OnLemonPieBottonClick);
        hotdogBotton.onClick.AddListener(OnHotdogBottonClick);
        cupCakeBotton.onClick.AddListener(OnCupCakeBottonClick);
        sandwitchBotton.onClick.AddListener(OnSandwitchBottonClick);
        croissantBotton.onClick.AddListener(OnCrossiantBottonClick);
        tiramisuBotton.onClick.AddListener(OnTiramisuBottonClick);

        returnBotton.onClick.AddListener(OnReturnBottonClick);
        rightBotton.onClick.AddListener(OnRightBottonClick);
        leftBotton.onClick.AddListener(OnLeftBottonClick);
        rotateBotton.onClick.AddListener(OnRotateBottonClick);
        greetingsBotton.onClick.AddListener(OnGreetingsBottonClick);
        show = ProductShow.BlackCoffee;
        current = blackcoffee;
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/如歌的行板");
        isRotate = false;
        
    }

    private void OnGreetingsBottonClick()
    {
        showPanel.SetActive(false);
        greetingsPanel.SetActive(true);
        Text greetingstext = greetings.GetComponent<Text>();
        string text;
        int result = Random.Range(1, 100);
        if (result < 34)
        {
            text = "事情做不完就留到明天去做吧，運氣好的話，明天死了就不用做了";

        }
        else if (result < 66)
        {
            text = "這世界唯一公平的事，就是每個人都不公平";

        }
        else if (result <= 100)
        {
            text = "在哪裡跌倒，就在哪裡躺下來";
        }
      





    }

    private void OnRotateBottonClick()
    { //取得目前模型旋轉 
        isRotate = !isRotate;
        
       
           
    }

    void Rotate()
    {
       
        if (isRotate==true)
        {
            //Quaternion angle = Quaternion.identity;
            GameObject showProduct = GameObject.FindGameObjectWithTag("Products");
            showProduct.transform.Rotate(0,0.5f,0);
           
            //angle.setfromtorotation(vector3.right,vector3.left);
            //showproduct.transform.rotation = angle;
        }
        else
        {
            GameObject showProduct = GameObject.FindGameObjectWithTag("Products");
            
            

        }


    }

    private void OnLeftBottonClick()
    {
        //刪除現有模型

        //生成下一個模型 按照順序
        current.SetActive(false);

        switch (show)
        {
            case ProductShow.BlackCoffee:
                show = ProductShow.Latte;
                current = latte;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/嬉遊曲");
                
                break;
            case ProductShow.Latte:
                show = ProductShow.Tea;
                current = tea;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/愛爾蘭傳統音樂");
                break;
            case ProductShow.Tea:
                show = ProductShow.LemonPie;
                current = lemonPie;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/Happy");
                break;
            case ProductShow.LemonPie:
                show = ProductShow.CupCake;
                current = cupCake;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/Maroon5Sugar");
                break;
            case ProductShow.CupCake:
                show = ProductShow.Tiramisu;
                current = tiramisu;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/韋瓦第四季");
                break;
            case ProductShow.Tiramisu:
                show = ProductShow.Sandwitch;
                current = sandwitch;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/SuperMarioBros");
                break;
            case ProductShow.Sandwitch:
                show = ProductShow.Croissant;
                current = croissant;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/藍色多瑙河");
                break;
            case ProductShow.Croissant:
                show = ProductShow.Hotdog;
                current = hotdog;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/PumpIt");
                break;
            case ProductShow.Hotdog:
                show = ProductShow.BlackCoffee;
                current = blackcoffee;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/如歌的行板");
                break;
            
               
        }


        current.SetActive(true);
        audioPlayer.Play();

    }



    private void OnRightBottonClick()
    {
        current.SetActive(false);

        switch (show)
        {
            case ProductShow.BlackCoffee:
                show = ProductShow.Hotdog;
                current = hotdog;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/PumpIt");

                break;
            case ProductShow.Hotdog:
                show = ProductShow.Croissant;
                current = croissant;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/藍色多瑙河");
                break;
            case ProductShow.Croissant:
                show = ProductShow.Sandwitch;
                current = sandwitch;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/SuperMarioBros");
                break;
            case ProductShow.Sandwitch:
                show = ProductShow.Tiramisu;
                current = tiramisu;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/韋瓦第四季");
                break;
            case ProductShow.Tiramisu:
                show = ProductShow.CupCake;
                current = cupCake;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/Maroon5Sugar");
                break;
            case ProductShow.CupCake:
                show = ProductShow.LemonPie;
                current = lemonPie;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/Happy");
                break;
            case ProductShow.LemonPie:
                show = ProductShow.Tea;
                current = tea;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/愛爾蘭傳統音樂");
                break;
            case ProductShow.Tea:
                show = ProductShow.Latte;
                current = latte;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/嬉遊曲");
                break;
            case ProductShow.Latte:
                show = ProductShow.BlackCoffee;
                current = blackcoffee;
                audioPlayer.clip = Resources.Load<AudioClip>("Audios/如歌的行板");
                break;


        }


        current.SetActive(true);
        audioPlayer.Play();
    }

    private void OnReturnBottonClick()
    {
        mainMenuPanel.SetActive(true);
        showPanel.SetActive(false);
        current.SetActive(false);
        audioPlayer.Stop();
        //lemonPie.SetActive(false);
        //latte.SetActive(false);
        //blackcoffee.SetActive(false);
        //tea.SetActive(false);
        //hotdog.SetActive(false);
        //croissant.SetActive(false);
        //cupCake.SetActive(false);
        //sandwitch.SetActive(false);
        //tiramisu.SetActive(false);

    }
    
    private void OnTiramisuBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = tiramisu;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/韋瓦第四季");
        audioPlayer.Play();
    }

    private void OnCrossiantBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = croissant;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/藍色多瑙河");
        audioPlayer.Play();
    }

    private void OnSandwitchBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = sandwitch;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/SuperMarioBros");
        audioPlayer.Play();
    }

    private void OnCupCakeBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = cupCake;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/Maroon5Sugar");
        audioPlayer.Play();
    }

    private void OnHotdogBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = hotdog;
        hotdog.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/PumpIt");
        audioPlayer.Play();

    }

    private void OnLemonPieBottonClick()
    {  
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = lemonPie;
        lemonPie.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/Happy");
        audioPlayer.Play();
    }

    private void OnBlackCoffeeClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = blackcoffee;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/如歌的行板");
        audioPlayer.Play();

    }

    private void OnlatteBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = latte;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/嬉遊曲");
        audioPlayer.Play();
    }

    private void OnTeaBottonClick()
    {
        mainMenuPanel.SetActive(false);
        showPanel.SetActive(true);
        current = tea;
        current.SetActive(true);
        audioPlayer.clip = Resources.Load<AudioClip>("Audios/愛爾蘭傳統音樂");
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();


    }
}
