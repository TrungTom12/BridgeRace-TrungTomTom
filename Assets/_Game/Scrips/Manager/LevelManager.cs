using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager :Singleton<LevelManager>
{
    public Level[] levelPrefabs;

    public Bot botPrefabs;
    public Player playerPrefabs;

    public Vector3 FinishedPoint => currentLevel.endPoint.position;
    public int CharacterAmount => currentLevel.botAmount + 1; //
    public int ColorAmount => currentLevel.botAmount + 1;
     
    //Bot
    private List<Bot> bots = new List<Bot>();
    private Level currentLevel;

    readonly List<ColorType> colorTypes = new List<ColorType>() {/*ColorType.Black,*/ ColorType.Red, ColorType.Blue, ColorType.Green, ColorType.Yellow, ColorType.Orange, ColorType.Brown, ColorType. Violet };
    //LoadLevel
    private int LevelIndex;

    private void Awake()
    {
        LevelIndex = PlayerPrefs.GetInt("Level", 0);
    }
    private void Start()
    {
        LoadLevel(0);
        OnInit();
        //OnStartGame();
        UIManager.Ins.OpenUI<MianMenu>();
    }

    public void OnInit()
    {
        //init vi tri bat dau game
        Vector3 index = currentLevel.startPoint.position;
        float space = 2f;
        Vector3 leftPoint = ((CharacterAmount / 2 ) + (CharacterAmount % 2) * 0.5f - 0.5f ) * space * Vector3.left + index;
        
        List<Vector3> startPoint =  new List<Vector3>();

        for (int i = 0; i < CharacterAmount; i++)
        {
            startPoint.Add(leftPoint + space * Vector3.right * i);
        }

        //init Random color
        List<ColorType> colorDatas = Utiities.SortOrder(colorTypes, CharacterAmount);

        //init random vi tri cua player
        int rand = Random.Range(0, CharacterAmount);
        playerPrefabs.transform.position = startPoint[rand];
        playerPrefabs.transform.rotation = Quaternion.identity; //???
        startPoint.RemoveAt(rand);

        //set color player
        playerPrefabs.ChangeColor(colorDatas[rand]);
        colorDatas.RemoveAt(rand);

        playerPrefabs.OnInit();

        //init bot 
        for (int i = 0; i < CharacterAmount - 1; i++)
        {
            Debug.Log(startPoint[i]);
            Bot bot = Instantiate(botPrefabs, startPoint[i],Quaternion.identity);
            bot.ChangeColor(colorDatas[i]);
            bot.OnInit();
            bots.Add(bot);
            
        }
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        if (level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level]);
            currentLevel.OnInit();
        }

        else
        {
            //TODO level vuot qua limit
        }
    }

    public void OnStartGame()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay); //ChuyenState sang Gameplay roi moi dc hoat dong
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }

    public void OnFinishGame()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(null);
            bots[i].MoveStop();
        }
    }

    public void OnReset()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            Destroy(bots[i].gameObject); // nho them gamObject neu khong bot chi xoa trong code
        }
        bots.Clear();
    }

    internal void OnRetry()
    {
        OnReset();
        LoadLevel(LevelIndex);
        OnInit();
        UIManager.Ins.OpenUI<MianMenu>();

    }

    internal void OnNextLevel()
    { 
        LevelIndex++;
        PlayerPrefs.SetInt("Level", LevelIndex);
        OnReset();
        OnInit();
        UIManager.Ins.OpenUI<MianMenu>();
    }
}
