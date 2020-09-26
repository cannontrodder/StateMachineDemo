using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using StateMachineDemo.States;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection.Metadata.Ecma335;

namespace StateMachineDemo
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            //var context = new ProcessContext
            //{
            //    Name = "Neil",
            //    Age = 44,
            //    HourOfDay = 0
            //};

            var context = new ProcessContext
            {
                Name = "Neil",
                Age = 44,
                HourOfDay = 19,
                CurrentStateName = "StateMachineDemo.States.Awake"
            };

            RegisterServices(context);

            serviceProvider
                .GetRequiredService<IProcessRunnerHost>()
                .StartProcess();

            DisposeServices();
        }

        #region DI Setup

        private static void RegisterServices(ProcessContext context)
        {
            serviceProvider = new ServiceCollection()
                .AddScoped<ILogger, Logger>()
                .AddScoped<IProcessRunnerHost, ProcessRunnerHost>()
                .AddSingleton<IProcessContext, ProcessContext>(factory => context)
                .BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        } 

        #endregion
    }
}
