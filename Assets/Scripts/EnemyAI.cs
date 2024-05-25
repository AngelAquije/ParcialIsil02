using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class EnemyAI : MonoBehaviour
{
    public List<Transform> points;
    public float speed = 2;
    bool isMoving = true;
    Vector2 dir = Vector2.right;
    SpriteRenderer spr;
    Animator ani;

    IEnumerator moving;
    IEnumerator waiting;
    [SerializeField] float movingTime;
    [SerializeField] float waitingTime;

    private void Reset()
    {
       Init();
    }

    private void Init() 
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "_Root");

        root.transform.position = transform.position;

        transform.SetParent(root.transform);

        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);
        p1.transform.position = Vector3.zero;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform);
        p2.transform.position = Vector3.zero;

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    private void Start()
    {
        moving = Moving(movingTime);
        waiting = Waiting(waitingTime);
        StartCoroutine(moving);
        StartCoroutine(waiting);
    }
    IEnumerator Waiting(float waitTime) 
    {
        while (true) 
        {
            yield return new WaitForSeconds(waitTime);

            if (isMoving)
            {
                StopCoroutine(moving);
                ani.SetTrigger("idle");                
            }
            else 
            {
                spr.flipX = flipSprite;
                dir.x = dir.x > 0 ? -1 : 1;
                ani.SetTrigger("patrol");
                StartMoving();
            }
            isMoving = !isMoving;
        }
    }
    void StartMoving() 
    {
        moving = Moving(movingTime);
        StartCoroutine(moving);
    }
    IEnumerator Moving(float waitTime) 
    {
        while (true)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            yield return new WaitForSeconds(waitTime);
            
        }
    }

    bool flipSprite 
    {
        get => dir.x > 0 ? true : false; 
    }


    private void OnMouseDown()
    {
        Prueba addPrueba = new Prueba();
        int addedNumber;
        string addedText;

        Informacion myInfo = new Informacion();
        myInfo.info = 1;
        int e = myInfo.info;
        if (e == 1) 
        {
            addedNumber = addPrueba.add(10, 25);
            addedText = addPrueba.add("Enemigo", "Experiencia");

            print(addedNumber);
            print(addedText);
        }
        
    }



}
