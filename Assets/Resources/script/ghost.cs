using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghost : MonoBehaviour
{
    public int MaxHP=100;
    public int HP;
    private Animator anim;
    public RectTransform recTransform;

    public float xOffset;
    public float yOffset;
    public Slider slider;
    public Transform hero;
    GameObject tar;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        anim = GetComponent<Animator>();
        Debug.Log("111");     
        

}

    // Update is called once pe
    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);
        att();
        
        
    }
    public void DeHP(int dehp)
    {
        HP -= dehp;
        slider.value = HP;
        if (HP <= 0)
        {
            Debug.Log("Ghost Die");
            anim.SetBool("Die",true);
        }
    }
    public void die()
    {
        Destroy(gameObject);
    }
    void AI()
    {
        if (hero.position.x > transform.position.x)
        {
            transform.position = new Vector2(transform.position.x + 0.1F, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (hero.position.x < transform.position.x)
        {
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void att()
    {
        GameObject tar = hero.gameObject;
        Vector3 tarpos = tar.transform.position;
        if (Vector3.Distance(transform.position, tarpos) <= 3)
        {
            //isAttack = true;
            Debug.Log("win");
            move g = tar.GetComponent<move>();
            g.DeHP(0.3f);
            Debug.Log("攻击成功   " + tar.name + "还剩余" + g.HP + "点血");
            
            
        }
        else
        {
            AI();
        }
    }

        
}
