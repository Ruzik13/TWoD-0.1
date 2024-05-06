using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] public float speed;
    private float Originalspeed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private float defaultspeed;

    public void notmove()
    {
        anim.SetBool("isRunning", false);
        speed = 0;
    }

    public void Awake()
    {
        initScale = enemy.localScale;
        Originalspeed = speed;
        if (Originalspeed != 0)
        {
            defaultspeed = Originalspeed;
        }
        if (speed == 0)
        {
            speed = defaultspeed;
        }
    }

    private void OnDisable()
    {
        anim.SetBool("isRunning", false);
    }

    private void Update()
    {
        if (speed != 0)
        {
            if (movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                    DirectionChange();
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                    DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("isRunning", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("isRunning", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}