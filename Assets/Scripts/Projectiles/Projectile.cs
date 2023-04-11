using System;
using UnityEngine;
[Serializable]
public class QueuedProjectile{
    public float speed;
    public Direction direction;
    public GameObject seeking;
    public Vector3 location;
    public ProjectileType type;

    public QueuedProjectile(Direction direction,float speed){
        this.direction = direction;
        this.speed = speed;
        this.type = ProjectileType.Standard;
    }
    public QueuedProjectile(Direction direction,float speed, GameObject seeking){
        this.direction = direction;
        this.speed = speed;
        this.seeking = seeking;
        this.type = ProjectileType.Seeking;
    }
    public QueuedProjectile(Direction direction,float speed, Vector3 location){
        this.direction = direction;
        this.speed = speed;
        this.location = location;
        this.type = ProjectileType.Bomber;
    }
    public Vector3 getDirection(){
        // Debug.Log(this.direction);
        return Directions.get(this.direction);
    }
}
public class Projectile : MoveableObject
{
    [SerializeField] public float force = 2f;
    [SerializeField] public Actor parent;
    [SerializeField] int maxBounces = 1;
    int numBounces = 0;
    int damage = 2;
    // Start is called before the first frame update
    void Start(){

    }
    
    public void setParent(Actor parent){
        this.parent = parent;
    }
    public void updateMaterial(Material []m){
        foreach(Transform t in transform){
            if(t.name == "Bullet"){
                foreach (Transform mesh in t)
                {
                    mesh.GetComponent<Renderer>().sharedMaterial = m[0];
                }
            }
        }
    }
    public void setForce(float multiplier){
        // this.force = force;
        this.setSpeed(force*multiplier);
    }
    // Update is called once per frame
    void Update()
    {
        if(this.hasBreachedBoundary()){
            Destroy(this.gameObject);
        }
        this.updateRotation();
        moveObject();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Harm NPC");
            Destroy(this.gameObject);
            Enemy e = (Enemy) collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage);
            // Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 7){
            this.reflect(collision.contacts[0].normal);
            numBounces++;
            if(numBounces >= maxBounces){
                Destroy(this.gameObject);
            }
            //  Destroy(this.gameObject);
        }
    }
}
