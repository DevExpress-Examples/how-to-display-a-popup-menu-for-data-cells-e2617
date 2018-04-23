using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace CellContextMenu {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = new ProductList();
        }

        private void copyCellDataItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            GridCellMenuInfo menuInfo = view.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null) {
                string text = "" +
                    grid.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column).ToString();
                Clipboard.SetText(text);
            }
        }

        private void deleteRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            GridCellMenuInfo menuInfo = view.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
                view.DeleteRow(menuInfo.Row.RowHandle.Value);
        }
    }
}
