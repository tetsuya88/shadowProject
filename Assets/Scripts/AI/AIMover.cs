using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AIScript/AIMover")]
public class AIMover : MonoBehaviour
{
    private EVillagerAnimationMode state;
    private Rigidbody rb;
    public Animator anim;
    private bool isGotBatted;
    private bool isDying;
    private IAIMoveStrategy aiMoveStrategy;
    // Use this for initialization
    void Awake()
    {
        
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
        if(aiMoveStrategy!=null)
        speed = aiMoveStrategy.DoMove();
        if (isDying) return;
        if (isGotBatted) return;
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

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bat")
        {
            aiMoveStrategy.Destory();
            aiMoveStrategy = null;
            //aiMoveStrategy = this.gameObject.AddComponent<AIEscapeMove>();
            //aiMoveStrategy.SetSpeed(prevStrategy.GetSpeed());
            StartCoroutine(BatMotionCoroutine(other));
            anim.Play("Odoroki");
            state = EVillagerAnimationMode.Bat;
            isGotBatted = true;
        }
        else if ((LayerMask.LayerToName(other.gameObject.layer) == "Charm")){
            var prevStrategy = aiMoveStrategy;

            aiMoveStrategy = null;
            aiMoveStrategy = this.gameObject.AddComponent<AICharmMove>();
            aiMoveStrategy.SetSpeed(prevStrategy.GetSpeed());
            var _transform = other.gameObject.transform;
            (aiMoveStrategy as AICharmMove).SetTransofrm(ref _transform);
            prevStrategy.Destory();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Player"){
            Debug.Log("aaa");
            anim.Play("Shinu");
            state = EVillagerAnimationMode.Shinu;
            StartCoroutine(DeadMotionCoroutine());
            isDying = true;
            aiMoveStrategy.Destory();
            aiMoveStrategy = null;
        }
    }
    private IEnumerator BatMotionCoroutine(Collider other){
        yield return new WaitForSeconds(0.3f);
        aiMoveStrategy = this.gameObject.AddComponent<AIEscapeMove>();
		(aiMoveStrategy as AIEscapeMove).SetMoveDirection(Vector3Utiltiy.ReturnNormalizedYZeroVec3(this.transform.position - other.transform.position));
        aiMoveStrategy.SetSpeed(0.1f);
		anim.Play("Hashiri");
        state = EVillagerAnimationMode.Hashiri;
        isGotBatted = false;
	}

    private IEnumerator DeadMotionCoroutine(){
        yield return new WaitForSeconds(0.5f);
        //DestoryThisVillager;
    }


}


public enum EVillagerAnimationMode
{
	Taiki, Odoroki, Hashiri, Shinu,Bat,Aruku
}