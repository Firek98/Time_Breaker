using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Disparo : MonoBehaviour {

    public float shootspeed;
    public float bombspeed;
    public float energia;
	public KeyCode disparo;
    public KeyCode CambiarDisparo;
    public KeyCode DisparoMando;
    public KeyCode CambiarDisparoMando;
    public KeyCode TimeMando;
    public KeyCode time;
    public KeyCode pausa;
    public KeyCode PausaMando;
	public GameObject bala;
    public GameObject balaDoble;
    public GameObject balaTriple;
    public GameObject bala2;
	public GameObject player;
    public GameObject bomba;
    public GameObject laser;
    public Transform bulletSpawn;
	public Transform bulletSpawn2;
	public Transform bombSpawn;
    public Transform laserSpawn;
    public bool menu;
    public int tipodisparo;
	public bool disparodisable1;
	public bool disparodisable2;
	public bool disparodisable3;
    public float fireRateBullet = 0.5f;
    public float fireRateBomb = 1.0f;
    public float nextFire;
    public int municion;
    public int timeEnergy;
    public Image ImagenBala;
    public Image ImagenBomba;
    public Image ImagenLaser;
	//Para la barra de energia
	public float barDisplay; 
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	public bool doubleShoot;
    public bool tripleShoot;
    public float EnergyTime;
	public bool MejoraBalas;
	public AudioSource audioDisparo;
	public AudioSource audioTiro;
	public AudioSource audioTirotocho;
	public AudioSource audioLaser;
	public AudioSource audioFullBar;
	public AudioSource audioMisil;
	public AudioSource audioTiempoStart;
	public AudioSource audioTiempoDurante;
	public AudioSource audioTiempoFinal;

	public Image XBala;
	public Image XBomba;
	public Image XLaser;

	public bool timeStopped;
	public Image Fade_Tiempo;
    // Use this for initialization
    void Start () 
	{
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        menu = false;
        tipodisparo = 1;
		barDisplay = 0;
		audioDisparo = audioTiro;
		timeStopped = false;
		XBala.enabled = false;
		XBomba.enabled = false;
		XLaser.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (menu==true)
        {
            if (Input.GetKeyDown(pausa) || Input.GetKeyDown(PausaMando))
            {
                menu = false;
            }
        }
        if(menu==false)
        {
            if (Input.GetKeyDown(pausa) || Input.GetKeyDown(PausaMando))
            {
                menu = true;
            }
            if (Input.GetKey(disparo) || Input.GetKey(DisparoMando))
            {
                Fire();
            }
            if(Input.GetKeyUp(disparo) || Input.GetKeyUp(DisparoMando))
            {
            	laser.SetActive(false);
				audioLaser.Stop ();
            }
            if (timeEnergy > 0)
            {

				if (Input.GetKeyDown (time) || Input.GetKeyDown (TimeMando)) 
				{
					if(timeStopped == false && barDisplay <= 0.915 )
					{
						Fade_Tiempo.GetComponent<Animator>().SetTrigger("Fade_In_Trigger");
						audioTiempoStart.Play ();
						timeStopped = true;
					}
				}
                if (Input.GetKey(time) || Input.GetKey(TimeMando))
                {
					if(barDisplay <= 0.915 && timeStopped == true)
					{
	                    int EnemySpeed = Enemigos.enemyspeed;
	                    int ShootSpeed = BalaEnemiga.shootSpeed;
	                    int AsteroidSpeed = Asteroids.asteroidSpeed;
						timeStopped = true;
						Enemigos.enemyspeed /= 5;
	                    BalaEnemiga.shootSpeed /= 5;
						Asteroids.asteroidSpeed /= 5;
						audioTiempoDurante.Play ();
						EnergyTime += 0.03f;
						barDisplay = EnergyTime*0.1f;
						if(barDisplay > 0.915)
						{
							Fade_Tiempo.GetComponent<Animator>().SetTrigger("Fade_Out_Trigger");
							Enemigos.enemyspeed = EnemySpeed;
							BalaEnemiga.shootSpeed = ShootSpeed;
							Asteroids.asteroidSpeed = AsteroidSpeed;
						}
					}
				
                }
				if (Input.GetKeyUp(time) || Input.GetKeyUp(TimeMando))
				{
					if(timeStopped == true)
					{
						Fade_Tiempo.GetComponent<Animator>().SetTrigger("Fade_Out_Trigger");
						timeStopped = false;
						audioTiempoFinal.Play ();
						audioTiempoDurante.Stop ();
						audioTiempoStart.Stop ();
					}
				}
			
                   
            }
            if(Input.GetKeyDown(CambiarDisparo) || Input.GetKeyDown(CambiarDisparoMando))
            {
                ChangeShoot();
            }
        }
        if (tipodisparo == 1)
        {
            ImagenBala.enabled = true;
            ImagenBomba.enabled = false;
            ImagenLaser.enabled = false;
        }
        else if (tipodisparo == 2)
        {
            ImagenBala.enabled = false;
            ImagenBomba.enabled = true;
            ImagenLaser.enabled = false;
        }
        else if (tipodisparo == 3)
        {
            ImagenBala.enabled = false;
            ImagenBomba.enabled = false;
            ImagenLaser.enabled = true;
        }
    }

	void OnGUI() 
	{
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	void Fire()
	{
        if(tipodisparo == 1)
        {
			XBomba.enabled = false;
			XLaser.enabled = false;
			if (disparodisable1 == false) 
			{
				if(Time.time > nextFire)
				{
					nextFire = Time.time + fireRateBullet;
					if(GetComponentInParent<Nave>().Tochas == true)
					{
						bala = bala2;
						audioDisparo = audioTirotocho;
					}
					if (GetComponentInParent<Nave>().Doble == false && GetComponentInParent<Nave>().Triple == false)
					{
						bala = bala;
					}
					else if (GetComponentInParent<Nave>().Doble == true && GetComponentInParent<Nave>().Triple == false)
					{
						bala = balaDoble;
					}
					else if (GetComponentInParent<Nave>().Triple == true)
					{
						bala = balaTriple;
					}

					var bullet = Instantiate(
						bala,
						bulletSpawn.position,
						bulletSpawn.rotation);
					// Add velocity to the bullet
					//bullet.GetComponent<Rigidbody2D>().AddForce((new Vector2(shootspeed * Time.deltaTime, 0)), ForceMode2D.Impulse);
					audioDisparo.Play ();
				}
			}
			else
			{
				XBala.enabled = true;
			}
        }
            
			//else 
			//{
			//	if (Time.time > nextFire) {
			//		nextFire = Time.time + fireRateBullet;
			//		// Create the Bullet from the Bullet Prefab
			//		var bullet2 = (GameObject)Instantiate (
			//			             bala2,
			//			             bulletSpawn.position,
			//			             bulletSpawn.rotation);

			//		// Add velocity to the bullet
			//		bullet2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootspeed * Time.deltaTime, 0), ForceMode2D.Impulse);
			//	}
			//}
        else if(tipodisparo == 2)
        {
			XBala.enabled = false;
			XLaser.enabled = false;
			if (disparodisable2 == false) 
			{
				if(Time.time > nextFire)
				{
					nextFire = Time.time + fireRateBomb;
					var bomb = (GameObject)Instantiate(
						bomba,
						bombSpawn.position,
						bombSpawn.rotation);
					bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(bombspeed * Time.deltaTime, 0), ForceMode2D.Impulse);
					audioMisil.Play ();
				}
			}
			else
			{
				XBomba.enabled = true;
			}
        }
        else
        {
			XBala.enabled = false;
			XBomba.enabled = false;
			if (disparodisable3 == false) 
			{
				if(barDisplay <= 0.915)
				{
					EnergyTime += 0.03f;
					laser.SetActive(true);
					if(laser.activeSelf)
					{
						barDisplay = EnergyTime*0.1f;
					}
					audioLaser.Play ();
				}
				else
				{
					laser.SetActive(false);
					audioLaser.Stop ();
				}
			}
			else
			{
				XLaser.enabled = true;
			}
        }
	}

    void ChangeShoot()
    {
        if(tipodisparo < 3)
        {
            tipodisparo++;
        }
        else
        {
			if(laser.activeSelf == false)
			{
				tipodisparo = 1;
			}
            
        }
    }
}
