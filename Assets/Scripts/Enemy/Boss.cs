using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
   // public Transform [] objetives;
    public float startWaitTime;
    public float maxWaitTime;
    private float waitTime;
    // private int randomSpot;
    [Header("Random Movement")]
    [SerializeField]
    private Vector3 randomSpot;
    [SerializeField]
    private float minX, minY, maxX, maxY;


    private Animator anim;
    public LayerMask whatIsSolid;
    private Transform player;
    private float timeBtwAttacks;
    public GameObject [] bossBullets;

    public float MinX { get => minX; set => minX = value; }
    public float MinY { get => minY; set => minY = value; }
    public float MaxX { get => maxX; set => maxX = value; }
    public float MaxY { get => maxY; set => maxY = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        randomSpot.Set(Random.Range(minX, maxX), Random.Range(minY, maxY),0);
        timeBtwAttacks = startTimeBtwAttacks;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        if (player != null) {
            FollowPlayer();
        }
        
        
    }
    public override void FollowPlayer()
    {
        
        Vector3 dir = (player.position - transform.position).normalized;
        Vector3 dirObjetives = (randomSpot - transform.position).normalized;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, player.position - transform.position, visiusRadius, whatIsSolid);
        if (hitInfo != false)
        {
            Debug.Log("ray: " + hitInfo.collider.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            if (hitInfo.transform.CompareTag("Player"))
            {
                anim.SetFloat("movX", dir.x);
                anim.SetFloat("movY", dir.y);
                //anim.SetBool("Walking",true);
                if (timeBtwAttacks <= 0)
                {
                    StartCoroutine(RangeAttack());
                    timeBtwAttacks = Random.Range(1, startTimeBtwAttacks);
                }
                else
                {
                    timeBtwAttacks -= Time.deltaTime;

                }
                base.FollowPlayer();
            }
            else
            {
                MoveToSpot(dirObjetives);
            }
        }
        else
        {
            MoveToSpot(dirObjetives); 
        }        
    }


    public void MoveToSpot(Vector3 dirObjetives) {
        transform.position = Vector2.MoveTowards(transform.position, randomSpot, speed * Time.deltaTime);
        anim.SetFloat("movX", dirObjetives.x);
        anim.SetFloat("movY", dirObjetives.y);
        //anim.SetBool("Walking",true);

        if (Vector2.Distance(transform.position, randomSpot) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot.Set(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                waitTime = Random.Range(startWaitTime, maxWaitTime);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


    IEnumerator  RangeAttack() {
        int bulletIndex = Random.Range(0, bossBullets.Length);
        Instantiate(bossBullets[bulletIndex], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bossBullets[bulletIndex], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bossBullets[bulletIndex], transform.position, transform.rotation);
        
    }
    
    
}
