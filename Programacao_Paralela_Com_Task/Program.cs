using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Programacao_Paralela_Com_Task
{
    class Program
    {
        static bool ImprimeMensagem(int startDoContador)
        {
            for (int i = startDoContador; i <= startDoContador+10; i++)
            {
                Console.WriteLine("Contador da Task: " + i);
                Thread.Sleep(500); // Provoca um tempo de execução de +- 5s
            }
            return true;
        }

        static void Main(string[] args)
        {
            bool retornouDaTask = false;

            // Dispara a Task para ser executada em paralelo
            Task taskImprimeMensagem = Task.Run(() => retornouDaTask = ImprimeMensagem(5));

            /*            
            ### OBSERVAÇÕES: ###
            
            # Disparo da Task sem retorno e com parâmetro:
            Task taskImprimeMensagem = Task.Run(() => ImprimeMensagem(5));
            
            # Posso usar o mesmo método para várias Tasks:
            Task taskImprimeMensagem = Task.Run(() => ImprimeMensagem(5));
            Task taskImprimeMensagem2 = Task.Run(() => ImprimeMensagem(12));
            Task taskImprimeMensagem3 = Task.Run(() => ImprimeMensagem(250));
            -
            Task taskPrintMessage = Task.Run(() returnOfTask => PrintMessage(50));
            Task taskPrintMessage2 = Task.Run(() returnOfTask => PrintMessage(120));
            Task taskPrintMessage3 = Task.Run(() returnOfTask2 => PrintMessage(2500));

            ### ###
            */

            Console.WriteLine($"Resultado antes do retorno da Task: {retornouDaTask}");

            // Método .Wait abaixo, aguardará no máximo 10s pelo retorno da Task.
            if(taskImprimeMensagem.Wait(10000) == false)
            {
                Console.WriteLine($"### Ainda não houve retorno da Task. ###");
            }
            else
            {
                Console.WriteLine($"Retorno da Task Confirmado!");
                Console.WriteLine($"Resultado depois do retorno da Task: {retornouDaTask}");

            }

            // Confirmação do paralelismo
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Contador da Thread Main: " + i);
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }
    }
}
