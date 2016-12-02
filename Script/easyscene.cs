using UnityEngine;
using System.Collections;

//0:石头
//1:地面
//2:树
//3:空白
//4:树的空口
//5:平台
public class easyscene : MonoBehaviour {
    public GameObject stone;
    public GameObject grass;
    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject plantf;
    public GameObject plantf_left;
    public GameObject plantf_right;


    public Object clone;
    public int x;//数组横坐标
    public int y;//数组纵坐标
    public int k;//数组计数器
    public int y1;//数组纵坐标暂存器
    public int m2;//2号
    public int n;//树高比较器
    public int r;//树干开口处的位置
    public int[,] array = new int[200, 30];
    void Start()
    {
        // 生成地图数组
        place();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void place()
    {
        for (x = 0; x < 200; ++x)
        {
            for (y = 0; y < 30; ++y)
            {
                array[x, y] = 0;
            }
        }
        x = 0;
        while (x < 5)
        {
            y = 10;
            for (; x < 5; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 5;
        while (x < 9)
        {
            y = 13;
            for (; x < 9; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 9;
        while (x < 15)
        {
            y = 17;
            for (; x < 15; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 15;
        while (x < 19)
        {
            y = 12;
            for (; x < 19; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 19;
        array[16, y] = 7;
        array[17, y] = 6;
        array[18, y] = 8;

        x = 19;
        while (x < 26)
        {
            y = 10;
            for (; x < 26; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 22;
        array[20, y] = 7;
        array[21, y] = 6;
        array[22, y] = 6;
        array[23, y] = 8;

        x = 22;
        y = 10;
        array[x, 10] = 4;
        for (; y < 15; y++)
        {
            array[x, y + 1] = 2;
        }
        array[x, 16] = 5;

        x = 26;
        while (x < 30)
        {
            y = 13;
            for (; x < 30; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 20;
        array[25, y] = 7;
        array[26, y] = 6;
        array[27, y] = 6;
        array[28, y] = 8;

        x = 30;
        while (x < 35)
        {
            y = 15;
            for (; x < 35; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 35;
        while (x < 38)
        {
            y = 10;
            for (; x < 38; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 19;
        array[34, y] = 7;
        array[35, y] = 6;
        array[36, y] = 8;

        x = 38;
        while (x < 44)
        {
            y = 22;
            for (; x < 44; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 44;
        while (x < 47)
        {
            y = 15;
            for (; x < 47; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 47;
        while (x < 50)
        {
            y = 10;
            for (; x < 50; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 50;
        while (x < 60)
        {
            y = 10;
            for (; x < 60; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 19;
        array[47, y] = 7;
        array[48, y] = 6;
        array[49, y] = 6;
        array[50, y] = 8;

        x = 56;
        y = 10;
        array[x, 10] = 4;
        for (; y < 15; y++)
        {
            array[x, y + 1] = 2;
        }
        array[x, 16] = 5;

        x = 60;
        while (x < 63)
        {
            y = 13;
            for (; x < 63; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 63;
        while (x < 65)
        {
            y = 10;
            for (; x < 65; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 65;
        while (x < 68)
        {
            y = 14;
            for (; x < 68; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 17;
        array[62, y] = 7;
        array[63, y] = 6;
        array[64, y] = 8;

        x = 68;
        while (x < 71)
        {
            y = 18;
            for (; x < 71; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 71;
        while (x < 73)
        {
            y = 16;
            for (; x < 73; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 73;
        while (x < 75)
        {
            y = 10;
            for (; x < 75; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 22;
        array[71, y] = 7;
        array[72, y] = 6;
        array[73, y] = 8;

        x = 75;
        while (x < 82)
        {
            y = 24;
            for (; x < 82; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 82;
        while (x < 92)
        {
            y = 10;
            for (; x < 92; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 87;
        array[x, 10] = 4;
        for (; y < 15; y++)
        {
            array[x, y + 1] = 2;
        }
        array[x, 16] = 5;

        y = 22;
        array[83, y] = 7;
        array[84, y] = 6;
        array[85, y] = 8;

        y = 18;
        array[86, y] = 7;
        array[87, y] = 6;
        array[88, y] = 6;
        array[89, y] = 8;

        y = 15;
        array[82, y] = 7;
        array[83, y] = 6;
        array[84, y] = 8;

        x = 92;
        while (x < 96)
        {
            y = 12;
            for (; x < 96; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 16;
        array[91, y] = 7;
        array[92, y] = 6;
        array[93, y] = 8;

        x = 96;
        while (x < 98)
        {
            y = 17;
            for (; x < 98; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 98;
        while (x < 105)
        {
            y = 10;
            for (; x < 105; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 105;
        while (x < 109)
        {
            y = 13;
            for (; x < 109; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        y = 14;
        array[100, y] = 7;
        array[101, y] = 6;
        array[102, y] = 8;


        x = 109;
        while (x < 113)
        {
            y = 16;
            for (; x < 113; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 113;
        while (x < 118)
        {
            y = 19;
            for (; x < 118; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 118;
        while (x < 120)
        {
            y = 10;
            for (; x < 120; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }

        x = 120;
        while (x < 130)
        {
            y = 23;
            for (; x < 130; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 130;
        while (x < 133)
        {
            y = 24;
            for (; x < 133; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        x = 133;
        while (x < 140)
        {
            y = 23;
            for (; x < 140; ++x)
            {
                array[x, y] = 1;
                y1 = y;
                y1 += 1;
                for (; y1 < 30; ++y1)
                {
                    array[x, y1] = 3;
                }
            }
        }
        each();
    }
    void each()//遍历数组
    {
        for (x = 0; x < 200; x++)
        {
            for (y = 0; y < 30; y++)
            {
                if (array[x, y] == 1)
                {
                    grass.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(grass, grass.transform.position, grass.transform.rotation);
                }
                if (array[x, y] == 2)
                {
                    tree.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(tree, tree.transform.position, tree.transform.rotation);
                }
                if (array[x, y] == 0)
                {
                    stone.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(stone, stone.transform.position, stone.transform.rotation);
                }
                if (array[x, y] == 4)
                {
                    tree2.transform.position = new Vector3(x - 25, y - 10, -1);
                    clone = Instantiate(tree2, tree2.transform.position, tree2.transform.rotation);
                }
                if (array[x, y] == 5)
                {
                    tree3.transform.position = new Vector3(x - 25, y - 10, -1);
                    clone = Instantiate(tree3, tree3.transform.position, tree3.transform.rotation);
                }
                if (array[x, y] == 6)
                {
                    plantf.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(plantf, plantf.transform.position, plantf.transform.rotation);
                }
                if (array[x, y] == 7)
                {
                    plantf_left.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(plantf_left, plantf_left.transform.position, plantf_left.transform.rotation);
                }
                if (array[x, y] == 8)
                {
                    plantf_right.transform.position = new Vector3(x - 25, y - 10, 0);
                    clone = Instantiate(plantf_right, plantf_right.transform.position, plantf_right.transform.rotation);
                }

            }
        }
    }

	public int getsceneinfo(int xc,int yc)
	{
		int scenceinfo = array [xc, yc];
		return scenceinfo;
	}

}
