using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Anki.Domain.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; private set; }

        public IList<string> Errors { get; private set; } = new List<string>();

        public ResultViewModel(T data, IList<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(string message)
        {
            Errors.Add(message);
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }
    }
}
