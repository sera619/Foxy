using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SingleShotSpell : PlayerSpell
{

    [SerializeField] private Vector3 projectileSpawnPosition;
    [SerializeField] private Vector3 projectileSpread;



    public Vector3 ProjectileSpawnPosition { get; set; }
    public ObjectPooler Pooler { get; set; }

    private Vector3 projectileSpawnValue;
    private Vector3 randomProjectileSpread;

    protected override void Awake()
    {
        base.Awake();
        projectileSpawnValue = projectileSpawnPosition;
        projectileSpawnValue.y = -projectileSpawnPosition.y;

        Pooler = GetComponent<ObjectPooler>();
    }


    protected override void RequestShot(){
       base.RequestShot();
       if (CanCast){
           EvaluateProjectileSpawnPosition();
           SpawnProjectile(ProjectileSpawnPosition);
       }  
    }

    private void SpawnProjectile(Vector2 spawnPosition){
        
        // get Object from Pool
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        projectilePooled.transform.position = spawnPosition;
        projectilePooled.SetActive(true);


        // get reference to projectile
        Projectile projectile = projectilePooled.GetComponent<Projectile>();
        projectile.EnableProjectile();
        projectile.ProjectileOwner = SpellOwner;

        // spread 
        randomProjectileSpread.z = Random.Range(-projectileSpread.z, projectileSpread.z);
        Quaternion spread = Quaternion.Euler(randomProjectileSpread);
        projectile.SetDirection(ProjectileSpawnPosition , transform.rotation);

        CanCast = false;


    }

    private void EvaluateProjectileSpawnPosition(){
        ProjectileSpawnPosition = transform.position + transform.rotation * projectileSpawnValue;
    }


    private void OnDrawGizmosSelected() {
        EvaluateProjectileSpawnPosition();

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ProjectileSpawnPosition, 0.1f);    
    }

}
