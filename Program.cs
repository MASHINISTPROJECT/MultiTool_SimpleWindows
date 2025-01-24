using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Serilog;
using Serilog.Events;

namespace MultiTool_SimpleWindows
{
    class Program
    {
        private static readonly string Banner = @"
        ╔═════════════════════════════════════════╗
        ║                                         ║
        ║    ░█╝   Powered By MASHINIST [YT]  ╚█░ ║
        ║                                         ║
        ╚═════════════════════════════════════════╝
";

        private static readonly Dictionary<int, string> Actions = new Dictionary<int, string>()
        {
            {1, "Открыть меню инструментов для Windows"},
            {2, "zapret обход блокировки дискорда и ютуба"}
        };

        private static readonly Dictionary<int, string> WindowsTools = new Dictionary<int, string>()
        {
            {1, "Открыть Галерею"},
             {2, "Открыть Photo Editor"}
        };

        static void Main(string[] args)
        {
            // Настройка логирования
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("MTSW.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Приложение запущено.");
            Log.Debug("Конфигурация логирования завершена.");
            Log.Information("Приложение запущено");

            // Вывод баннера
            Console.WriteLine(Banner);
            Log.Debug("Баннер выведен.");


            try
            {
                Log.Debug("Начало главного цикла приложения.");

                // Основной цикл приложения
                while (true)
                {
                    foreach (var action in Actions)
                    {
                        Console.WriteLine($"{action.Key}. {action.Value}");
                    }

                    Console.WriteLine("Введите номер действия или 0 для выхода:");

                    while (true)
                    {
                        Log.Debug("Начало цикла выбора действия.");
                        string input = Console.ReadLine();
                        Log.Debug($"Пользовательский ввод: {input}");

                        if (int.TryParse(input, out int choice))
                        {
                            if (choice == 0)
                            {
                                Log.Information("Приложение завершено пользователем.");
                                Log.Debug("Пользователь выбрал выход из приложения.");
                                break; // Выход из цикла выбора действия
                            }
                            else if (Actions.ContainsKey(choice))
                            {
                                string selectedAction = Actions[choice];
                                Log.Information($"Выбрано действие: {selectedAction}");
                                Log.Debug($"Выбрано действие: {selectedAction}");
                                PerformAction(choice);
                                Log.Debug("Выход из цикла выбора действия после выполнения.");
                                break; // Выход из цикла выбора действия после выполнения
                            }
                            else
                            {
                                Log.Warning("Неверный выбор. Пожалуйста, введите номер из списка.");
                                Console.WriteLine("Неверный выбор. Пожалуйста, введите номер из списка.");
                                Log.Debug("Неверный выбор пользователя.");
                            }
                        }
                        else
                        {
                            Log.Warning("Неверный формат ввода. Введите число.");
                            Console.WriteLine("Неверный формат ввода. Введите число.");
                            Log.Debug("Неверный формат ввода пользователя.");
                        }
                        Log.Debug("Конец цикла выбора действия.");

                    }
                    Log.Debug("Конец главного цикла приложения.");
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Произошла ошибка при работе приложения.");
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Log.Error(ex, $"Ошибка в приложении: {ex.Message}");
                Console.ReadKey();
            }
            finally
            {
                Log.CloseAndFlush();
                Log.Debug("Логирование завершено и очищено.");
            }

        }

        static void PerformAction(int actionId)
        {
            Log.Debug($"Выполнение действия: {actionId}");
            switch (actionId)
            {
                case 1:
                    ShowWindowsToolsMenu();
                    Log.Debug($"Завершено действие: {actionId}");
                    break;
                case 2:
                    ZapretBypass();
                    Log.Debug($"Завершено действие: {actionId}");
                    break;
                default:
                    Log.Warning($"Неизвестное действие: {actionId}");
                    break;
            }
        }
        static void ShowWindowsToolsMenu()
        {
            Log.Debug("Вызов подменю WindowsTools.");

            while (true)
            {
                Console.WriteLine("Выберите инструмент для Windows:");
                foreach (var tool in WindowsTools)
                {
                    Console.WriteLine($"{tool.Key}. {tool.Value}");
                }
                Console.WriteLine("0. Назад");
                Log.Debug($"Вывод списка доступных инструментов.");

                string input = Console.ReadLine();
                Log.Debug($"Пользовательский ввод: {input}");

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        Log.Debug("Пользователь выбрал возврат в основное меню.");
                        break; // Выход в основное меню
                    }
                    else if (WindowsTools.ContainsKey(choice))
                    {
                        PerformWindowsToolAction(choice);
                        Log.Debug("Выход из подменю после выполнения.");
                        break; // Выход из подменю
                    }
                    else
                    {
                        Log.Warning("Неверный выбор инструмента. Пожалуйста, введите номер из списка.");
                        Console.WriteLine("Неверный выбор инструмента. Пожалуйста, введите номер из списка.");
                        Log.Debug("Неверный выбор пользователя.");
                    }
                }
                else
                {
                    Log.Warning("Неверный формат ввода. Введите число.");
                    Console.WriteLine("Неверный формат ввода. Введите число.");
                    Log.Debug("Неверный формат ввода пользователя.");
                }
            }
        }
        static void PerformWindowsToolAction(int toolId)
        {
            Log.Debug($"Выполнение инструмента для Windows: {toolId}");
            switch (toolId)
            {
                case 1:
                    OpenGallery();
                    Log.Debug($"Завершено выполнение инструмента для Windows: {toolId}");
                    break;
                case 2:
                    OpenPhotoEditor();
                    Log.Debug($"Завершено выполнение инструмента для Windows: {toolId}");
                    break;
                default:
                    Log.Warning($"Неизвестный инструмент для Windows: {toolId}");
                    break;
            }
        }


        static void OpenGallery()
        {
            Log.Debug($"Начало выполнения действия: OpenGallery");
            try
            {
                string galleryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gallery.exe");
                if (File.Exists(galleryPath))
                {
                    Process.Start(galleryPath);
                    Log.Information("Галерея запущена.");
                    Log.Debug("Галерея запущена.");
                }
                else
                {
                    Log.Error($"Файл '{galleryPath}' не найден.");
                    Console.WriteLine($"Файл '{galleryPath}' не найден.");
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Не удалось запустить Галерею: {ex.Message}");
                Console.WriteLine($"Не удалось запустить Галерею: {ex.Message}");
                Log.Error(ex, $"Ошибка при запуске Галереи: {ex.Message}");
            }
            Log.Debug($"Завершено выполнение действия: OpenGallery");
        }
        static void OpenPhotoEditor()
        {
            Log.Debug($"Начало выполнения действия: OpenPhotoEditor");
            try
            {
                string photoEditorPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "photo_editor.exe");
                if (File.Exists(photoEditorPath))
                {
                    Process.Start(photoEditorPath);
                    Log.Information("Photo Editor запущен.");
                    Log.Debug("Photo Editor запущен.");
                }
                else
                {
                    Log.Error($"Файл '{photoEditorPath}' не найден.");
                    Console.WriteLine($"Файл '{photoEditorPath}' не найден.");
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Не удалось запустить Photo Editor: {ex.Message}");
                Console.WriteLine($"Не удалось запустить Photo Editor: {ex.Message}");
                Log.Error(ex, $"Ошибка при запуске Photo Editor: {ex.Message}");
            }
            Log.Debug($"Завершено выполнение действия: OpenPhotoEditor");
        }
        static void ZapretBypass()
        {
            Log.Debug($"Начало выполнения действия: ZapretBypass");
            try
            {
                string zapretPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zapret", "general.bat");

                if (File.Exists(zapretPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = zapretPath,
                        UseShellExecute = true // Нужно для запуска .bat
                    });
                    Log.Information("Zapret обход блокировки запущен.");
                    Log.Debug("Zapret обход блокировки запущен.");
                }
                else
                {
                    Log.Error($"Файл '{zapretPath}' не найден.");
                    Console.WriteLine($"Файл '{zapretPath}' не найден.");
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Не удалось запустить zapret обход блокировки: {ex.Message}");
                Console.WriteLine($"Не удалось запустить zapret обход блокировки: {ex.Message}");
                Log.Error(ex, $"Ошибка при запуске zapret обход блокировки: {ex.Message}");
            }

            Log.Debug($"Завершено выполнение действия: ZapretBypass");
        }
    }
}