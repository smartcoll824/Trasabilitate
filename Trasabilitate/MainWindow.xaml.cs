using S7.Net;
using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private PlcConnection plcConnection;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void ConnectButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Inițializează conexiunea la PLC (folosește IP-ul PLC-ului tău)
            plcConnection = new PlcConnection("192.168.0.1");

            // Încearcă să te conectezi la PLC
            plcConnection.Connect();

            // Verifică dacă conexiunea a fost realizată cu succes
            if (plcConnection.GetPlcInstance().IsConnected)
            {
                // Dacă conexiunea este realizată cu succes, schimbă culoarea butonului în verde
                ConnectButton.Background = new SolidColorBrush(Colors.Green);
                ConnectButton.Content = "Connected";
            }
            else
            {
                // Dacă conexiunea a eșuat, schimbă culoarea în roșu
                ConnectButton.Background = new SolidColorBrush(Colors.Red);
                ConnectButton.Content = "Failed to Connect";
            }
        }
    }
}