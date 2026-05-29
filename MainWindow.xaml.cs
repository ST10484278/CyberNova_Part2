using System.Windows;

namespace CyberNova
{
    public partial class MainWindow : Window
    {
        private ChatBot bot = new ChatBot();

        public MainWindow()
        {
            InitializeComponent();

            // STARTUP ONLY 
            AsciiArtBox.Text = bot.GetAsciiArt();
            bot.PlayGreetingAudio();

            AddBotMessage(bot.GetGreeting());
        }

        // SEND MESSAGE
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(InputBox.Text);
        }

        
        private void SendMessage(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return;

            // USER MESSAGE (LEFT SIDE)
            AddUserMessage(userInput);

            // BOT RESPONSE 
            string response = bot.ProcessInput(userInput);

            AddBotMessage(response);

            InputBox.Clear();
        }

        // ================= USER BUBBLE =================
        private void AddUserMessage(string text)
        {
            ChatPanel.Children.Add(new System.Windows.Controls.Border
            {
                Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(58, 58, 58)),
                CornerRadius = new System.Windows.CornerRadius(10),
                Padding = new System.Windows.Thickness(10),
                Margin = new System.Windows.Thickness(5),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                MaxWidth = 300,
                Child = new System.Windows.Controls.TextBlock
                {
                    Text = text,
                    Foreground = System.Windows.Media.Brushes.White,
                    TextWrapping = System.Windows.TextWrapping.Wrap
                }
            });
        }

        // ================= BOT BUBBLE =================
        private void AddBotMessage(string text)
        {
            ChatPanel.Children.Add(new System.Windows.Controls.Border
            {
                Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 122, 204)),
                CornerRadius = new System.Windows.CornerRadius(10),
                Padding = new System.Windows.Thickness(10),
                Margin = new System.Windows.Thickness(5),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                MaxWidth = 300,
                Child = new System.Windows.Controls.TextBlock
                {
                    Text = text,
                    Foreground = System.Windows.Media.Brushes.White,
                    TextWrapping = System.Windows.TextWrapping.Wrap
                }
            });
        }

        private void InputBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendButton_Click(sender, e);
                e.Handled = true; // prevents "ding" sound + newline
            }
        }
    }
}