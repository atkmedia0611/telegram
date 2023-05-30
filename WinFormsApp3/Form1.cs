using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Message = Telegram.Bot.Types.Message;

namespace WinFormsApp3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TelegramBotClient botClient;
        private void Form1_Load(object sender, EventArgs e)
        {
            botClient = new TelegramBotClient("6292442311:AAGd0OLswO90AgAkZRREYjZpGUq3S2yR7J0");
            StartReceiver();
        }

        public async Task StartReceiver()
        {
            var token = new CancellationTokenSource();
            var cancetoken = token.Token;
            var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
            await botClient.ReceiveAsync(OnMesssage, ErrorMessage, ReOpt, cancetoken);

        }
        public async Task OnMesssage(ITelegramBotClient botClient, Update update, CancellationToken cancellation)
        {
            if (update.Message is Message message)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "xin chao");


            }

        }

        public async Task ErrorMessage(ITelegramBotClient telegramBot, Exception e, CancellationToken cancellation)
        {
            if (e is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync("", e.Message.ToString());

            }
        }

        //public async Task SendMessage ( Message message )
        //{

        //}
    }
}