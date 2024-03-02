using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVFX : MonoBehaviour
{
    [SerializeField] float _duration;

    //Function yang terpanggil pada saat gameobject aktif
    private void OnEnable()
    {
        StartCoroutine(VFXDuration());
    }

    //Functuion untuk mengembalikan VFX kembali ke pool bila vfx sudah berjalan setelah beberapa durasi tertentu 
    IEnumerator VFXDuration()
    {
        yield return new WaitForSeconds(_duration);
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
