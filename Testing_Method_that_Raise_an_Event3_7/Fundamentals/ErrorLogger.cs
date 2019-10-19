using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Method_that_Raise_an_Event3_7.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        private Guid _errorId;

        public void Log(string _error)
        {
            if (String.IsNullOrWhiteSpace(_error))
                throw new ArgumentNullException();


            LastError = _error;

            // Write the log to a storage
            // ...

            OnErrorLogged(Guid.NewGuid());
        }

        public virtual void OnErrorLogged(Guid _errorId)
        {
            ErrorLogged?.Invoke(this, _errorId);
        }
    }
}
