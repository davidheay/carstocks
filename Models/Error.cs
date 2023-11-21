using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace carstocks.models;

public class Error
{

    public DateTime Date { get; private set; }
    public string Message { get; private set; }

    public Error(string message)
    {
        Message = message;
        Date = DateAndTime.Now;
    }

}
