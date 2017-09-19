using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AIScript/AIMover")]
public class AIMover : MonoBehaviour
{
	private GameObject mainui;
	private bool scoreflag=true;//scoreが連続で加算されるのを防ぐ

	private EVillagerAnimationMode state;
    private Rigidbody rb;
    public Animator anim;
    private bool isGotBatted;
    private bool isDying;
    private IAIMoveStrategy aiMoveStrategy;
    private int t;
    private Coroutine nowTimeCoroutine;

    // Use this for initialization
    void Awake()
    {
		Debug.Log ("seiseisareta");
		mainui = GameObject.FindGameObjectWithTag ("UI");
        aiMoveStrategy = GetComponent<IAIMoveStrategy>();
        if(aiMoveStrategy==null){
            Debug.Log("AIの移動戦略が指定されていません。");
        }
        rb = this.GetComponent<Rigidbody>();
        anim.Play("Taiki");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float speed = 0;
        if (aiMoveStrategy != null)
        {
            speed = aiMoveStrategy.DoMove();

        }
        if (isDying) return;
        if (isGotBatted) return;
        if (nowTimeCoroutine == null)
            nowTimeCoroutine = StartCoroutine(TimeCountCoroutine());
		
        
        if (speed <0.00001f)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Taiki"))
            {
                state = EVillagerAnimationMode.Taiki;
                anim.Play("Taiki");
            }
        }
        else{
            if(state ==EVillagerAnimationMode.Taiki){
                anim.Play("Aruku");
                state = EVillagerAnimationMode.Aruku;
            }
        }


    }

    private IEnumerator TimeCountCoroutine (){
        yield return new WaitForSeconds(1f);
		if (Random.Range(0, 20) < t)
		{
            if(aiMoveStrategy!=null)
			aiMoveStrategy.Destory();
			aiMoveStrategy = null;
			switch ((int)Random.Range(0, 2 - 0.01f))
			{
				case 0:
                    aiMoveStrategy = gameObject.AddComponent<AIFindNodeMove>();
					break;
				case 1:
					//aiMoveStrategy = gameObject.AddComponent<AIFindNodeMove>();
					break;
				default:
                    //aiMoveStrategy = gameObject.AddComponent<AIFindNodeMove>();
					break;
			}
            t = 0;
		}
        t++;
        nowTimeCoroutine = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bat")
        {
			if (aiMoveStrategy != null) {
				aiMoveStrategy.Destory ();
			}
            aiMoveStrategy = null;
            //aiMoveStrategy = this.gameObject.AddComponent<AIEscapeMove>();
            //aiMoveStrategy.SetSpeed(prevStrategy.GetSpeed());
            StartCoroutine(BatMotionCoroutine(other.transform.position));
            anim.Play("Odoroki");
            state = EVillagerAnimationMode.Bat;
            isGotBatted = true;
        }
        else if ((LayerMask.LayerToName(other.gameObject.layer) == "Charm")){
			if (aiMoveStrategy != null)
			{
				aiMoveStrategy.Destory();
			}
            aiMoveStrategy = null;
            aiMoveStrategy = this.gameObject.AddComponent<AICharmMove>();
            var _transform = other.gameObject.transform;
            (aiMoveStrategy as AICharmMove).SetTransofrm(ref _transform);
        }



    }

	private void OnCollisionEnter(Collision collision){
		if (LayerMask.LayerToName (collision.gameObject.layer) == "Player") {
			anim.Play ("Shinu");
			state = EVillagerAnimationMode.Shinu;
			StartCoroutine (DeadMotionCoroutine ());
			isDying = true;
			if (aiMoveStrategy != null) {
				aiMoveStrategy.Destory ();
			}
			aiMoveStrategy = null;
			if (scoreflag) {
				mainui.GetComponent<Main> ().scorePlus ();
				scoreflag = false;
			}
		}
	}

    
    private IEnumerator BatMotionCoroutine(Vector3 bat_position){
        yield return new WaitForSeconds(0.3f);
        aiMoveStrategy = this.gameObject.AddComponent<AIEscapeMove>();
		(aiMoveStrategy as AIEscapeMove).SetMoveDirection(Vector3Utiltiy.ReturnNormalizedYZeroVec3(this.transform.position - bat_position));
		anim.Play("Hashiri");
        state = EVillagerAnimationMode.Hashiri;
        isGotBatted = false;
	}

    private IEnumerator DeadMotionCoroutine(){
		rb.isKinematic = true;
        this.GetComponent<Collider>().isTrigger = true;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }




}


public enum EVillagerAnimationMode
{
	Taiki, Odoroki, Hashiri, Shinu,Bat,Aruku
}

public static class MoveSpeed{
    public static float CharmSpeed = 0.1f;
    public static float EscapeSpeed = 0.1f;
    public static float WalkSpeed = 0.1f;
}