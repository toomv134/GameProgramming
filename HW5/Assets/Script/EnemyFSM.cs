using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase,AttackBase,ChasePlayer,AttackPlayer, SelfDestruct }
    public EnemyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float SelfDestructDistance;
    public float playerAttackDistance;
    private NavMeshAgent agent; 
    public float lastShootTime;
    public GameObject bulletPrefab;
    public float fireRate;
    public GameObject shootpoint;
    public ParticleSystem muzzleEffect;
    public Life life;
    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private void Update()
    {
        if (currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else if (currentState == EnemyState.AttackPlayer) { AttackPlayer(); }
        else { SelfDestruct(); }
    }
    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, shootpoint.transform.position, transform.rotation);
            muzzleEffect.Play();
        }
    }
    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    void SelfBomb()
    {
        life.amount = 0;
    }
    void GoToBase() {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        //print("GoToBase"); 
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if(distanceToBase < SelfDestructDistance)
        {
            currentState = EnemyState.SelfDestruct;
        }
        else if (distanceToBase < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackBase() {
        //agent.isStopped = true;
        //LookTo(baseTransform.position);
        //Shoot();
        //print("AttackBase");
    }
    void ChasePlayer() {
        agent.isStopped = false;
        //print("ChasePlayer"); 
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer < SelfDestructDistance)
        {
            currentState = EnemyState.SelfDestruct;
        }
        else if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer() {
        agent.isStopped = true;
        //print("AttackPlayer"); 
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer < SelfDestructDistance)
        {
            currentState = EnemyState.SelfDestruct;
        }
        else if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void SelfDestruct()
    {
        agent.isStopped = true;
        SelfBomb();
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, SelfDestructDistance);
    }
}
