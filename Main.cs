using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPICreateButton
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Моя вкладка";
            application.CreateRibbonTab(tabName); //Создание вкладки

            string utilsPipesPath = @"C:\Program Files\RevitAPITraining\RevitAPIPipeCount.dll";
            string utilsWallsPath = @"C:\Program Files\RevitAPITraining\RevitAPIVolumeAllWall.dll";
            string utilsDoorsPath = @"C:\Program Files\RevitAPITraining\RevitAPIDoorsCount.dll";

            var panel = application.CreateRibbonPanel(tabName, "Солянка"); //Создание панели на вкладке

            var buttonPipe = new PushButtonData("Трубы", "Количество труб", utilsPipesPath, "RevitAPIPipeCount.Main");
            var buttonWall = new PushButtonData("Стены", "Объем стен", utilsWallsPath, "RevitAPIVolumeAllWall.Main");
            var buttonDoors = new PushButtonData("Двери", "Количество дверей", utilsDoorsPath, "RevitAPIDoorsCount.Main");

            panel.AddItem(buttonPipe);
            panel.AddItem(buttonWall);
            panel.AddItem(buttonDoors);

            return Result.Succeeded;
        }
    }
}
