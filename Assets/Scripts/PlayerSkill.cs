using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {

	public GameObject batCircle;
	public GameObject Bat;
    public GameObject charmField;
    public GameObject charmCollision;
    public Animator anim;
	public float speed=3f;
	public float minpos=2f;
	public float maxpos=5f;

	private GameObject batcircle;
	private GameObject bat;
	private Vector3 startpos;
	private float dis = 0f;
	private Vector3 batpos;
	private bool flag=true;
    private Vector3? batVec;
	void Start () {
		
	}
    void RayCastBat(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int laymask = 1 << 13;
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity,laymask);
        if (hit.collider != null)
            batVec = hit.point;
        else
            batVec = null;

        Debug.Log(batVec);
    }

	void Update () {
		startpos = transform.forward * minpos+ new Vector3(0,-1f,0);
		if (Input.GetKeyDown (KeyCode.X)&&flag) {
			flag = false;
			dis = 0f;
			batcircle = Instantiate (batCircle) as GameObject;
			batcircle.transform.position = transform.position + transform.forward * dis + startpos;
            anim.Play("Nageru_mae");
		} else if (Input.GetKeyUp (KeyCode.X)&&batcircle!=null) {
			batpos = batcircle.transform.position;
			Destroy (batcircle);
			StartCoroutine ("BatStart");
            anim.Play("Nageru_ato");
		} else if (Input.GetKey (KeyCode.X)&&batcircle!=null) {
			if (dis < maxpos - minpos) {
				dis += Time.deltaTime * speed;
			} 
			batcircle.transform.position = transform.position + transform.forward * dis + startpos;
		}
        RayCastBat();
        if(batcircle!=null&&batVec!=null){
            batcircle.transform.position = (Vector3)batVec;
        }
        if(Input.GetMouseButtonDown(0)&& flag){ 
                
            if (batVec != null)
            {
                flag = false;
                batcircle = Instantiate(batCircle) as GameObject;

                batcircle.transform.position = (Vector3)batVec;
                anim.Play("Nageru_mae");
            }
        }else if(Input.GetMouseButtonUp(0)&&batcircle!=null){
            Destroy(batcircle);
			StartCoroutine("BatStart");
			anim.Play("Nageru_ato");
        }


        if(Input.GetMouseButtonDown(1)){
            charmField.SetActive(true);
        }else if(Input.GetMouseButtonUp(1)){
            charmCollision.SetActive(true);
			charmField.SetActive(false);
            StartCoroutine("CharmStart");
            anim.Play("Charm");
        }
	}


    IEnumerator CharmStart(){
        yield return new WaitForSeconds(2);
        charmCollision.SetActive(false);
    }

	IEnumerator BatStart(){
		bat = Instantiate (Bat) as GameObject;
        if (batVec!=null)
        bat.transform.position = (Vector3)batVec;
		yield return new WaitForSeconds (2);
		Destroy (bat);
		flag = true;
	}

}
