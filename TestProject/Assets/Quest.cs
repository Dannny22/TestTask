using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public bool dialog1;
    public bool dialog2;
    public bool dialog1_2;
    public bool dialog2_2;
    public int dialog = 0;
    public string missionTag;
    private GameObject MP;
    public bool Press_E;
    public bool Visible_E = true;
    public GameObject cameraMain;
    public GameObject cameraQuest;
    Enemy enemyScript;
    Enemy enemyScript2;
    public bool Score;

    // Start is called before the first frame update
    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player");
        Cursor.visible = false;
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        enemyScript2 = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy>();
    }

    // Update is called once per frame
    public void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2 & Visible_E)
        {
            Press_E = true;
        }
        else
        {
            Press_E = false;
        }

        if (Input.GetKeyDown(KeyCode.E) & Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2 & dialog < 5)
        {
            cameraMain.SetActive(false);
            cameraQuest.SetActive(true);
            Press_E = false;
            dialog1 = true;
            Cursor.visible = true;
            Visible_E = false;
            gameObject.GetComponent<Animator>().SetTrigger("Talk");
        }

        if (Input.GetMouseButtonDown(1) & dialog1)
        {
            dialog1 = false;
            dialog = 1;
            gameObject.GetComponent<Animator>().SetTrigger("Talk2");
        }

        if (dialog == 4 & Input.GetKeyDown(KeyCode.E) & Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2)
        {
            Visible_E = false;
            dialog2 = true;
            dialog1 = false;
            gameObject.GetComponent<Animator>().SetTrigger("Talk");
        }

        if (Input.GetMouseButtonDown(1) & dialog2)
        {
            dialog2 = false;
            dialog = 5;
            gameObject.GetComponent<Animator>().SetTrigger("Talk2");
        }
        if (dialog == 4 & !dialog2)
        {
            Visible_E = true;
        }

        if (Input.GetMouseButtonDown(1) & dialog1_2)
        {
            dialog = 3;
            cameraMain.SetActive(true);
            cameraQuest.SetActive(false);
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonDown(1) & dialog2_2)
        {
            dialog = 6;
            cameraMain.SetActive(true);
            cameraQuest.SetActive(false);
            Cursor.visible = false;
        }


    }

    public void OnGUI()
    {
        if (Press_E)
        {
          
                //GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width + 250) / 2 + 5, (Screen.height) / 2 + 15, 600, 600), "Нажмите E");
                GUI.Label(new Rect((Screen.width + 240) / 2 + 5, (Screen.height + 25) / 2 + 15, 600, 600), "для диалога");

        }

        if (dialog1)
        {
            GUI.Label(new Rect((Screen.width - 400) / 2 + 5, (Screen.height + 500) / 2 + 15, 600, 600), "Мужчина, помогите, бандиты в переулке гонятся за мной!");
            GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height + 525) / 2 + 15, 600, 600), "(Нажмите ПКМ для продолжения)");

        }
        if (dialog == 1)
        {
            
            GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height + 500) / 2 + 15, 600, 600), "Хорошо, я разберусь с ними.");
            dialog1_2 = true;


        }

        if (dialog2)
        {
            GUI.Label(new Rect((Screen.width - 400) / 2 + 5, (Screen.height + 500) / 2 + 15, 600, 600), "Все, я разобрался с ними.");
            
        }
        if (dialog == 5)
        {
            GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height + 500) / 2 + 15, 600, 600), "Спасибо большое!");
            dialog2_2 = true;

        }

        if (dialog == 3 || dialog == 4)
        {
            GUI.Label(new Rect(20, 200, 300, 50), "Разберитесь с бандитами");
            dialog1_2 = false;
            
            if (!enemyScript.Dead & !enemyScript2.Dead)
            {
                GUI.Label(new Rect(200, 200, 215, 30), "0/2");
                
            }
            if ((enemyScript.Dead || enemyScript2.Dead) & !Score)
            {

                GUI.Label(new Rect(200, 200, 215, 30), "1/2");

            }
            if (enemyScript.Dead & enemyScript2.Dead)
            {
                Score = true;
                GUI.Label(new Rect(200, 200, 215, 30), "2/2");
                GUI.Label(new Rect(20, 225, 300, 50), "Вернитесь к девушке");
                dialog = 4;
            }

            
        }


    }
}
