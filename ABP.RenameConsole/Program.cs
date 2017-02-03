using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.RenameConsole
{
    class Program
    {
        private static bool isFirstRun = true;
        //是否创建备份
        private static bool _createBackup = true;
        //项目src目录
        private static  string _folder = "";

        //原有项目公司名称
        private static string _companyNamePlaceHolder = "";
        //原有项目名称
        private static string _projectNamePlaceHolder = "";
        //新项目公司名称
        private static string _companyName = "";
        //新项目名称
        private static string _projectName = "";

        static void Main(string[] args)
        {
            if (!isFirstRun)
            {
                if (_folder == "")
                {
                    Console.WriteLine("项目地址不能为空！，请重新录入！");
                    getParam();
                }
                if (_projectNamePlaceHolder == "" || _projectName == "")
                {
                    Console.WriteLine("原有项目名称和新项目名称不能为空，请重新输入");
                    getParam();
                }
            }
            else
            {
                getParam();
            }

            Console.WriteLine("替换中...! 替换完成自动关闭窗口");
            SolutionRenamer app = new SolutionRenamer(_folder, _companyNamePlaceHolder, _projectNamePlaceHolder, _companyName, _projectName);
            app.CreateBackup = _createBackup;//是否创建备份
            app.Run();
        }


        public static void getParam()
        {
            Console.WriteLine("请输入需要ABP项目的src根目录:");
            _folder = Console.ReadLine();

            Console.WriteLine("是否创建备份？(true创建备份；false不创建备份)");
             _createBackup = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("请输入原项目的公司名称(如果没有，可以为空):");
            _companyNamePlaceHolder = Console.ReadLine();
            Console.WriteLine("请输入原项目的项目名称:");
            _projectNamePlaceHolder = Console.ReadLine();

            Console.WriteLine("请输入新项目的公司名称(如果没有，可以为空):");
            _companyName = Console.ReadLine();
            Console.WriteLine("请输入新项目的项目名称:");
            _projectName = Console.ReadLine();

            isFirstRun = false;
        }
    }
}
