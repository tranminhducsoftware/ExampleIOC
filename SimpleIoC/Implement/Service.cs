using System;
using SimpleIoC.Entity;
using SimpleIoC.Interface;

namespace SimpleIoC.Implement
{
    public class Service : IService
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public Service(IDatabase database,IEmailSender emailSender, ILogger logger)
        {
            _database = database;
            _emailSender = emailSender;
            _logger = logger;
        }
        public Cart HandleEvent()
        {
            var cart = new Cart()
            {
                Id = 1,
                UserId = 12
            };
            _database.Save(cart.Id);
            _logger.LogInfo(cart.ToString());
            _emailSender.SendEmail(cart.UserId);
            Console.WriteLine("Done.-------------------");
            return cart;
        }
    }
}