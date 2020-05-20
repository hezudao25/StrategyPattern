using StrategyPattern.Interface;
using StrategyPattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    /// <summary>
    /// 1 策略模式(Strategy)介绍和优缺点
    /// 2 策略模式和简单工厂的结合
    /// 3 策略模式的应用
    /// 
    /// 设计模式：面向对象语言开发过程中，对各种问题和场景的解决方案的沉淀
    ///           ---是解决问题的套路，
    ///           提出场景--解决问题--总结沉淀--推广应用
    /// 行为型设计模式：关注对象和行为的分离
    /// 设计模式都是为了解决一类问题而存在的，往往在解决一类问题的同时会带来的新的问题，会有对应的解决方案。设计模式不是万能的
    /// 
    /// 程序设计：不关系功能性，关注的非功能性的要求，程序的扩展性--可读性--健壮性
    /// 
    /// 策略模式已经完成了！
    /// 策略模式应对业务处理中，会有多种相似处理方式(算法)，然后封装成算法+抽象，此外，调用环节也有扩展要求的，来个context
    /// 好处：算法封装，有抽象可以扩展；
    ///       调用环节转移，可以扩展；
    /// 缺陷：上端必须知道全部算法，而且知道映射关系
    /// 最终我们会解决问题，但是这个不属于策略模式
    /// 
    /// 其实一样的功能，可以多样的实现，
    /// 但是不同的实现，真的可以看出不同的水准
    /// 擅长什么，是很容易的暴露的
    /// 看花容易绣花难，
    /// 
    /// 扩展性---抽象---反射---动态
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("策略模式");
                Console.WriteLine("下面是一个计算器展示demo:");
                while (true)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("******************************");
                    Console.WriteLine("******************************");
                    #region UI 前端逻辑 接受用户输入并验证
                    int iInputLeft = 0;
                    int iInputRight = 0;
                    string operate = "";

                    Console.WriteLine("输入第一个数字(整数):");
                    string sInputLeft = Console.ReadLine();
                    if (!int.TryParse(sInputLeft, out iInputLeft))
                    {
                        Console.WriteLine("输入数字无效,请重新输入");
                        continue;
                    }

                    Console.WriteLine("输入计算符号(+-*/):");
                    operate = Console.ReadLine();
                    string CaculationType = System.Configuration.ConfigurationManager.AppSettings["CaculationType"];
                    if (!CaculationType.Split(',').Contains(operate))
                    {
                        Console.WriteLine("输入计算符号无效,请重新输入");
                        continue;
                    }

                    Console.WriteLine("输入第二个数字(整数):");
                    string sInputRight = Console.ReadLine();
                    if (!int.TryParse(sInputRight, out iInputRight))
                    {
                        Console.WriteLine("输入数字无效,请重新输入");
                        continue;
                    }
                    #endregion

                    #region 后台逻辑 业务逻辑
                    int iResult = 0;
                    //switch (operate)//1 业务逻辑都暴露在上端，封装转移一下  POP--OOP
                    //{
                    //    case "+":
                    //        iResult = iInputLeft + iInputRight;
                    //        break;
                    //    case "-":
                    //        iResult = iInputLeft - iInputRight;
                    //        break;
                    //    case "*":
                    //        iResult = iInputLeft * iInputRight;
                    //        break;
                    //    case "/":
                    //        iResult = iInputLeft / iInputRight;
                    //        break;
                    //    default:
                    //        Console.WriteLine("输入符号异常,重新输入");
                    //        continue;
                    //}
                    ICaculation iCaculation = null;
                    //switch (operate)//从POP到OOP，屏蔽细节,
                    //{
                    //    case "+":
                    //        iCaculation = new Plus();
                    //        break;
                    //    case "-":
                    //        iCaculation = new Minus();
                    //        break;
                    //    case "*":
                    //        iCaculation = new Mutiply();
                    //        break;
                    //    case "/":
                    //        iCaculation = new Devision();
                    //        break;
                    //    default:
                    //        Console.WriteLine("输入符号异常,重新输入");
                    //        continue;
                    //}
                    //3 转移了算法创建以及映射关系，封装了一下
                    //iCaculation = Factory.GetCaculation(operate);
                    iCaculation = Factory.GetCaculationReflection(operate);
                    //1 转移了算法逻辑
                    //iResult = iCaculation.Caculation(iInputLeft, iInputLeft);
                    CaculationContext context = new CaculationContext(iCaculation, iInputLeft, iInputRight);
                    //2 转移了算法的调用逻辑
                    iResult = context.Action();

                    Console.WriteLine("计算为: {0}{1}{2}={3}", iInputLeft, operate, iInputRight, iResult);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
