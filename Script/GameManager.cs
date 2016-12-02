using UnityEngine;
using System.Collections;

//0:石头
//1:地面
//2:树
//3:空白
//4:树的空口
//5:平台
public class GameManager : MonoBehaviour {
    public GameObject stone;
    public GameObject grass;
    public GameObject tree;
    public GameObject tree2;
	public GameObject player;
    public Object clone;
    public int i;//数组横坐标
    public int j;//数组纵坐标
    public int k;//数组计数器
    public int m1;//数组纵坐标暂存器
    public int m2;//2号
    public int n;//树高比较器
    public int r;//树干开口处的位置
    public int[,] array = new int[50, 30];
	public ArrayList Enermy = new ArrayList();

	public delegate void addbuff(GameObject target);
	//用来维护主角特效和技能的各种组
	public ArrayList AttackBuffList = new ArrayList(); //攻击特效组

	// Use this for initialization
	void Start () {
    // 生成地图数组
        Rand();
	}
	// Update is called once per frame
	void Update () {
	}
    void Rand()
    {
        for (i = 0; i < 50; ++i) {
            for (j = 0; j < 30; ++j) {
                array[i,j] = 0;
            }
        }
        i = 0;
        while (i < 50)
        {
            int land = Random.Range(2, 8);
            int tree = Random.Range(0, land);
            int treeHeight= Random.Range(5,8);
            int height = Random.Range(0, 4);
            j = 10;
            k = 0;
            j += height;
            for (; k <= land && i<50; ++k,++i)
            {
                array[i, j] = 1;
                m1 = j;
                m1 += 1;
                for (; m1 < 30; ++m1)
                {
                    array[i, m1] = 3;
                }
                m2 = j;
                if (k == tree)
                {
                    r = Random.Range(2, 4);
                    for (; m2 - 10 - height <= treeHeight; ++m2)
                    {
                        array[i, m2] = 2;
                        n = m2 - 10 - height;
                        if (n == r)
                        {
                            array[i, m2] = 4;
                        }
                        
                    }
                }
            }
           
        }
        each();
        
    }
    void each()//遍历数组
    {
        for (i = 0; i < 50; i++)
        {
            for (j = 0; j < 30; j++)
            {
                if (array[i, j] == 1)
                {
                    grass.transform.position = new Vector3(i - 25, j - 10, 0);
                    clone = Instantiate(grass, grass.transform.position, grass.transform.rotation);
                }
                if (array[i, j] == 2)
                {
                    tree.transform.position = new Vector3(i - 25, j - 10, 0);
                    clone = Instantiate(tree, tree.transform.position, tree.transform.rotation);
                }
                if (array[i, j] == 0)
                {
                    stone.transform.position = new Vector3(i - 25, j - 10, 0);
                    clone = Instantiate(stone, stone.transform.position, stone.transform.rotation);
                }
                if (array[i, j] == 4)
                {
                    tree2.transform.position = new Vector3(i - 25, j - 10, 0);
                    clone = Instantiate(tree2, tree2.transform.position, tree2.transform.rotation);
                }
            }
        }
    }
	public int getsceneinfo(int x,int y)
	{
		int scenceinfo = array [x, y];
		return scenceinfo;
	}

	public Vector2 GetPlayerPosition()
	{
		Vector2 PlayerPosition =  new Vector2 (player.transform.localPosition.x, player.transform.position.y);
		return PlayerPosition;
	}
}

