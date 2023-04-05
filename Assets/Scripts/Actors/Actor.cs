using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MoveableObject
{
    // [SerializeField] public float stateUpdateLimit = 5;
    [SerializeField] public ActorConfig config;
    [SerializeField] public State state = State.None;
    [SerializeField] internal Projectile projectilePrefab;
    List<Projectile> projectiles =  new List<Projectile>(); 
    // public const float maxStateUpdateLimit = 5;
    // public const float movementUpdateLimit = 0.2f;
    public float stateUpdate = 0;
    public float movementUpdate = 0;
    public int maxHp = 10;
    public int hp = 10;
    public float projectileMultiplier = 1f;
    public float shootUpdate = 0;
    // Start is called before the first frame update
    void Start(){
        hp = maxHp;
    }
    public void MoveActor(){
        if(!isBeyondBoundary){
            this.moveObject();
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
        Vector3 dir = this.getDirection();
        // Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, Quaternion.identity) ;
        Projectile projectile =(Projectile)Instantiate(projectilePrefab, this.transform.position+dir, this.transform.rotation) ;
        projectiles.Add(projectile);
        projectile.name = "P1";
        projectile.setParent(this);
        projectile.setDirection(this.direction);
        projectile.setForce(speed);
    }
    public void Update()
    {
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
