using CommunityToolkit.Mvvm.ComponentModel;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manigdha.Model;
using SharedModal.ClientServerConnection.Product_Catagory;
using SharedModal.ClientServerConnection.Catagory_Type;
using Manigdha.GraphQL_Execution;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Manigdha.View;
using CommunityToolkit.Mvvm.Input;
using Manigdha.Model.StaticFolder;

namespace Manigdha.ViewModel
{
    public partial class ProductInfoFillViewModal: ObservableObject
    {
        [ObservableProperty]
        bool isSelectGridVisible;
        [ObservableProperty]
        bool isLodaingGridVisible;
        [ObservableProperty]
        bool isPickInfoVisible;
        [ObservableProperty]
        string selectedProductCatagory;
        [ObservableProperty]
        string selectedCatagoryType;
        [ObservableProperty]
        List<string> productCatagoryNameList;
        [ObservableProperty]
        List<string> catagoryTypeNameList;
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string price;
        [ObservableProperty]
        string titleError;
        [ObservableProperty]
        string descriptionError;
        [ObservableProperty]
        string priceError;
        [ObservableProperty]
        string catagoryTypeError;
        [ObservableProperty]
        string productCatagoryError;

        bool isBusy;
        private ShowSnakeBar showSnake = new ShowSnakeBar();
        private ProductInformationFillViewModalQuery query;
        List<ProductCatagory> PikerProductCatagoryList;
        public ProductInfoFillViewModal()
        {
            CURDCall<ProductCatagory> pc = new CURDCall<ProductCatagory>();
            CURDCall<CatagoryType> ct = new CURDCall<CatagoryType>();
            ProductCatagoryServerConnection pcconn = new ProductCatagoryServerConnection(pc);
            CatagoryTypeServerConnection ctconn= new CatagoryTypeServerConnection(ct);
            query = new ProductInformationFillViewModalQuery(ctconn, pcconn);
            isBusy = false;
            IsSelectGridVisible = true;
            getProductCatagoryList();

        }

        public async Task getProductCatagoryList()
        {
            isBusy = true;
            IsLodaingGridVisible = isBusy;
            IsPickInfoVisible = !isBusy;
            try
            {
                PikerProductCatagoryList = await query.GetAllCatagory();
                ProductCatagoryNameList = PikerProductCatagoryList.Where(c => c.Name != null).Select(c => c.Name).ToList();
                TemporaryStaticInfo.PikerProductCatagoryList = PikerProductCatagoryList;
            }
            catch (Exception ex) { await showSnake.Show(ex.Message, SharedModal.Enums.SnakeBarType.Type.Danger); }
            isBusy = false;
            IsLodaingGridVisible = isBusy;
            IsPickInfoVisible = !isBusy;
        }

        [RelayCommand]
        public void GotoImageVerification()
        {
            TitleError = "";
            DescriptionError = "";
            PriceError = "";
            ProductCatagoryError = "";
            CatagoryTypeError = "";
            if (string.IsNullOrEmpty(Title)) { TitleError = "Title can't be empty"; return; }
            if (string.IsNullOrEmpty(Description)) { DescriptionError = "Description can't be empty"; return; }
            if (string.IsNullOrEmpty(Price)) { PriceError = "Price can't be empty"; return; }
            if (Price.All(char.IsDigit) == false) { PriceError = "Not a valid price"; return; }
            if (int.Parse(price) < 100) { PriceError = "Cannot sell any product less then 100 taka"; return; }
            if (string.IsNullOrEmpty(SelectedProductCatagory)) { ProductCatagoryError = "Please select product catagory"; return; }
            if (string.IsNullOrEmpty(SelectedCatagoryType)) { CatagoryTypeError = "Please select product catagory type"; return; }

            GoToVerification();
        }
        public async Task GoToVerification()
        {
            await Shell.Current.GoToAsync(nameof(UploadImage));
        }
    }
}
