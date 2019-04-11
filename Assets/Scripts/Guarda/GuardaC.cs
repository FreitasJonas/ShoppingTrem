using UnityEngine;
using UnityEngine.AI;

public class GuardaC : MonoBehaviour
{
    public float tempo = 3f;
    //private bool isColided = false;
    private bool right = true;
    private bool canWalk = true;

    private NavMeshAgent navAgent;
    private Animator anim;

    public GameObject limiter_1;
    public GameObject limiter_2;

    //public CapsuleCollider trigger;

    // Use this for initialization
    void Start()
    {
        //trigger = GetComponent<CapsuleCollider>();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canWalk)
        {
            if (right)
            {
                if (!navAgent.hasPath)
                {
                    SetWalk();
                    navAgent.SetDestination(limiter_2.transform.position);
                }
            }
            else
            {
                if (!navAgent.hasPath)
                {
                    SetWalk();
                    navAgent.SetDestination(limiter_1.transform.position);
                }
            }
        }
        else
        {
            if (tempo > 0)
            {
                tempo -= Time.deltaTime;
                canWalk = false;
            }
            else
            {
                tempo = 3f;
                canWalk = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var player = collision.collider.GetComponent<PlayerC>();

            if (!player.sitting)
            {
                navAgent.ResetPath();
                canWalk = false;

                SetIdle();

                var gC = GameObject.FindGameObjectsWithTag("GameController")[0];
                gC.GetComponent<CameraC>().FimDeJogo();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerC>().sitting)
        {
            other.GetComponent<PlayerC>().onRunningAway = true;
            SetRun();
        }
        else if (other.CompareTag("guard_limiter"))
        {
            Flip();
            SetIdle();
            right = !right;

            navAgent.ResetPath(); //retira path atual
            
            canWalk = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerC>().onRunningAway = false;
            SetWalk();
        }
    }

    private void SetRun()
    {
        navAgent.speed = 3;
        anim.SetBool("idle", false);
        anim.SetBool("walking", false);
        anim.SetBool("running", true);
    }

    private void SetWalk()
    {
        navAgent.speed = 1;
        anim.SetBool("idle", false);
        anim.SetBool("walking", true);
        anim.SetBool("running", false);
    }

    private void SetIdle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
        anim.SetBool("running", false);
    }

    private void Flip()
    {
        transform.rotation = Quaternion.Inverse(transform.rotation);
    }
}
