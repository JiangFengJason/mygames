using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    Vector3 CameraPosition;
    Vector3 startPosition;

	public GameManager gm;
	public SkillController skc;

	//角色的属性
    public float jumpheight;
    public float Movespeed1;
    public float count;//run是否带刹车计时器
    public float count1;//rush总时间计时器
    public float count2;//rush加速时间计时器
    public float count3;//rush间隔计时器
	public int powercount;//蓄力指数计时器

    public bool leftcheck;
    public bool rightcheck;
    public bool landcheck;
    public bool stopusing;//禁用左右键的判断量
    public bool stoprush;//禁用C键的判断变量
    public bool attack1;
    public bool airattack;
    public bool sing;
    public bool hit;//受到攻击
	public bool nothing; // 啥都干不了的判断

	public ArrayList DogedList = new ArrayList(); //记录已经闪避的弹幕
	public int dogetime;   //闪避次数

    public Animator animator;
    public Rigidbody2D character;
    public AudioClip hitlanding,hitback,run,landing,fly;
    AudioSource hitlandingSound,hitbackSound,runSound,landingSound,flySound;

	public int damtimecount;

	public int attackuffnumber;
	public bool powerup1,powerup2;

	//各种组
    ArrayList ColliderList = new ArrayList();  //碰撞器

	// Use this for initialization
	void Start () {
		//初始化脚本参数
        jumpheight = 600f;
       // jumpheight = 13f;
        Movespeed1 = 0.3f * skc.movespeed;
        count = 30f;
        count1 = 0f;
        count2 = 0f;
        count3 = 0f;
        leftcheck = false;
        rightcheck = false;
        landcheck = false;
        stopusing = false;
        stoprush = false;
        hit = false;
        attack1 = true;
        airattack = true;
        sing = true;
        startPosition = new Vector3(-23f, 6f, 0);
        this.transform.position = startPosition;
		damtimecount = 0;
		dogetime = 0;
		powerup1 = false;
		powerup2 = false;
        hitlandingSound = gameObject.AddComponent<AudioSource>();
        hitbackSound = gameObject.AddComponent<AudioSource>();
        runSound = gameObject.AddComponent<AudioSource>();
        landingSound = gameObject.AddComponent<AudioSource>();
        flySound = gameObject.AddComponent<AudioSource>();
        hitlandingSound.clip = hitlanding;
        hitbackSound.clip = hitback;
        runSound.clip = run;
        landingSound.clip = landing;
        flySound.clip = fly;
        
        CameraPosition = GameObject.Find("Main Camera").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        cameracontrol();
		powerup ();
		if (!nothing) {
            //checkA ();
			checkJ ();
			checkW ();
		}
        checkspeed();
        checkland();
        checkhit();
        if (Input.GetKey(KeyCode.A) && !leftcheck && !stopusing && !nothing 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("BreakD")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dash")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")
            )
        {
            animator.SetBool("run",true);
            animator.SetBool("stand", false);
            animator.SetBool("breakr", false);
            left();
            rightcheck = false;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
                this.transform.localScale = new Vector3(-0.1f, 0.1f, 1f);
        }
		if (Input.GetKey(KeyCode.D) && !rightcheck && !stopusing && !nothing 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("BreakD") 
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dash")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")
            )
        {
            animator.SetBool("run", true);
            animator.SetBool("stand", false);
            animator.SetBool("breakr", false);
            right();
            leftcheck = false;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
                this.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
		if (Input.GetKey(KeyCode.Space) && !stoprush && !nothing )
        {
			if(count1 == 0)
			{
				if(skc.sp > 2)
					skc.DoRushSkill();
				dogetime = skc.rushlevel;
				DogedList.Clear();
			}
            count3 = 0;
            stopusing = true;
            animator.SetBool("fall", false);
			if(!landcheck)
				skc.jumptime = 0;
            if (rightcheck||leftcheck)
            {
                animator.SetBool("rush", false);
                animator.SetBool("breakd", true);
            }
            if (this.transform.localScale.x > 0 && !rightcheck && this.transform.position.x < 113.5)
            {
				if(count1 == 0)
					if(skc.sp > 2){
						skc.sp = skc.sp - 2;
					}
					else
					{
						count1 = 36;
						count2 = 36;
						stoprush = true;
						stopusing = false;
					}
                if (count1 < 35)
                {
                    count1++;
                    animator.SetBool("rush", true);
                    animator.SetBool("breakd", false);
                    character.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }else if (count1==35)
                {
                    animator.SetBool("rush", false);
                    if (landcheck)
                        animator.SetBool("breakd", true);
                    else if (!landcheck)
                        animator.SetBool("fall", true);
                    character.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                if (count2 < 10)
                {
                    count2++;
                    Movespeed1 += 0.3f * skc.movespeed;
                    transform.Translate(Vector3.right *Movespeed1);
                }
                else if (count2<=35&&count2>=10)
                {
                    count2++;
                    transform.Translate(Vector3.right * 3f* skc.movespeed);
                    Movespeed1 = 0.3f * skc.movespeed;
                }
                leftcheck = false;
            }
			else if (this.transform.localScale.x < 0 && !leftcheck && this.transform.position.x > -24.5)
            {
				if(count1 == 0)
					if(skc.sp > 2)
						skc.sp = skc.sp - 2;
					else
					{
						count1 = 35;
						count2 = 36;
						stoprush = true;
						stopusing = false;
					}
                if (count1 < 35)
                {
                    count1++;
                    animator.SetBool("rush", true);
                    animator.SetBool("breakd", false);
                    character.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
                else if (count1 == 35)
                {
                    animator.SetBool("rush", false);
                    if (landcheck)
                        animator.SetBool("breakd", true);
                    else if (!landcheck)
                        animator.SetBool("fall", true);
                    character.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                if (count2 < 10)
                {
                    count2++;
                    Movespeed1 += 0.3f * skc.movespeed;
                    transform.Translate(Vector3.left * Movespeed1);
                }
                else if (count2 < 35 && count2 >= 10)
                {
                    count2++;
                    transform.Translate(Vector3.left * 3f * skc.movespeed);
                    Movespeed1 = 0.3f * skc.movespeed;
                }
                rightcheck = false;
            }
            else if (this.transform.position.x > 113.5 || this.transform.position.x < -24.5)
            {
                animator.SetBool("rush", false);
                animator.SetBool("breakd", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            count1 = 0;
            count2 = 0;
            Movespeed1 = 0.3f * skc.movespeed;
            if (!landcheck)
                animator.SetBool("fall", true);
            else 
                animator.SetBool("breakd", true);
            animator.SetBool("rush", false);
            stopusing = false;
            stoprush = true;
        }

		//恢复冲刺功能的条件判断
		if (stoprush && !Input.GetKey(KeyCode.Space)) { 
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Stand") && !animator.IsInTransition(0))
				stoprush = false;
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !animator.IsInTransition(0))
				stoprush = false;
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
				stoprush = false;
		}

		//跳跃次数的重制
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Landing"))
			skc.jumptime = skc.jumplevel;

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("run", false);
            if (count < 0)
            {
                animator.SetBool("breakr", true);
                count = 30;
            }
            else if (count > 0)
            {
                animator.SetBool("stand", true);
                count = 30;
            }
        }
	}


    void checkhit()
    {
		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("HitFall") && !animator.GetCurrentAnimatorStateInfo (0).IsName ("HitLanding")) {
			if(!animator.GetCurrentAnimatorStateInfo (0).IsName ("HitBack") && !animator.GetCurrentAnimatorStateInfo (0).IsName ("Dam") && !hit)
				nothing = false;
			if (landcheck && hit && damtimecount == 0) {
				animator.SetBool ("dam", true);
				hit = false;
				damtimecount = 150;
			} else if (hit && damtimecount <= 50) { 
				animator.SetBool ("hited", true);
				hit = false;
				damtimecount = 150;
			} else if (damtimecount > 50) {
				animator.SetBool ("hited", false);
				animator.SetBool ("dam", false);
				hit = false;
			} 
			if(damtimecount > 0)
				damtimecount = damtimecount - 1;
		}
    }

    void checkland()
    {
        if (landcheck)
        {
            character.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("landing", true);
        }
        else if (!landcheck)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Sing") || animator.GetCurrentAnimatorStateInfo(0).IsName("MAGIC"))
            {
                character.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                character.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            animator.SetBool("landing", false);
        }
        if (transform.InverseTransformDirection(character.velocity).y == 0 && landcheck)
        {
            animator.SetBool("landing", true);
            animator.SetBool("fall", false);
            animator.SetBool("jump", false);
        }
    }
    void checkspeed()
    {
        if (transform.InverseTransformDirection(character.velocity).y < 0)
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", true);
            animator.SetBool("landing", false);
        }
        else if (transform.InverseTransformDirection(character.velocity).y >= 0)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") && !Input.GetKey(KeyCode.W))
            {
                animator.SetBool("jump", false);
            }
            else
            {
                animator.SetBool("jump", true);
            }
        }
    }
    void checkW()
    {
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !animator.IsInTransition(0))
		animator.SetBool("rejump",false);
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("landing", false);
            animator.SetBool("fall", false);
            jump();
            character.constraints = RigidbodyConstraints2D.FreezeRotation;
            landcheck = false;
        }
    }
    void checkJ()
    {
		animator.SetBool("attack1", false);
		animator.SetBool("airattack", false);
		if (Input.GetKey(KeyCode.J) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dash") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
        {
			stoprush = true;
            animator.SetBool("attack1", attack1);
            attack1 = false;
			if (animator.GetBool ("attack1") || animator.GetBool ("airattack"))
				if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
					Attack ();
			if (!landcheck)
            {
                animator.SetBool("airattack", airattack);
                airattack = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            animator.SetBool("airattack", airattack);
            animator.SetBool("attack1", attack1);
            attack1 = true;
            airattack = true;
			if(powercount > 120)
			{
				skc.powerAttack(powercount);
				powercount = 0;
                //GameObject.Destroy(GameObject.Find("PowerUp1(Clone)"));
                //GameObject.Destroy(GameObject.Find("PowerUp2(Clone)"));
				powerup1 = false;
				powerup2 = false;
			}
        }
    }

	void powerup()
	{
		if (Input.GetKey (KeyCode.J)) {
			if(skc.attackmode == 2 && skc.atklevel > 3 && skc.atklevel < 9 && powercount < 540){
				powercount = powercount + 2;
			}
			else if(skc.attackmode == 2 && skc.atklevel > 8 && powercount < 540){
				powercount = powercount + 3;
			}
			if(skc.sp > 0)
			{
				skc.sp = skc.sp - 0.02f;
			}
			else
			{
				powercount = 0;
                //GameObject.Destroy(GameObject.Find("PowerUp1(Clone)"));
                //GameObject.Destroy(GameObject.Find("PowerUp2(Clone)"));
				powerup1 = false;
				powerup2 = false;
			}
		}

		if (powercount > 120 && !powerup1) {
			skc.efc.newpowerup2ef(this.transform);
			powerup1 = true;
		}
		if (powercount >= 540 && !powerup2) {
			skc.efc.newpowerup1ef(this.transform);
			powerup2 = true;
		}
	}

    void cameracontrol()
    {
        if (this.transform.position.x <= 106 && this.transform.position.x >= -14)
        {
            CameraPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1, CameraPosition.z);
            GameObject.Find("Main Camera").transform.position = CameraPosition;
        }
        else
        {
            CameraPosition = new Vector3(CameraPosition.x, this.transform.position.y + 1, CameraPosition.z);
            GameObject.Find("Main Camera").transform.position = CameraPosition;
        }
    }
    void right()
    {
        if (this.transform.position.x < 113.5)
        {
            transform.Translate(Vector3.right * skc.movespeed);
            count--;
        }
    }
    void left()
    {
        if (this.transform.position.x > -24.5)
        {
            transform.Translate(Vector3.left * skc.movespeed);
            count--;
        }
    }

    void jump()
    {
		if (landcheck)
		{
			character.velocity = new Vector3(0f, 0f, 0f);   
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpheight);
		}
        if (!landcheck && this.transform.position.y < 20 && skc.jumptime > 0)
        {
			skc.jumptime = skc.jumptime - 1;
			animator.SetBool("rejump",true);
            character.velocity = new Vector3(0f, 0f, 0f);   
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpheight);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.tag == "left" || collider.tag == "right" || collider.tag == "grund") {
			GameObject co = collider.gameObject;
			ColliderList.Add (co);

			if (collider.tag == "left")
				rightcheck = true;
			if (collider.tag == "right")
				leftcheck = true;
			if (collider.tag == "grund")
				landcheck = true;
		} 
    }

	void OnTriggerStay2D(Collider2D collider)
	{
		GameObject mgo = collider.gameObject;
		bool isbullet = false;
		bool dam = false;
		if (collider.tag == "Enermy") {
			mgo = collider.gameObject;
			isbullet = false;
			dam = true;
		} else if (collider.tag == "Bullet") {
			mgo = collider.gameObject;
			isbullet = true;
			dam = true;
		} else if (collider.tag == "Budy") {
			mgo = collider.gameObject;
			while(mgo.tag != "Enermy")
			{
				mgo = mgo.transform.parent.gameObject;
			}
			isbullet = false;
			dam = true;
		}

		if (dam) {
			powercount = 0;
            //GameObject.Destroy(GameObject.Find("PowerUp1(Clone)"));
            //GameObject.Destroy(GameObject.Find("PowerUp2(Clone)"));
			powerup1 = false;
			powerup2 = false;
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Dash") && dogetime > 0) {
				bool exist = false;
				for (int i = 0; i< DogedList.Count; i++) {
					if ((GameObject)DogedList [i] == mgo)
						exist = true;
				}
				if (!exist)
				{
					skc.DoDodgeSkill(isbullet,mgo);
					dogetime = dogetime - 1;
					DogedList.Add(mgo);
					//触发闪避效果
					//触发闪避特效
					//将go添加到队列中
				}
			} else {
				hit = true;
				if (damtimecount <= 50 && nothing == false) {
					skc.Dmg (isbullet, mgo);
					nothing = true;
				}
			}
		}
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject co = collider.gameObject;
        bool rightstay = false;
        bool leftstay = false;
        bool landstay = false;
        for (int i = 0; i < ColliderList.Count;)
        {
            GameObject co1 = (GameObject)ColliderList[i];
            if (co == co1)
            {
                ColliderList.RemoveAt(i);
                if (ColliderList.Count == 0)
                    break;
            }
            if (co1.tag == "left")
                rightstay = true;
            if (co1.tag == "right")
                leftstay = true;
            if (co1.tag == "grund")
                landstay = true;
            if (co != co1 && i < ColliderList.Count)
                i++;
        }
        if (rightstay == false)
            rightcheck = false;
        if (leftstay == false)
            leftcheck = false;
        if (landstay == false)
            landcheck = false;
    }
    //void checkA()
    //{
    //    animator.SetBool("sing", false);
    //    if (Input.GetKey(KeyCode.A)  && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
    //    {
    //        animator.SetBool("sing", sing);
    //        sing = false;
    //        stoprush = true;
    //    }
    //    if (Input.GetKeyUp(KeyCode.A))
    //    {
    //        animator.SetBool("sing", sing);
    //        sing = true;
    //    }
    //}

	void Attack()
	{
		if (skc.sp > 0.5f) {
			//发动攻击技能
			skc.DoAttackSkill ();
			skc.sp = skc.sp - 0.5f;
			skc.Attack ();
		}
	}
    public void playhitlanding()
    {
        hitlandingSound.Play();
    }
    public void playhitback()
    {
        hitbackSound.Play();
    }
    public void playrun()
    {
        runSound.Play();
    }
    public void playlanding()
    {
        landingSound.Play();
    }
    public void playfly()
    {
        flySound.volume = 0.3f;
        flySound.Play();
    }
}
