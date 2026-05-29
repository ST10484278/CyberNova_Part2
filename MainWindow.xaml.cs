using System.Windows;

namespace CyberNova
{
    public partial class MainWindow : Window
    {
        private ChatBot bot = new ChatBot();

        public MainWindow()
        {
            InitializeComponent();

            // STARTUP ONLY (NO LOGIC HERE)
            AsciiArtBox.Text = bot.GetAsciiArt();
            bot.PlayGreetingAudio();
            ChatHistory.AppendText(bot.GetStartupMessage() + "\n\n");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputBox.Text;

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            //string response = bot.GetResponse(userInput, "User");
            string response = bot.GetResponse(userInput);

            ChatHistory.AppendText("You: " + userInput + "\n");
            ChatHistory.AppendText("CyberNova: " + response + "\n\n");

            InputBox.Clear();
            ChatHistory.ScrollToEnd();
        }
    }
}