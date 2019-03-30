using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D m_Rigidbody2D;
    public float moveSpeed = 5.0f;
    private GameObject[] tars;
    private float lastkilltime = 0;
    public float killjg = 1 ;
    public int gjl = 10;
    public bool isAttack = false;
    public float HP;
    public int MaxHP;
    public Slider slider;
    public RectTransform recTransform;

    public float xOffset;
    public float yOffset;
    // Start is
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);
        if (!isAttack) {
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("Run", true);
                transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Run", true);
                transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);

            } else {
                anim.SetBool("Run", false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            float interval = Time.time - lastkilltime;
            if (interval > killjg)
            {
                anim.SetTrigger("Attack");
                anim.SetBool("Run", false);
                Att();
                lastkilltime = Time.time;
            }


        }




    }
    void Att()
    {
        
        tars=GameObject.FindGameObjectsWithTag("huaidan");
        for (int i = 0; i < tars.Length; i++)
        {
            GameObject tar = tars[i];
            Vector3 tarpos = tar.transform.position;
            if (Vector3.Distance(transform.position, tarpos) <= 3)
            {
                isAttack = true;
                Debug.Log("win");
                ghost g=tar.GetComponent<ghost>();
                g.DeHP(gjl);
                Debug.Log("攻击成功   "+tar.name+"还剩余"+g.HP+"点血");
                ResetAttack();
                return;
            }
            {

            }
        }
    }

    public void ResetAttack() {
        isAttack = false;
    }
   
    public void DeHP(float dehp)
    {
        HP -= dehp;
        slider.value = HP;
        if (HP <= 0)
        {
            Debug.Log("Hero Die");
            
        }
    }
}
