
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public float lockPos;
    public float lockMin;
    public GameObject wall;
    public bool isRechaed;


    private void Start()
    {
        //PlayerPrefs.SetFloat("save", 0);
        if (isRechaed)
        {
          if(  PlayerPrefs.GetFloat("save") >0)
            {
                FindAnyObjectByType<Player>().transform.position = new Vector3(PlayerPrefs.GetFloat("save"), 0, 0);

            }

        }
    }

    void EnemyCountCheck()
    {
        List<EnemyHP> list = GetComponentsInChildren<EnemyHP>(true).ToList();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsDead == false)
            {
                Invoke("EnemyCountCheck", 1);
                return;
            }
        }

        FindAnyObjectByType<K_Camera>().lockMax = 0;
        if (wall) wall.SetActive(false);
    }
    public void OnPlayerEnter() { 

        if(isRechaed)
        {
            PlayerPrefs.SetFloat("save", 120);
        }


        Invoke("EnemyCountCheck", 1);
        FindAnyObjectByType<K_Camera>().lockMax = lockPos;
        FindAnyObjectByType<K_Camera>().lockMin = lockMin;
    }

    public void LockCamera() 
    {
    }
}
