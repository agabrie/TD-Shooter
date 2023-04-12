using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Actor : MoveableObject
{
    // [SerializeField] public float stateUpdateLimit = 5;
    [SerializeField] public Animator animator;
    [SerializeField] Material [] materials;
    // [SerializeField] Material accentMaterial;
    [SerializeField] public ActorConfig config;
    [SerializeField] public State state = State.None;
    [SerializeField] internal Projectile projectilePrefab;
    List<Projectile> projectiles =  new List<Projectile>(); 
    [SerializeField] List<QueuedProjectile> projectileQueue =  new List<QueuedProjectile>(); 
    // public const float maxStateUpdateLimit = 5;
    // public const float movementUpdateLimit = 0.2f;
    public float stateUpdate = 0;
    public float movementUpdate = 0;
    public int maxHp = 10;
    public int hp = 10;
    public float projectileMultiplier = 1f;
    public float shootUpdate = 0;
    // Start is called before the first frame update
    public void Start(){
        // animator = GetComponentInChildren<Animator>();
        hp = maxHp;
        // Debug.Log(transform);
        foreach (Transform t in transform)
        {
            if(t.name=="Poof"){
                // string [] accentNames = {"Arm", "Eye", "Foot", "Nozzle"};
                updateChildMaterials(t, materials[1], new string[]{"Arm", "Eye", "Foot", "Nozzle"});
                updateChildMaterials(t, materials[0], new string[]{"Body"});
            }
            // foreach (Transform mesh in t)
            // {

                // Debug.Log(mesh.name);
                // if(mesh.name == "Arm" || mesh.name == "Arm" || mesh.name == "Eye"|| mesh.name == "Foot" || mesh.name == "Nozzle"){
                //     Debug.Log(mesh.name);        
                //     if(mesh.name =="Body"){
                //         mesh.GetComponent<Renderer>().sharedMaterial = materials[0];
                //     }else{
                //         mesh.GetComponent<Renderer>().sharedMaterial = materials[1];
                //     }
                // }    
            // }
        }
    }
    public void MoveActor(){
        if(!isBeyondBoundary){
            // if(!animator.GetBool("isWalking")){
            //     animator.SetBool("isWalking", true);
            // }
            this.moveObject();
        }else{
            if(animator.GetBool("isWalking")){
                animator.SetBool("isWalking", false);
            }
        }
    }

    public void setState(State state){
        this.state = state;
    }

    public State getRandomState(){
        return States.getRandomState();
    }
    public State getRandomState(List<State> selectableStates){
        return States.getRandomState(selectableStates);
    }
    public void fireProjectile(Direction direction,float speed){
        animator.SetTrigger("Shoot");
        // Vector3 dir = this.getDirection();
        // Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, Quaternion.identity) ;
        // Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, this.transform.rotation) ;
        // projectiles.Add(projectile);
        // projectile.name = "P1";
        // projectile.setParent(this);
        queueProjectile(direction, speed);
        // projectile.setDirection(this.direction);
        // projectile.setForce(speed);
    }
    public void queueProjectile(Direction dir,float speed){
        // Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, Quaternion.identity) ;
        // Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, this.transform.rotation) ;
        projectileQueue.Add(new QueuedProjectile(dir, speed));
        // projectile.name = "P1";
        // projectile.setParent(this);
        // projectile.setDirection(this.direction);
        // projectile.setForce(speed);
    }
    public void launchProjectileQueue(){
        // if(projectileQueue.Count<1){
            // return ;
        // }
       for (int i = projectileQueue.Count - 1; i >= 0; i--)
        {
            QueuedProjectile queued;
            if(projectileQueue[i]!=null){
                queued = projectileQueue[i];
            }else{
                continue;
            }
            // if(i>= projectileQueue.Count || i<= 0){
                // i--;
                // break;
            // }
            switch(projectileQueue[i].type){
                case ProjectileType.Standard:{
                    // Debug.Log(string.Format("i=> {0} counter => {1} q => {2}",i, projectileQueue.Count, queued.getDirection()));
                    Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+queued.getDirection(), this.transform.rotation) ;

                    // projectile..sharedMaterial = this.materials[0];
                    // updateChildMaterials(projectile.transform, materials[0]);
                    projectile.updateMaterial(materials);
                    projectile.name = "P1";
                    projectile.setParent(this);
                    projectile.setDirection(queued.direction);
                    projectile.setForce(queued.speed);
                    break;
                }
            }
                    projectileQueue.RemoveAt(i);
        }
    }
    public void updateChildMaterials(Transform transforms, Material m,string []validNames){
            // Debug.Log(transforms.name);
        
        foreach (Transform t in transforms)
        {
            // Debug.Log(t.name);
            if(validNames.Contains(t.name)){
                t.GetComponent<Renderer>().sharedMaterial = m;
            }
        }
    }
    public void Update()
    {
        if(state == State.Move){
            if(!animator.GetBool("isWalking")){
                animator.SetBool("isWalking", true);
            }
        }else{
            if(animator.GetBool("isWalking")){
                animator.SetBool("isWalking", false);
            }
        }
        if(config.animationTime <= 1f){
            config.animationTime += Time.deltaTime;
        }

        if(config.animationTime >= config.shootAnimationTime){
            launchProjectileQueue();
            config.animationTime = 0;
        }
        if(hp <= 0){
            Destroy(this.gameObject);
        }
        checkBeyondBoundary();
        this.updateRotation();
    }
    public int takeDamage(int damage){
        this.hp -= damage;
        if(hp<damage){
            return damage - hp;
        }
        return damage;
    }
    
    

    public void OnCollisionEnter(Collision collision)
    {
        // if(!isPlayer){
            // this.setDirection(this.getRandomDirection());
            // state = State.Move;
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            // if (collision.gameObject.layer == 6)
            // {
            //     //If the GameObject's name matches the one you suggest, output this message in the console
            //     Debug.Log("Collided with floor");
            // }
            // if (collision.gameObject.layer == 8)
            // {
            //     //If the GameObject's name matches the one you suggest, output this message in the console
            //     Debug.Log("Collided with player");
            //     // setDirection(Directions.getRandomDirection(direction));
            //     // state = State.Move;
            // }
            if (collision.gameObject.layer == 3)
            {
                //If the GameObject's name matches the one you suggest, output this message in the console
                // Debug.Log("Collided with NPC");
                // setDirection(Directions.getRandomDirection(direction));
                // state = State.Move;
            }
        // }else{
        //     isBeyondBoundary = true;
        // }
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        // if (collision.gameObject.tag == "MyGameObjectTag")
        // {
        //     //If the GameObject has the same tag as specified, output this message in the console
        //     Debug.Log("Do something else here");
        // }
    }
}
