using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("çıìGê›íË")]
    [SerializeField] private float detectionRange = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            // ÉvÉåÉCÉÑÅ[Çí«ê’
            agent.SetDestination(player.position);
        }
        else
        {
            // çıìGîÕàÕäOÇ»ÇÁí‚é~
            agent.ResetPath();
        }

    }
}
