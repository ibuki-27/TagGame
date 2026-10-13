using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("çıìGê›íË")]
    [SerializeField] private float detectionRange = 10f;

    [Header("ïﬂälê›íË")]
    [SerializeField] private float catchRange = 1.5f;

    private NavMeshAgent agent;

    private bool isGameOver = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (isGameOver) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // ïﬂÇ‹Ç¡ÇΩîªíË
        if (distance <= catchRange)
        {
            GameOver();
            return;
        }

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

    private void GameOver()
    {
        isGameOver = true;

        agent.ResetPath();
        agent.isStopped = true;

        GameManager.Instance.GameOver();
    }
}
