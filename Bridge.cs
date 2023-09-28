using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHomeTaskPattern2
{
    internal class Bridge
    {
        // Інтерфейс для інкапсуляції реалізації комп'ютера
        public interface IComputerImplementation
        {
            string BuildComputer(string processor, int memoryGB, int storageGB, string graphicsCard);
        }

        // Клас комп'ютера, який використовує реалізацію (Bridge)
        public abstract class Computer
        {
            protected IComputerImplementation implementation;

            public Computer(IComputerImplementation implementation)
            {
                this.implementation = implementation;
            }

            public abstract string Assemble(string processor, int memoryGB, int storageGB, string graphicsCard);
        }
        // Реалізація для створення настільного комп'ютера
        public class DesktopComputerImplementation : IComputerImplementation
        {
            public string BuildComputer(string processor, int memoryGB, int storageGB, string graphicsCard)
            {
                return $"Характеристики ПК:\nПроцесор: {processor}\nОперативна пам'ять: {memoryGB} GB\nПам'ять: {storageGB} GB\nВідеокарта: {graphicsCard}";
            }
        }

        // Реалізація для створення ноутбука
        public class LaptopImplementation : IComputerImplementation
        {
            public string BuildComputer(string processor, int memoryGB, int storageGB, string graphicsCard)
            {
                return $"Характеристики Ноутбука:\nПроцесор: {processor}\nОперативна пам'ять: {memoryGB} GB\nПам'ять: {storageGB} GB\nВідеокарта: {graphicsCard}";
            }
        }
        public class DesktopComputer : Computer
        {
            public DesktopComputer(IComputerImplementation implementation) : base(implementation)
            {
            }

            public override string Assemble(string processor, int memoryGB, int storageGB, string graphicsCard)
            {
                // Логіка для створення настільного комп'ютера
                return implementation.BuildComputer(processor, memoryGB, storageGB, graphicsCard);
            }
        }

        public class Laptop : Computer
        {
            public Laptop(IComputerImplementation implementation) : base(implementation)
            {
            }

            public override string Assemble(string processor, int memoryGB, int storageGB, string graphicsCard)
            {
                // Логіка для створення ноутбука
                return implementation.BuildComputer(processor, memoryGB, storageGB, graphicsCard);
            }
        }
    }
}
