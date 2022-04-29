using AirportServer.BL;
using Dal.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection hubConnection;
        public MainWindow()
        {
            InitializeComponent();
            DoRealTimeSuff();
        }

        async void DoRealTimeSuff()
        {
            SIgnalRChatSetup();
            await SignalRConnect();

        }

        private async Task SignalRConnect()
        {
            await hubConnection.StartAsync();
        }

        private void SIgnalRChatSetup()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/data")
                .Build();

            hubConnection.On<List<History>>("ReceiveHistory", (history) =>
            {
                History.Items.Clear();
                foreach (var item in history)
                {
                    if (item.LeavingTine == null)
                    {
                        History.Items.Add($"plane {item.PlaneId} enterd station{item.StationName} in {item.EnterTime} and leaved {item.LeavingTine}");
                    }
                    else
                        History.Items.Add($"plane {item.PlaneId} enterd station{item.StationName} in {item.EnterTime}");
                }

            });
               
            hubConnection.On<List<Dal.Models.Landing>>("ReceiveLandings", (landings) =>
            {
                Landings.Items.Clear();
                foreach (var item in landings)
                {
                    Landings.Items.Add($"plane {item.PlaneId} land in {item.Time}");
                }
            });
            
            hubConnection.On<List<Dal.Models.Departure>>("ReceiveDepartments", (departures) =>
            {
                Departures.Items.Clear();
                foreach (var item in departures)
                {
                    Departures.Items.Add($" plane {item.PlaneId} depart in {item.Time}");
                }
            });
            
            hubConnection.On<List<Dal.Models.Station>>("ReceiveStations", (stations) =>
            {
                tbl1PlaneId.Text = "";
                tbl2PlaneId.Text = "";
                tbl3PlaneId.Text = "";
                tbl4PlaneId.Text = "";
                tbl5PlaneId.Text = "";
                tbl6PlaneId.Text = "";
                tbl7PlaneId.Text = "";
                tbl8PlaneId.Text = "";
                tbl9PlaneId.Text = "";
                tbl1PlaneId.Text = stations[0].PlaneId.ToString();
                tbl2PlaneId.Text = stations[1].PlaneId.ToString();
                tbl3PlaneId.Text = stations[2].PlaneId.ToString();
                tbl4PlaneId.Text = stations[3].PlaneId.ToString();
                tbl5PlaneId.Text = stations[4].PlaneId.ToString();
                tbl6PlaneId.Text = stations[5].PlaneId.ToString();
                tbl7PlaneId.Text = stations[6].PlaneId.ToString();
                tbl8PlaneId.Text = stations[7].PlaneId.ToString();
                tbl9PlaneId.Text = stations[8].PlaneId.ToString();

            });

            hubConnection.On<List<History>, List<Dal.Models.Departure>, List<Dal.Models.Landing>, List<Dal.Models.Station>>("ReceiveAll", (history,departures, landings,stations) =>
            {
                History.Items.Clear();
                Landings.Items.Clear();
                Departures.Items.Clear();
                tbl1PlaneId.Text="";
                tbl2PlaneId.Text="";
                tbl3PlaneId.Text="";
                tbl4PlaneId.Text="";
                tbl5PlaneId.Text="";
                tbl6PlaneId.Text="";
                tbl7PlaneId.Text="";
                tbl8PlaneId.Text="";
                tbl9PlaneId.Text = "";
                foreach (var item in history)
                {
                    if (item.LeavingTine == null)
                    {
                        History.Items.Add($"plane {item.PlaneId} enterd station{item.StationName} in {item.EnterTime} and leaved {item.LeavingTine}");
                    }
                    else
                    History.Items.Add($"plane {item.PlaneId} enterd station{item.StationName} in {item.EnterTime}");
                }
                foreach (var item in landings)
                {
                    Landings.Items.Add($"plane {item.PlaneId} land in {item.Time}");
                }
                foreach (var item in departures)
                {
                    Departures.Items.Add($" plane {item.PlaneId} depart in {item.Time}");
                }
                tbl1PlaneId.Text = stations[0].PlaneId.ToString();
                tbl2PlaneId.Text = stations[1].PlaneId.ToString();
                tbl3PlaneId.Text = stations[2].PlaneId.ToString();
                tbl4PlaneId.Text = stations[3].PlaneId.ToString();
                tbl5PlaneId.Text = stations[4].PlaneId.ToString();
                tbl6PlaneId.Text = stations[5].PlaneId.ToString();
                tbl7PlaneId.Text = stations[6].PlaneId.ToString();
                tbl8PlaneId.Text = stations[7].PlaneId.ToString();
                tbl9PlaneId.Text = stations[8].PlaneId.ToString();
            });
        }
    }
}
