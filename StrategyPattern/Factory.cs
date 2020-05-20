using StrategyPattern.Interface;
using StrategyPattern.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    /// <summary>
    /// 面向对象语言开发从来不担心代码多，因为可以封装一下
    /// 工厂只是转移了矛盾，并没有消除矛盾
    /// 代码升级跟下象棋是一样的，高手其实就是看得远，能看到3步4步
    /// 代码的升级是一步一步来的，先升级再解决问题，先解决眼前的问题，再解决下一步的问题
    /// 
    /// 会下象棋小伙伴儿刷个6
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// 不仅把对象创建给屏蔽了，而且映射关系也可以配置文件决定了
        /// </summary>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static ICaculation GetCaculationReflection(string operate)
        {
            string key = $"ICaculation{operate}";
            string dllType = ConfigurationManager.AppSettings[key];
            Assembly assembly = Assembly.Load(dllType.Split(',')[1]);
            Type type = assembly.GetType(dllType.Split(',')[0]);
            return (ICaculation)Activator.CreateInstance(type);
        }
        public static ICaculation GetCaculation(string operate)
        {
            ICaculation iCaculation = null;
            switch (operate)
            {
                case "+":
                    iCaculation = new Plus();
                    break;
                case "-":
                    iCaculation = new Minus();
                    break;
                case "*":
                    iCaculation = new Mutiply();
                    break;
                case "/":
                    iCaculation = new Devision();
                    break;
                default:
                    Console.WriteLine("输入符号异常,重新输入");
                    throw new Exception("输入符号异常,重新输入");
            }
            return iCaculation;
        }
    }
}
