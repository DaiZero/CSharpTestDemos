namespace DZero.Prism.TestDemo.Infrastructure.Client.Constants
{
    public class PageType : IPageType
    {
        private MenuType _menuType;
        public MenuType MenuType
        {
            get
            {
                return _menuType;
            }

            set
            {
                _menuType = value;
                switch (value)
                {
                    case MenuType.None:
                    case MenuType.WarehouseManagement:
                    case MenuType.NewProductionImport:
                    case MenuType.ProductionManagement:
                    case MenuType.AnalysisBoard:
                    case MenuType.SystemIntegration:
                    case MenuType.EquipmentConnection:
                        GlobalApplication.CurrentApplication.MainWindow.WindowState = System.Windows.WindowState.Normal;
                        GlobalApplication.CurrentApplication.MainWindow.Height = WindowSizeConstant.MenuViewHeight;
                        GlobalApplication.CurrentApplication.MainWindow.Width = WindowSizeConstant.MenuViewWidth;

                        double dWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                        double dHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

                        GlobalApplication.CurrentApplication.MainWindow.Left = (dWidth - WindowSizeConstant.MenuViewWidth) / 2;
                        GlobalApplication.CurrentApplication.MainWindow.Top = (dHeight - WindowSizeConstant.MenuViewHeight) / 2;
                        break;
                    default:
                        GlobalApplication.CurrentApplication.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                        break;
                }
            }
        }
    }
}
