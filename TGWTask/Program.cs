using System;
using System.Collections.Generic;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGWTask.Application;
using TGWTask.Business;
using TGWTask.Infrastructure;
using TGWTask.Repositories;

namespace TWGTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfigurationPropertyService, ConfigurationPropertyService>()
            .AddSingleton<ILayerService, LayerService>()
            .AddSingleton<ILayerRepository, LayerRepository>()
            .AddSingleton<IConfigurationParser, ConfigurationParser>()
            .AddSingleton<IRawConfigurationProvider, RawConfigurationFromLocalFileProvider>()
            .BuildServiceProvider();

            Parser.Default.ParseArguments<GetConfigurationPropertyOptions, AddNewLayerOptions>(new String[] { "--help" });

            while (true)
            {
                var text = Console.ReadLine().Split();
                var parse = Parser.Default.ParseArguments<GetConfigurationPropertyOptions, AddNewLayerOptions>(text)
                    .MapResult(
                        (GetConfigurationPropertyOptions opts) => GetConfigurationProperty(opts, serviceProvider.GetRequiredService<IConfigurationPropertyService>()),
                        (AddNewLayerOptions opts) => AddNewLayer(opts, serviceProvider.GetRequiredService<ILayerService>()),
                      (errs) => 1);

            }
        }

        private static int AddNewLayer(AddNewLayerOptions opts, ILayerService layerService)
        {
            layerService.AddLayer(opts.Level, opts.ConfigurationPath, opts.LayerType);
            Console.WriteLine("Configuration layer added");
            return 0;
        }

        private static int GetConfigurationProperty(GetConfigurationPropertyOptions opts, IConfigurationPropertyService configurationPropertyService )
        {
            var value = configurationPropertyService.GetConfigurationProperty(opts.PropertyName);
            if (value == null)
                Console.WriteLine("Property not found");
            else
                Console.WriteLine(value);
            return 0;
        }

        [Verb("GetConfigPropery", HelpText = "Gets property from highest level where it is set")]
        class GetConfigurationPropertyOptions
        {
            [Option(HelpText = "PropertyName")]
            public string PropertyName { get; set; }
        }

        [Verb("AddNewLayer", HelpText = "Add new configuration layer")]
        class AddNewLayerOptions
        {
            [Option(HelpText = "Configuration path")]
            public string ConfigurationPath { get; set; }

            [Option(HelpText = "Layer level")]
            public int Level { get; set; }

            [Option(HelpText = "Layer type")]
            public LayerType LayerType { get; set; }
        }
    }
}

