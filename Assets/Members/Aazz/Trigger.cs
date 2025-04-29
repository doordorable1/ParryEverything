using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public int index;
     public UnityEvent OnEnter;
    // public UnityEngine.Events.UnityEvent OnColEnter;
    //public UnityEngine.Events.UnityEvent OnEixt;
    // public LayerMask CheckLayer;

    void Start()
    {
        var v = FindObjectOfType<Trigger>();
       var v1= v.transform.parent.parent.GetComponentsInChildren<Trigger>();
        for (int i = 0; i < v1.Length; i++)
        {
            if(v1[i].gameObject==gameObject)
                  v1[i].index = i;        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Player>() != null)
        {
            Debug.Log("Stage" + index +"    "+ "PlayTime" + Time.time);
            OnEnter.Invoke();
        }
    }






    public void StageNext()
    {
        if (SceneManager.GetActiveScene().buildIndex != SceneManager.GetAllScenes().Length - 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void SaveBefore()// 현 맵 리셋
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
