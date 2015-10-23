using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeKeeper : MonoBehaviour 
{

	List<Vector3> positionVal = new List<Vector3>();             
	List<Vector3> rotationVal = new List<Vector3>();             
	List<Vector3> velocityVal = new List<Vector3>();

	int indexVal;
	float counter;
	bool isRewinding;

	Rigidbody rb;

	int listLimit = 500;
	int timeLimitInSeconds =10;

	void Start()
	{
		rb = GetComponent<Rigidbody>()	;
		
	}

	void Update()
	{
		//we use a counter variable to limit the rewind mechanic usage to 10 seconds
		if(Input.GetKey(KeyCode.E))
		{

			if(counter > 0)
			{
				counter-=Time.deltaTime;
				isRewinding = true;
				Rewind();
			}
		}

		else
		{
			if(counter<timeLimitInSeconds)
			{
				counter+=Time.deltaTime;
			}

			isRewinding = false;
		}

		//if time is moving forward, keep adding new elements to the arrays
		if(!isRewinding)
		{
					
			positionVal.Add(transform.position);
			rotationVal.Add(transform.eulerAngles);
			velocityVal.Add(rb.velocity);
		
			//increase the index every frame

			if(indexVal<listLimit)
			{
				indexVal++;
				
			}
		}


		//keep removing old data if the list size exceeds a certain value
		//this is extremely important because without this logic, the list size
		//will continue to increase which is not desirable
		if(indexVal>listLimit && !isRewinding)
		{
		
			positionVal.RemoveAt(0);
			rotationVal.RemoveAt(0);
			velocityVal.RemoveAt(0);
		}

	}


	//method that actually 'rewinds' the game
	void Rewind()
	{
		//if current index is not 0
		if(indexVal>0)
		{
			//decrease index
			indexVal--;

			//get last data of this gameobject and apply it to the gameobject 
			//remove the used data thereby decreasing the list size
			transform.position = positionVal[indexVal];
			positionVal.RemoveAt(indexVal);
	
			transform.eulerAngles = rotationVal[indexVal];
			rotationVal.RemoveAt(indexVal);

			rb.velocity = velocityVal[indexVal];
			velocityVal.RemoveAt(indexVal);

		}
	}
}
