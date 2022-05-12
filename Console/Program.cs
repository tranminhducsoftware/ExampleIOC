// See https://aka.ms/new-console-template for more information

using System;
using SimpleIoC;
using SimpleIoC.Implement;
using SimpleIoC.Interface;

Console.WriteLine("Hello, World!");
DIContainer.SetModule<ILogger, Logger>();
DIContainer.SetModule<IEmailSender, EmailSender>();
DIContainer.SetModule<IDatabase, Database>();
DIContainer.SetModule<IService, Service>();


var cart = DIContainer.GetModule<IService>();
cart.HandleEvent();