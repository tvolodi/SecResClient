using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SecResClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HubConnection connection;

        public MainPage()
        {
            this.InitializeComponent();

            HubConnect();
        }

        private async Task HubConnect()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/secHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(1000);
                await connection.StartAsync();
            };

            try
            {
                await connection.StartAsync();
            }
            catch (Exception e)
            {
                MessageDialog errorMessage = new MessageDialog($"Error: {e.Message}");
                await errorMessage.ShowAsync();
            }

        }
    }
}
