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
    class ConcreteJewelryOrderAdminViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _name;
        private JewelryItemMaterial _material;
        private DeliveryType _delivery;
        private string _clientFIO;
        private string _phone;
        private string _address;
        private float _price;
        private OrderStatus _status;
        private JewelryOrder _order;

        public ICommand NavigateBackCommand { get; }

        public EnumViewModel<OrderStatus> StatusViewModel { get; }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public JewelryItemMaterial Material
        {
            get => _material;
            set => Set(ref _material, value);
        }

        public DeliveryType Delivery
        {
            get => _delivery;
            set => Set(ref _delivery, value);
        }

        public string ClientFIO
        {
            get => _clientFIO;
            set => Set(ref _clientFIO, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        public float Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public OrderStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ConcreteJewelryOrderAdminViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            JewelryOrder order)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            _order = order;
            Name = _order.JewelryItem.JewelryName;
            Material = _order.Material;
            Delivery = _order.Delivery;
            ClientFIO = _order.ClientFIO;
            Phone = _order.Phone;
            Address = _order.Address;
            Price = _order.TotalPrice;
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
                var currentOrder = unitOfWork.OrderRepository.Get(_order.Id);
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
                        message.Subject = "Заказ готов";
                        message.Body = $"Здравствуйте, {ClientFIO}, ваш заказ {_order.JewelryItem.JewelryName} готов.";
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
                        message.Subject = "Заказ в процессе";
                        message.Body = $"Здравствуйте, {ClientFIO}, ваш заказ {_order.JewelryItem.JewelryName} принят и находится в разработке. Ожидайте. По всем вопросам можете писать на почту";
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

                unitOfWork.OrderRepository.Update(currentOrder);
                await unitOfWork.SaveAsync();
            }
        }
    }
}
