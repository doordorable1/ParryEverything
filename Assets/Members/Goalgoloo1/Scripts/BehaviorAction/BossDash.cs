using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class BossDash : Action
{
    
    public SharedFloat randomForceMin = 1.0f;
    public SharedFloat randomForceMax = 15.0f;

    private float horizontalForce;

    public SharedGameObject targetAnimatorController; 
    private Animator animator;

    public string dashStateName = "newBossDash"; 
    public int layerIndex = 0;

    public GameObject player;

    private Rigidbody2D rb;
    private bool forceApplied = false; 

    public override void OnAwake()
    {
        base.OnAwake();
        rb = GetComponent<Rigidbody2D>();

        var targetGO = GetDefaultGameObject(targetAnimatorController.Value);
        if (targetGO != null)
        {
            animator = targetGO.GetComponent<Animator>();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override void OnStart()
    {
        base.OnStart();
        horizontalForce = Random.Range(randomForceMin.Value, randomForceMax.Value);
        forceApplied = false;
        var direction = player.transform.position.x < transform.position.x ? -1 : 1;
        rb.linearVelocity = Vector2.zero; 
        rb.AddForce(new Vector2(horizontalForce * direction, 0), ForceMode2D.Impulse);
        forceApplied = true; 
    }

    public override TaskStatus OnUpdate()
    {
        if (!forceApplied || animator == null)
        {
            return TaskStatus.Failure;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        if (stateInfo.IsName(dashStateName) && stateInfo.normalizedTime >= 1.0f)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        forceApplied = false; 
    }
}