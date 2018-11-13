using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

    class WuJiang
    {
        public string name;            //名字
        public int force;              //武力
        public int captain;            //统帅
        public int intelligence;       //智力
        public int political;          //内政

        public int score;             //得分


        public void showName()         //显示名字
        {
            Console.WriteLine(name);
        }
        public void showScore()        //显示得分
        {
            Console.WriteLine(score);
        }
        public void showAll()          //显示全部
        {
            Console.Write(" ");
            Console.Write(name + ": ");
            Console.Write("武力"+ force +" ");
            Console.Write("统帅" + captain + " ");
            Console.Write("智力" + intelligence + " ");
            Console.Write("内政" + political + " ");
            Console.WriteLine();
        }
        
        public void addScore()         //增加1分
        {
            score++;
        }

        public WuJiang(string n, int f, int c, int i, int p)   //构造函数
        {
            name          = n;
            force         = f;
            captain       = c;
            intelligence  = i;
            political     = p;
            score         = 0;
        }

    }


    class Program
    {

        static int compare(int x, int y) //大 1，等于0 ，小 -1
        {
            int good;
            if (x > y) { good = 1; }
            else if (x == y) { good = 0; }
            else { good = -1; }
            return good;
        }
        static void statistics(WuJiang a, int i)    //计分
        {
            if (i == 1)
            {
                a.addScore();
                a.addScore();
            }
            else if (i == 0)
            {
                a.addScore();
            }
            else
            {
                
            }
        }
        static void calculateGuysScore(WuJiang[] guys,int howManyGuys)  //计算人们的分数
        {
            int h = howManyGuys;
            for (int i = 0; i <h ; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    WuJiang a = guys[i];
                    WuJiang b = guys[j];
                    if (a.name == b.name) { continue; }
                    else
                    {
                        //武力对决
                        statistics(a, compare(a.force, b.force));
                        statistics(a, compare(a.captain, b.captain));
                        statistics(a, compare(a.intelligence, b.intelligence));
                        statistics(a, compare(a.political, b.political));

                    }
                }
            }
        }
        static void whoIsTheBestGuys(WuJiang[] guys, int howManyGuys)
        {
            int h = howManyGuys;
            int noErr = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    WuJiang a = guys[i];
                    WuJiang b = guys[j];
                    if (a.name == b.name) { continue; }
                    else if (a.score >= b.score)
                    {
                        if (j == 4) {
                            Console.WriteLine();
                            Console.WriteLine(a.name + " 是超级武将");
                            Console.WriteLine("     得分是" + a.score);
                            noErr = 1;
                            break; 
                        }
                        else continue;
                    }
                    else break;
                    if (j == 4 && noErr != 1)
                    {
                        Console.WriteLine("Error happen!");
                    }
                }
            }
        }
        static void showMeAllGuys(WuJiang[] guys, int howManyGuys)
        {
            int h = howManyGuys;
            for (int i = 0; i < h; i++)
            {
                WuJiang a = guys[i];
                a.showAll();
            }
        }


        static void Main(string[] args)
        {
            WuJiang[] guys = new WuJiang[5];

            guys[0] = new WuJiang("关羽", 97, 96, 73, 62);
            guys[1] = new WuJiang("张飞", 98, 90, 30, 22);
            guys[2] = new WuJiang("赵云", 96, 92, 75, 65);
            guys[3] = new WuJiang("马超", 96, 91, 44, 26);
            guys[4] = new WuJiang("黄忠", 95, 89, 66, 52);

            showMeAllGuys(guys, 5);
            calculateGuysScore(guys, 5);
            whoIsTheBestGuys(guys, 5);
            Console.ReadKey();


        }
    }
}
