using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    PATROL,//巡逻
    CHASE,//追踪
    ATTACK,//攻击
    DIE//死亡
}

public class EnemyController : MonoBehaviour {

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;

    private EnemyState enemy_State;

    public float walk_Speed = 0.5f;
    public float run_Speed = 4f;

    public float chase_Distance = 7f;
    private float current_Chase_Distance;
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;

    private float attack_Timer;

    private Transform target;

    public GameObject attack_Point;

    private EnemyAudio enemy_Audio;

    void Awake() {
        enemy_Anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        enemy_Audio = GetComponentInChildren<EnemyAudio>();

    }

    void Start () {

        enemy_State = EnemyState.PATROL;
        patrol_Timer = patrol_For_This_Time;
        attack_Timer = wait_Before_Attack;
        current_Chase_Distance = chase_Distance;

	}
	
	void Update () {
		
        if(enemy_State == EnemyState.PATROL) {
            Patrol();
        }

        if(enemy_State == EnemyState.CHASE) {
            Chase();
        }

        if (enemy_State == EnemyState.ATTACK) {
            Attack();
        }
    }
    //巡逻
    void Patrol() {
        //启用导航
        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;
        
        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > patrol_For_This_Time) {

            SetNewRandomDestination();
            patrol_Timer = 0f;
        }

        if(navAgent.velocity.sqrMagnitude > 0) {
        
            enemy_Anim.Walk(true);
        
        } else {

            enemy_Anim.Walk(false);

        }

        if(Vector3.Distance(transform.position, target.position) <= chase_Distance) {

            enemy_Anim.Walk(false);

            enemy_State = EnemyState.CHASE;

            enemy_Audio.Play_ScreamSound();

        }

    } 
    //追踪
    void Chase() {
        //启用网格导航
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;
        //朝目标
        navAgent.SetDestination(target.position);

        if (navAgent.velocity.sqrMagnitude > 0) {

            enemy_Anim.Run(true);

        } else {

            enemy_Anim.Run(false);

        }
        //目标小于等于攻击距离
        if(Vector3.Distance(transform.position, target.position) <= attack_Distance) {

          
            enemy_Anim.Run(false);
            enemy_Anim.Walk(false);
            enemy_State = EnemyState.ATTACK;

            if(chase_Distance != current_Chase_Distance) {
                chase_Distance = current_Chase_Distance;
            }
            //目标超出追踪距离
        } else if(Vector3.Distance(transform.position, target.position) > chase_Distance) {
         
            enemy_Anim.Run(false);

            enemy_State = EnemyState.PATROL;

            //重置计时器，恢复巡逻
            patrol_Timer = patrol_For_This_Time;
            if (chase_Distance != current_Chase_Distance) {
                chase_Distance = current_Chase_Distance;
            }
        } 

    } 
    //攻击
    void Attack() {

        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_Timer += Time.deltaTime;

        if(attack_Timer > wait_Before_Attack) {

            enemy_Anim.Attack();
            attack_Timer = 0f;
            enemy_Audio.Play_AttackSound();

        }

        if(Vector3.Distance(transform.position, target.position) >
           attack_Distance + chase_After_Attack_Distance) {

            enemy_State = EnemyState.CHASE;

        }
    }

    //巡逻随机找个目标点
    void SetNewRandomDestination() {

        float rand_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);

    }

    void Turn_On_AttackPoint() {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint() {
        if (attack_Point.activeInHierarchy) {
            attack_Point.SetActive(false);
        }
    }

    public EnemyState Enemy_State {
        get; set;
    }

}