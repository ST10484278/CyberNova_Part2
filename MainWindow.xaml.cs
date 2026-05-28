using System.Windows;

namespace CyberNova
{
    public partial class MainWindow : Window
    {
        private ChatBot bot = new ChatBot();

        public MainWindow()
        {
            InitializeComponent();

            // ASCII ART HEADER
            AsciiArtBox.Text =
@"   _____      _               _   _                 
  / ____|    | |             | \ | |                
 | |    _   _| |__   ___ _ __|  \| | _____   ____ _ 
 | |   | | | | '_ \ / _ \ '__| . ` |/ _ \ \ / / _` |
 | |___| |_| | |_) |  __/ |  | |\  | (_) \ V / (_| |
  \_____\__, |_.__/ \___|_|  |_| \_|\___/ \_/ \__,_|
         __/ |                                      
        |___/                                                                                           ";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputBox.Text;

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            string userName = "User";

            // Show user message
            ChatHistory.AppendText("You: " + userInput + "\n");

            // Get bot response
            string response = bot.GetResponse(userInput, userName);

            // Show bot message
            ChatHistory.AppendText("CyberNova: " + response + "\n\n");

            InputBox.Clear();

            ChatHistory.ScrollToEnd();
        }
    }
}