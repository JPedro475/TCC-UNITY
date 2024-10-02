using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Image : MonoBehaviour
{
    [SerializeField] private GameObject image_desconhecida;

    public void OnMouseDown()
    {
        //Checa se a imagem está ativa, e se estiver a oculta
        if (image_desconhecida.activeSelf) 
        {
            image_desconhecida.SetActive(false);
        }
    }
    private int _spriteId;
    public int spriteId 
    {
        get { return _spriteId; }
    }

    public void MudarSprite(int id, Sprite image) 
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}

