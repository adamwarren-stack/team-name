using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    public float Deg;

     void start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    
     void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
       if(Mathf.Abs(Vector3.Angle(transform.forward, dir)) <Deg)
       {
        agent.SetDestination(Player.transform.position);
       }
    }
}