using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteTrain : MonoBehaviour
{
    private GameObject player;
    public GameObject[] ui;
    public GameObject uiNew;
    public GameObject ruka;

    private void Awake()
    {
        player = GameObject.Find("PlayerTraining");
    }
    private void OnEnable()
    {
        player.GetComponent<PlayerTraining>().HaveDamage(transform.parent.gameObject.GetComponent<TrainPervak>().damage);
        GetComponentInParent<Animator>().enabled = false;
        GetComponentInParent<TrainPervak>().enabled = false;
        StartCoroutine(UI());
    }

    IEnumerator UI()
    {
        foreach (GameObject item in ui)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(4f);
            item.SetActive(false);
        }
        PlayerTraining.shootTemp = true;
        transform.parent.gameObject.transform.position = new Vector3(player.transform.position.x + 3f, player.transform.position.y, 0f);
        transform.parent.gameObject.GetComponent<Animator>().SetTrigger("idle");
        GetComponentInParent<TrainPervak>().enabled = true;
        TrainPervak.isCode = false;
        uiNew.SetActive(true);
        ruka.SetActive(true);
        gameObject.SetActive(false);
    }
}
