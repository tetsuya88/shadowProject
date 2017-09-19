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
	void Start () {
		
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


        if(Input.GetKeyDown(KeyCode.Z)){
            charmField.SetActive(true);
        }else if(Input.GetKeyUp(KeyCode.Z)){
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
		bat.transform.position = batpos;
		yield return new WaitForSeconds (2);
		Destroy (bat);
		flag = true;
	}

}
