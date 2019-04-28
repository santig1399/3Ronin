using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("Player Stats")]
    public int normalDamage;
    private int damage;
    [Tooltip("Damage ammount when special hability is actived")]
    public int specialDamage;
    public float speed;
    [Tooltip("Fixed duration time for the hability")]
    public float startSpecialDuration;
    [Tooltip("Cooldown time for special hability")]
    public float startTimeBtwnSpecial;
    //[SerializeField]
    private float timeBtwSpecial;
    //[SerializeField]
    private float specialDuration;

    public Color specialPlayerColor;
    public Color specialImageColor;
    private bool canActivateSpecial = true;
    public Image specialIndicatorImage;
    
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 mov;

    public GameObject splashArt;
   

    void Start()
    {
        specialDuration = 0;
        timeBtwSpecial = startTimeBtwnSpecial;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        FindObjectOfType<Currency>().IntroDialogue(splashArt);
        
        specialIndicatorImage.fillAmount = timeBtwSpecial / startTimeBtwnSpecial;
    }

    public void Update()
    {
        if (timeBtwSpecial<startTimeBtwnSpecial && specialDuration <= 0) {
            canActivateSpecial = false;
            timeBtwSpecial += Time.deltaTime;        
            specialIndicatorImage.fillAmount = timeBtwSpecial / startTimeBtwnSpecial;
        }
        else if (timeBtwSpecial >= startTimeBtwnSpecial) {
            canActivateSpecial = true;
            
        }

        if (specialDuration > 0)
        {
            specialDuration -= Time.deltaTime;
            sprite.color = specialPlayerColor;
            specialIndicatorImage.fillAmount = specialDuration / startSpecialDuration;

            //special stats
            this.damage = specialDamage;
        }
        else if (specialDuration <= 0) {
            sprite.color = Color.white;
            this.damage = normalDamage;
        }

        if (specialIndicatorImage.fillAmount == 1)
        {
            specialIndicatorImage.color = specialImageColor;
        }
        else {
            specialIndicatorImage.color = Color.white;
        }
        
    }

    public void Move(float x, float y) {
        mov.Set(x, y);
        mov = mov.normalized * Time.deltaTime * speed;
        //rb.MovePosition(rb.position + mov);
        transform.Translate(new Vector3(x, y, 0).normalized * speed * Time.deltaTime);
        Animations(x,y);
        
    }
    void Animations(float x, float y) {
        if (mov != Vector2.zero)
        {
            //Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            anim.SetBool("Walking", true);
            anim.SetFloat("movX", x);
            anim.SetFloat("movY", y);
           // print("walking animation");
        }
        else {
            anim.SetBool("Walking", false);
        }
        
    }
    public void Attack() {

        anim.SetTrigger("Attacking");
        Debug.Log("Attacking With Basic Attack");
    }
    public void SpecialAttack() {
        if (canActivateSpecial) {
            anim.SetTrigger("Special");
            specialDuration = startSpecialDuration;
            timeBtwSpecial = 0;
            Debug.Log("Attacking With Special Attack");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) {

            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            //else if (collision.CompareTag("EnemyBullet")) {
            //    Destroy(collision.gameObject)
            //}
        }
    }



}
