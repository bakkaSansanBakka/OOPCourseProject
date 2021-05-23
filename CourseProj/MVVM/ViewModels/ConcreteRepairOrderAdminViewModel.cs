using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    class ConcreteRepairOrderAdminViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _clientFIO;
        private string _image;
        private string _description;
        private OrderStatus _status;
        private RepairOrder _order;

        public ICommand NavigateBackCommand { get; }

        public EnumViewModel<OrderStatus> StatusViewModel { get; }

        public string ClientFIO
        {
            get => _clientFIO;
            set => Set(ref _clientFIO, value);
        }

        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public OrderStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ConcreteRepairOrderAdminViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            RepairOrder order)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            _order = order;
            ClientFIO = _order.ClientFIO;
            Image = _order.Image;
            Description = _order.Description;
            Status = _order.Status;

            StatusViewModel = new EnumViewModel<OrderStatus>();
            StatusViewModel.SelectedItem = _order.Status;
            StatusViewModel.OnSelectionChanged += StatusViewModelOnOnSelectionChanged;

            NavigateBackCommand = new NavigateCommand<OrdersAdminViewModel>(navigationStore,
                () => new OrdersAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }

        private async void StatusViewModelOnOnSelectionChanged()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var currentOrder = unitOfWork.RepairOrderRepository.Get(_order.Id);
                _order.Status = currentOrder.Status = StatusViewModel.SelectedItem;
                if (_order.Status == OrderStatus.Ready)
                {
                    try
                    {
                        MailAddress from = new MailAddress("jewelryStore11@mail.ru", "JewelryStore");
                        MailAddress to = new MailAddress("polina.potapeyko@mail.ru", "Polina");
                        Encoding encoding = System.Text.Encoding.UTF8;
                        MailMessage message = new MailMessage(from, to);
                        message.SubjectEncoding = encoding;
                        message.BodyEncoding = encoding;
                        message.Subject = "Починка готова";
                        message.Body = $"Здравствуйте, {ClientFIO}, починка готова, вы можете приехать за изделием.";
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                        smtp.Credentials = new NetworkCredential("jewelryStore11@mail.ru", "jew63@12Kk");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
                if (_order.Status == OrderStatus.InProgress)
                {
                    try
                    {
                        MailAddress from = new MailAddress("jewelryStore11@mail.ru", "JewelryStore");
                        MailAddress to = new MailAddress("polina.potapeyko@mail.ru", "Polina");
                        Encoding encoding = System.Text.Encoding.UTF8;
                        MailMessage message = new MailMessage(from, to);
                        message.SubjectEncoding = encoding;
                        message.BodyEncoding = encoding;
                        message.Subject = "Выполнение заявки";
                        message.Body = $"Здравствуйте, {ClientFIO}, мы готовы взяться за вашу заявку на ремонт изделия, давайте обговорим все подробности.";
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                        smtp.Credentials = new NetworkCredential("jewelryStore11@mail.ru", "jew63@12Kk");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }

                unitOfWork.RepairOrderRepository.Update(currentOrder);
                await unitOfWork.SaveAsync();
            }
        }

        //private static async Task SendEmailAsync()
        //{
        //    try
        //    {
        //        MailAddress from = new MailAddress("svyatik.svyaaatik@mail.ru", "JewelryStore");
        //        MailAddress to = new MailAddress("polina.potapeyko@mail.ru", "Polina");
        //        Encoding encoding = System.Text.Encoding.UTF8;
        //        MailMessage message = new MailMessage(from, to);
        //        message.SubjectEncoding = encoding;
        //        message.BodyEncoding = encoding;
        //        message.Subject = "Заказ готов";
        //        message.Body = $"Здравствуйте, {ClientFIO}";
        //        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
        //        //smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
        //        smtp.Credentials = new NetworkCredential("polina.potapeyko@mail.ru", "password12122001@z");
        //        smtp.EnableSsl = true;
        //        await smtp.SendMailAsync(message);
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка");
        //    }
            
        //}
    }
}
