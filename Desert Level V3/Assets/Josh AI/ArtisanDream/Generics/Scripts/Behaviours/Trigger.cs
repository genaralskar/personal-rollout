
using UnityEngine;

public class Trigger : MonoBehaviour
{
	public FloatBase Data;
	public FunctionBase Work;
	
	private void OnTriggerEnter(Collider other)
	{
		Work.Run(Data);
	}
}