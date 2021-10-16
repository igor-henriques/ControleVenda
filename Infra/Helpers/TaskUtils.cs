using System;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class TaskUtils
    {
        /// <summary>
        /// Espera enquanto a condição for verdadeira, ou até que atinja timeout.
        /// </summary>
        /// <param name="condition">A condição a ser verificada.</param>
        /// <param name="frequency">Frequência de checagem em milissegundo.</param>
        /// <param name="timeout">Tempo para timeout em milissegundo.</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task WaitWhile(Func<bool> condition, int frequency = 25, int timeout = -1)
        {
            var waitTask = Task.Run(async () =>
            {
                while (condition()) await Task.Delay(frequency);
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
                throw new TimeoutException();
        }

        /// <summary>
        /// Espera enquanto a condição não for verdadeira, ou até que atinja timeout.
        /// </summary>
        /// <param name="condition">A condição a ser verificada.</param>
        /// <param name="frequency">Frequência de checagem em milissegundo.</param>
        /// <param name="timeout">Tempo para timeout em milissegundo.</param>
        /// <returns></returns>
        public static async Task WaitUntil(Func<bool> condition, int frequency = 25, int timeout = -1)
        {
            var waitTask = Task.Run(async () =>
            {
                while (!condition()) await Task.Delay(frequency);
            });

            if (waitTask != await Task.WhenAny(waitTask,
                    Task.Delay(timeout)))
                throw new TimeoutException();
        }
    }
}
