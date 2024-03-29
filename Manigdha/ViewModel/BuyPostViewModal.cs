﻿using CommunityToolkit.Mvvm.ComponentModel;
using Manigdha.GraphQL_Execution;
using Manigdha.Model;
using SharedModal.ClientServerConnection.City_Server_Connection;
using SharedModal.ClientServerConnection;
using SharedModal.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedModal.ReponseModal;
using System.Net;
using System.Net.Http.Headers;
using Manigdha.Model.StaticFolder;

namespace Manigdha.ViewModel
{
    public partial class BuyPostViewModal : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<int> cList;
        [ObservableProperty]
        bool isLoading;


        private ProfileViewModalQuery profileViewModalQuery;
        public BuyPostViewModal()
        {         
            CURDCall<City> curd = new CURDCall<City>();
            UserServerConnection userServerConnection = new UserServerConnection();
            CityServerConnection cityServerConnection = new CityServerConnection(curd);
            profileViewModalQuery = new ProfileViewModalQuery(userServerConnection, cityServerConnection);
            cList = new ObservableCollection<int>();
            cList.Add(0);
            cList.Add(1);
            cList.Add(2);
            cList.Add(3);
            cList.Add(4);
            GetInitInfo();
        }
        public async Task GetInitInfo()
        {
            IsLoading = true;           
            await StaticInfo.GetAuthInfo();           
            if (StaticInfo.IsJwtTokenExpired())
            {
                ShowSnakeBar showSnakeBar = new ShowSnakeBar();
                if (!(await RefreshTokenOnExpired.RefreshTokenNow())) 
                {
                    await showSnakeBar.Show("Cant Refresh The Token", SharedModal.Enums.SnakeBarType.Type.Danger);
                }         
            }
            IsLoading = false;
        }   
    }
}
