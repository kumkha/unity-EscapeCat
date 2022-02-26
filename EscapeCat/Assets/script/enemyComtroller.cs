using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyComtroller : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;

    private float dampSpeed = 0.02f;



    private GameObject endLine;

    Animator animator;

    public string _targetName = "Player";

    Transform _target;

    public bool _touch = false;

    Rigidbody rigidbody;

    float a;
    float b;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        a = Random.Range(1.0f, 2.0f);
        b = Random.Range(-0.10f, 0.04f);
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");


        //FollowTarget();
        if (_touch == true)
        {
            Vector3 c = new Vector3(b, 0, 0);
            transform.position = Vector3.Lerp(transform.position - c, _target.transform.position, Time.deltaTime + dampSpeed * a);
            transform.LookAt(_target);
            //FollowTarget();
            //Vector3 getVel = new Vector3(xMove, 0, zMove) * dampSpeed;
            //rigidbody.velocity = getVel;
        }
    }

    public void TargetFind()
    {
        // Å¸°Ù string¸¦ ¹Ù²Þ
        _target = GameObject.FindGameObjectWithTag(_targetName).GetComponent<Transform>();
        animator.SetTrigger("isCatRun");

    }
    //public void FollowTarget()
    //{
    //    float a = Random.Range(1.0f, 3.0f);
    //    float b = Random.Range(1.0f, 3.0f);
    //    Vector3 c = new Vector3(a, 0, b);
    //    transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * dampSpeed * a);
    //    //var heading = _target.position - gameObject.transform.position;


    //    //if (heading.sqrMagnitude > 1)
    //    //{
    //    //    gameObject.transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * dampSpeed);

    //    //}

    //    transform.LookAt(_target);
    //}

    private void OnTriggerEnter(Collider other)
    {
        endLine = other.gameObject.GetComponent<GameObject>();
        if(other.tag.Equals("EndLine"))
        {
            Destroy(gameObject);
        }


    }
}


// http://minpaprograming.blogspot.com/2018/04/unity-followtarget-lootat-target.html