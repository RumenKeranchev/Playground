namespace FileDownloader
{
    using System.IO;
    using System.Net.Http;
    using System.Windows;

    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        private async void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            var path = InputBox.Text.Replace("\"", "");
            ArgumentNullException.ThrowIfNullOrWhiteSpace($"Path cannot be null!");

            IProgress<int> progressTotal = new Progress<int>((i) => ProgressBarTotal.Value = i);
            IProgress<int> progressCurrent = new Progress<int>((i) => ProgressBarCurrent.Value = i);

            var file = await File.ReadAllLinesAsync(path);

            if (file == null)
            {
                throw new FileNotFoundException($"File with the specified path was not found!");
            }
            if (file.Length == 0)
            {
                throw new ArgumentException($"File must not be empty!");
            }

            for (var i = 1; i <= file.Length; i++)
            {               

                progressCurrent.Report(0);

                for (var j = 0; j < file.Length; j++)
                {
                    await Task.Delay(1);
                    progressCurrent.Report(j);
                }

                progressTotal.Report(i);
            }
        }
    }
}