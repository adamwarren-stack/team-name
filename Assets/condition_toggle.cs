using UnityEngine;

public class condition_toggle : AsyncSceneLoading
{
    public bool locked = true;

    public void Unlocked(){
        PlayerPrefs.SetInt("unlocked", 1);
        locked = false;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !locked)
        {
        LoadingScreen.SetActive(true);
           LoadScene(scene_name[0]);
        }

        
    }

}
