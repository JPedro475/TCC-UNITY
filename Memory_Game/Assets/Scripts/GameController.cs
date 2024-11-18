using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const int colums = 4;
    public const int rows = 2;


    public const float Xspace = 4f;
    public const float Yspace = -5f;

    [SerializeField] private Main_Image startObject;
    [SerializeField] private Sprite[] images;

    //Randomizador do array
    private int[] Randomiser(int[] locations) 
    {
        int[] array = locations.Clone() as int[];
        for(int i = 0; i < array.Length; i++) 
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < colums; i++) 
        {
            for(int j = 0; j < rows; j++) 
            {
                Main_Image gameImage;
                if(i == 0 && j == 0) 
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as Main_Image;
                }
                int index = j * colums + i;
                int id = locations[index];
                gameImage.MudarSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private Main_Image primeiraEscolha;
    private Main_Image segundaEscolha;

    private int pontuacao = 0;
    private int tentativas = 0;

    [SerializeField] private TextMesh pontuacaoText;
    [SerializeField] private TextMesh tentativasText;

    public bool canOpen 
    {
        get { return segundaEscolha == null; }
    }

    public void imageOpener(Main_Image startObject) 
    {
        if(primeiraEscolha == null) 
        {
            primeiraEscolha = startObject;
        }
        else 
        {
            segundaEscolha = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed() 
    {
        if (primeiraEscolha.spriteId == segundaEscolha.spriteId)  //Compara os dois objetos
        {
            pontuacao++; //Adiciona um ponto
            pontuacaoText.text = "Pontuação: " + pontuacao;
        }
        else 
        {
            yield return new WaitForSeconds(0.5f); //Inicia o contador de tempo

            primeiraEscolha.Close();
            segundaEscolha.Close();
        }

        tentativas++;
        tentativasText.text = "Tentativas: " + tentativas;

        primeiraEscolha = null;
        segundaEscolha = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Jogo");
    }

}
