using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Dirt : MonoBehaviour
{
    
    private Vector2 startMouse;
    private Vector2 finalMouse;
    private float sudutGeser;
    public int orderLayer;
    
    private void Start() {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderLayer;
    }
    //point
    public GameObject Tanah;
    [SerializeField] private Transform Barat, Utara, Timur, Selatan;

    private void OnMouseDown() {
        Debug.Log(this.gameObject.name);
        //ketika mouse di klik isi startpos dengan nilai dimana posisi mouse
        startMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp() {
        //ketika mouse tidak diklik isi final mouse dengan nilai dimana posisi mouse
        finalMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HitungSudut();
        if(hitungPanjang() > 1.1){
            buatTanahBaru(sudutGeser);
        }
    }

    private float hitungPanjang(){
        return Vector2.Distance(startMouse, finalMouse);
    }

    //menghitung sudut antara titik startmouse dengan finalmouse
    private void HitungSudut(){
        sudutGeser = (float)(Mathf.Atan2(finalMouse.y - startMouse.y, finalMouse.x - startMouse.x) * 180 /  Math.PI);
        Debug.Log(sudutGeser);
    }

    private void buatTanahBaru(float sudutgeser){
        if(sudutGeser >= 0 && sudutGeser < 90){
            GameObject newTanah = Instantiate(Tanah, Barat.transform.position, quaternion.identity);
            newTanah.GetComponent<Dirt>().orderLayer = this.orderLayer - 1;
            newTanah.SetActive(true);
            // newTanah.transform.SetParent(Barat);
            // Debug.Log("Barat");
        }
        else if(sudutGeser >= 90 && sudutGeser < 180){
            GameObject newTanah = Instantiate(Tanah, Utara.transform.position, quaternion.identity);
            newTanah.GetComponent<Dirt>().orderLayer = this.orderLayer - 1;
            newTanah.SetActive(true);
            // newTanah.transform.SetParent(Utara);
            // Debug.Log("Utara");
        }
        else if(sudutGeser < -90 && sudutGeser > -180){
            GameObject newTanah = Instantiate(Tanah, Timur.transform.position, quaternion.identity);
            newTanah.GetComponent<Dirt>().orderLayer = this.orderLayer + 1;
            newTanah.SetActive(true);
            // newTanah.transform.SetParent(Timur);
            // Debug.Log("Timur");
        }
        else if(sudutGeser < 0 && sudutGeser > -90 ){
            GameObject newTanah = Instantiate(Tanah, Selatan.transform.position, quaternion.identity);
            newTanah.GetComponent<Dirt>().orderLayer = this.orderLayer + 1;
            newTanah.SetActive(true);
            // newTanah.transform.SetParent(Selatan);
            // Debug.Log("Selatan");
        }
    }

}
