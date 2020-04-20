using UnityEngine;
using UnityEngine.AI;
public class AgentMovement4 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float runningdistance;
    [SerializeField] float attackingdistance;
    private NavMeshAgent agent;

    static Animator anim;

    Health h;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("isIdle", false);

    }

    void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);


        if (agent != null)
        {
            agent.speed = 1;
            anim.SetBool("isWalking", true);

            float dist = Vector3.Distance(transform.position, target.position);
            if(dist < runningdistance)
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", true);

                agent.speed = 2;

                if (dist < attackingdistance)
                {

                    anim.SetBool("isAttacking", true);

                    agent.speed = 1;
                }
            }

        }

    }

}