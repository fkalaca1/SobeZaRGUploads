using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAnimation : MonoBehaviour
{
	[SerializeField] Vector3 _targetPosition;
	public bool pronadjen = false;

	private Hashtable iTweenArgs;
    // Start is called before the first frame update
    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", _targetPosition);
        iTweenArgs.Add("time", 2.5f);
        iTweenArgs.Add("easetype", iTween.EaseType.easeInOutSine);
        iTweenArgs.Add("islocal", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
        	pomjeri();
        }
    }

    void pomjeri(){
    	//iTween.MoveTo(gameObject, iTween.Hash("position", _targetPosition, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));
    	iTween.MoveTo(gameObject, iTweenArgs);
    }
}
