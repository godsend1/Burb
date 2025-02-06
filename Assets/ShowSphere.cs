using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSphere : MonoBehaviour
{
    public GameObject sphere;

	public void ToggleSphere () {
		sphere.SetActive (!sphere.activeInHierarchy);
	}
}
