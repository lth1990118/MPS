using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MPS.Unity
{
    public class UnityContainManager
    {
        //private static IUnityContainer container = null;
        //private static void RegisterContainer()
        //{
        //    container = new UnityContainer();
        //    UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
        //    config.Configure(container, "Programmer");
        //}
        //private IUnityContainer LoadUnityConfig()
        //{
        //    ////根据文件名获取指定config文件
        //    string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Unity.config";
        //    var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };

        //    //从config文件中读取配置信息
        //    Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        //    var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
        //    var container = new UnityContainer();
        //    foreach (var item in unitySection.Containers)
        //    {
        //        container.LoadConfiguration(unitySection, item.Name);
        //    }

        //    return container;
        //}
    }
}