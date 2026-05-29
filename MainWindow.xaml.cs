using System.Windows;

namespace CyberNova
{
    public partial class MainWindow : Window
    {
        private ChatBot bot = new ChatBot();

        public MainWindow()
        {
            InitializeComponent();

            // ================= STARTUP ONLY =================
            AsciiArtBox.Text = bot.GetAsciiArt();
            bot.PlayGreetingAudio();

            ChatHistory.AppendText(bot.GetGreeting() + "\n\n");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputBox.Text;

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            // ================= MAIN BOT CALL =================
            string response = bot.ProcessInput(userInput);

            // ================= DISPLAY =================
            ChatHistory.AppendText("You: " + userInput + "\n");
            ChatHistory.AppendText("CyberNova: " + response + "\n\n");

            InputBox.Clear();
            ChatHistory.ScrollToEnd();
        }
    }
}