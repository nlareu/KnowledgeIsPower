using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentatioLevel_Class : MonoBehaviour {

    public float DisplayInterval;
    public List<GameObject> Images;

    private float currentDisplayInterval = 5.0f;
    private int currentItemIndex = -1;
    private bool fadingIn = false;
    private bool fadingOut = false;
    private Action onCompleteCallback;

    public PresentatioLevel_Class()
    {
        this.DisplayInterval = 5.0f;
        this.Images = new List<GameObject>();
    }

    // Use this for initialization
    void Start ()
    {
        this.Images.ForEach(item =>
        {
            Color cur = item.GetComponent<Renderer>().material.color;

            item.GetComponent<Renderer>().material.color = new Color(cur.r, cur.g, cur.b, 0);

            //iTween.ColorTo(item, Color.black, 1);
            //item.
            //item.renderer = new Color(
            //      mObj.color.r, mObj.color.g,
            //      mObj.color.b, newAlpha);

            //item.gameObject.SetActive(false);
            //iTween.FadeTo(
            //    item,
            //    iTween.Hash(
            //        "alpha", 0,
            //        "time", 0.01f
            //    )
            //);

        });

        this.DisplayNextItem();
    }

    // Update is called once per frame
    void Update () {
        if ((this.fadingIn == false) && (this.fadingOut == false))
        {
            this.currentDisplayInterval -= Time.deltaTime;

            if (this.currentDisplayInterval <= 0)
            {
                this.fadingOut = true;

                iTween.FadeTo(
                    this.Images[this.currentItemIndex],
                    iTween.Hash(
                        "alpha", 0,
                        "time", 2,
                        "oncompletetarget", this.gameObject,
                        "oncomplete", "ImageFadeOut_Complete"
                    )
                );
            }
        }
    }

    public void Display(Action onCompleteCallback)
    {
        this.onCompleteCallback = onCompleteCallback;

        this.gameObject.SetActive(true);
    }
    private void DisplayNextItem()
    {
        this.currentItemIndex++;
        this.fadingIn = true;

        this.Images[this.currentItemIndex].SetActive(true);

        iTween.FadeTo(
            this.Images[this.currentItemIndex],
            iTween.Hash(
                "alpha", 1,
                "time", 2,
                //"onstarttarget", this.gameObject,
                //"onstart", "ImageFadeIn_Start",
                "oncompletetarget", this.gameObject,
                "oncomplete", "ImageFadeIn_Complete"
            )
        );
    }

    //public void FadeIn_Complete()
    //{
    //    Destroy(this.gameObject);

    //    this.onCompleteCallback();
    //}
    public void ImageFadeIn_Complete()
    {
        this.fadingIn = false;
        this.currentDisplayInterval = this.DisplayInterval;
    }
    public void ImageFadeOut_Complete()
    {
        this.fadingOut = false;

        //this.Images[this.currentItemIndex].SetActive(false);
        Destroy(this.Images[this.currentItemIndex].gameObject);

        if (this.currentItemIndex < this.Images.Count - 1)
        {
            this.DisplayNextItem();
        }
        else
        {
            Destroy(this.gameObject);

            this.onCompleteCallback();

            //iTween.FadeTo(
            //    this.gameObject,
            //    iTween.Hash(
            //        "alpha", 0,
            //        "time", 2,
            //        "oncomplete", "FadeIn_Complete"
            //    )
            //);
        }
    }
}
