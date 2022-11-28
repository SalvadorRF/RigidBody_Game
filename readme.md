# Aplicación basada en RigidBody
Crear un juego basado en la implementación de física y detección de colisiones

El programa se basa en 3 scripts principales, Player Controller el cual controla los eventos que determinan si el jugador se encuentra en el suelo o no, también controla el movimiento por medio del teclado. Area, controla que el jugador no salga del area de juego por medio de un trigger de colisión. Jump Pad se encarga de detectar cuando una entidad entra a su collision box y disparar la acción en el jugador, en este caso lanzarlo por los aires o simplemente hacerlo saltar dependiendo del modo en que se configuró el jumpPad.

## Scripts
PlayerController.cs

    using  System.Collections;
    using  System.Collections.Generic;
    using  UnityEngine;
    
    public  class  PlayerController  :  MonoBehaviour
    {
    	private  new  Rigidbody rigidbody;
    	public  float movementSpeed;
    	public  float jumpForce;
    	public  float angularSpeed;
    	private  float orgJumpForce;
    	public  bool isGrounded =  true;
    	public  bool isInJumpPad =  false;
    
    	void  Start()
    	{
    		rigidbody  =  GetComponent<Rigidbody>();
    		orgJumpForce  =  jumpForce;
    	}
    
    	void  Update()
    	{
    		float hor =  Input.GetAxisRaw("Horizontal");
    		float ver =  Input.GetAxisRaw("Vertical");
    
    		move(hor,  ver,  (hor  !=  0  ||  ver  !=  0));
    		jump(Input.GetButtonDown("Jump"));
    
    	}
    
    	private  void  OnCollisionEnter(Collision  collision)
    	{
    		if  (collision.gameObject.CompareTag("Ground")  ||  collision.gameObject.CompareTag("JumpPad"))
    		{
    			isGrounded  =  true;
    		}
    	}
    
    	private  void  move(float  hor,  float  ver,  bool  move)
    	{
    		Vector3 velocity =  Vector3.zero;
    
    		if  (move)
    		{
    			Vector3 direction =  (transform.forward  *  ver  +  transform.right  *  hor).normalized;
    			velocity  =  direction  *  movementSpeed;
    		}
    
    		velocity.y  =  rigidbody.velocity.y;
    		rigidbody.velocity  =  velocity;
    	}
    
    	private  void  jump(bool  jump)
    	{
    		if  (jump  &&  isGrounded)
    		{
    			rigidbody.AddForce(Vector3.up  *  jumpForce,  ForceMode.Impulse);
    			isGrounded  =  false;
    		}
    	}
    }

Area.cs

    using  System.Collections;
    using  System.Collections.Generic;
    using  UnityEngine;
    
    public  class  Area  :  MonoBehaviour
    {
    	
    	public  Transform spawnPoint;
    
    	void  Start()
    	{
    
    	}
    
    	void  Update()
    	{
    
    	}
    
    	private  void  OnTriggerExit(Collider  other)
    	{
    		if  (other.gameObject.name  ==  "Player")
    		{
    			other.gameObject.transform.position  =  spawnPoint.position;
    		}
    	}
    }	

JumpPad.cs

    using  System.Collections;
    using  System.Collections.Generic;
    using  UnityEngine;
    
    public  class  JumpPad  :  MonoBehaviour
    {
    	public  float jumpForce =  10;
    	public  float impulseForce =  10;
    	public  bool randomJump =  false;
    
    	void  Start()
    	{
    
    	}
    
    	void  Update()
    	{
    
    	}
    
    	private  void  OnTriggerEnter(Collider  collision)
    	{
	    	if  (collision.gameObject.name  ==  "Player")
	    	{
	    
		    	PlayerController PlayerController =  collision.gameObject.GetComponent<PlayerController>();
		    	Rigidbody playerRigidbody =  PlayerController.GetComponent<Rigidbody>();
		    
		    	if  (PlayerController.isGrounded)
		    	{
			    	if  (randomJump)
			    	{
				    	playerRigidbody.AddForce(transform.forward  *  jumpForce  *  30,  ForceMode.Impulse);
				    	playerRigidbody.AddForce(Vector3.up  *  impulseForce,  ForceMode.Impulse);
			    	}
			    	else
			    	{
				    	playerRigidbody.AddForce(Vector3.up  *  jumpForce,  ForceMode.Impulse);
			    	}
		    	}
	    	}
    	}
    }

