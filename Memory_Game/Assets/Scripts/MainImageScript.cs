using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Image : MonoBehaviour
{
    [SerializeField] private GameObject image_desconhecida;
    [SerializeField] private GameController gameController;

    public void OnMouseDown()
    {
        //Checa se a imagem está ativa, e se estiver a oculta
        if (image_desconhecida.activeSelf && gameController.canOpen) 
        {
            image_desconhecida.SetActive(false);
            gameController.imageOpener(this);
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
        GetComponent<SpriteRenderer>().sprite = image; //Obtém o componente de renderização de sprite para alterar o sprite
    }

    public void Close() 
    {
        image_desconhecida.SetActive(true); //Esconde a imagem
    }
}

