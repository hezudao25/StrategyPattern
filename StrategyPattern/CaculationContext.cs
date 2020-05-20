using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    /// <summary>
    /// 见过哪些context,---httpcontext dbcontext callcontext
    /// HttpContext,ControllerContext,ActionExecutingContext,ActionExecutedContext,ResultExecutingContext,ResulViewContexttExecutedContext,ExceptionContext,
    /// 上下文环境:是为了保存整个请求过程中，全部的信息--中间结果--最终结果
    /// 行为型设计模式的标配，行为会无止境的到处转移，方法需要参数。执行结果
    /// 
    /// 包一层：没有什么技术问题是包一层不能解决的，如果有，再包一层
    /// 中间层，转移调用，核心意义就在于调用环节可以扩展
    /// </summary>
    public class CaculationContext
    {
        private ICaculation _iCaculation = null;
        private int _iInpuLeft = 0;
        private int _iInputRight = 0;
        public CaculationContext(ICaculation caculation, int iInpuLeft, int iInputRight)
        {
            this._iCaculation = caculation;
            this._iInpuLeft = iInpuLeft;
            this._iInputRight = iInputRight;
        }

        private string Para = "";//可能要调用第三方接口

        /// <summary>
        /// 也许调用算法，需要额外的参数信息
        /// </summary>
        /// <returns></returns>
        public int Action()
        {
            try
            {
                Console.WriteLine("Caculation");
                Console.WriteLine(this.Para);
                return this._iCaculation.Caculation(this._iInpuLeft, this._iInputRight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
