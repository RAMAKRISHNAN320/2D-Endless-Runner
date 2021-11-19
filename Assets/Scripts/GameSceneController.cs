using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Camera gameCamera;
    [SerializeField] GameObject[] BlockPrefabs;
    private float gamePointer;
    private float safeSpawningArea=25f;
    [SerializeField] Text gameText;
    [SerializeField] bool isGameOver;
    [SerializeField] GameObject GameOverPanel;
    

    // Start is called before the first frame update
    void Start()
    {

        gamePointer = -30f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            gameCamera.transform.position = new Vector3
                (player.transform.position.x, 
                gameCamera.transform.position.y, 
                gameCamera.transform.position.z);
            gameText.text = "Score:" + Mathf.Floor(player.transform.position.x);
        }
        else
        {
            if(!isGameOver)
            {
                isGameOver = true;
                GameOverPanel.SetActive(true);
                
            }
        }
        while(player!=null && gamePointer<player.transform.position.x+safeSpawningArea)
        {
            int blockIndex = Random.Range(0, BlockPrefabs.Length);
            if(gamePointer<0)
            {
                blockIndex = 0;
            }
            GameObject blockObject = Instantiate(BlockPrefabs[blockIndex]);
            blockObject.transform.SetParent(this.transform);
            Blocks block = blockObject.GetComponent<Blocks>();
            blockObject.transform.position = new Vector2(gamePointer + block.size / 2,0);
            gamePointer += block.size; 
        }
      
        
    }
}
